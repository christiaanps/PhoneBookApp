using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBookApp.Domain.Contracts.Entries;
using PhoneBookApp.Domain.Contracts.PhoneBooks;
using PhoneBookApp.Domain.Core.ApplicationUsers;
using PhoneBookApp.Domain.Core.Entries;
using PhoneBookApp.Domain.Core.PhoneBooks;
using PhoneBookApp.EndPoints.WebUI.Models;
using PhoneBookApp.Infrastructures.DataLayer.Common;

namespace PhoneBookApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IEntryRepository _entryRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public PhoneBookController(UserManager<ApplicationUser> userManager, IPhoneBookRepository phoneBookRepository, IEntryRepository entryRepository)
        {
            this._userManager = userManager;
            this._phoneBookRepository = phoneBookRepository;
            this._entryRepository = entryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            var user = await GetCurrentUserAsync();
            var _phoneBook = _phoneBookRepository.GetAll().Include(x => x.Entries).FirstOrDefault(n => n.Name == user.Email);
            if (_phoneBook != null)
            {
                return Ok(_phoneBook.Entries
                    .Where(pb => pb.Name.Contains(searchString) || pb.PhoneNumber.Contains(searchString) || searchString == "")
                    .Select(n => new PhoneBookEntryViewModel { EntryName = n.Name, PhoneNumber = n.PhoneNumber })
                    .ToList());
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PhoneBookEntryViewModel entry)
        {
            var user = await GetCurrentUserAsync();

            if (entry.PhoneNumber != null && entry.EntryName != null && entry.PhoneBookName == user.Email)
            {
                var existinPhoneBook = _phoneBookRepository.GetAll().Include(x => x.Entries).FirstOrDefault(n => n.Name == entry.PhoneBookName);
                if (existinPhoneBook == null)
                {
                    PhoneBook phoneBook = new PhoneBook
                    {
                        Name = entry.PhoneBookName,
                        Entries = new List<Entry>()
                    };

                    phoneBook.Entries.Add(new Entry { Name = entry.EntryName, PhoneNumber = entry.PhoneNumber });
                    _phoneBookRepository.Add(phoneBook);
                }
                else
                {
                    var newEntry = new Entry { Name = entry.EntryName, PhoneNumber = entry.PhoneNumber };
                    existinPhoneBook.Entries.Add(new Entry { Name = entry.EntryName, PhoneNumber = entry.PhoneNumber });
                    _phoneBookRepository.Update(existinPhoneBook);
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
