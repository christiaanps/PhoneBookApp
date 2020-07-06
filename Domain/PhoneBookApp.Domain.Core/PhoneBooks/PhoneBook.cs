using PhoneBookApp.Domain.Core.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Domain.Core.PhoneBooks
{
    public class PhoneBook : BaseEntity
    {
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }

    }

}
