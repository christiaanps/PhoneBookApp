using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Domain.Contracts.PhoneBooks;
using PhoneBookApp.Domain.Core.PhoneBooks;
using PhoneBookApp.Infrastructures.Common;
using PhoneBookApp.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Infrastructures.DataLayer.PhoneBooks
{
    public class PhoneBookRepository : BaseRepository<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(PhoneBookAppContext dbContext) : base(dbContext)
        {
        }
    }
}
