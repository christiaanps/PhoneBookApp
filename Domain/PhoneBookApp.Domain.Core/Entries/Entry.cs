using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Domain.Core.Entries
{
    public class Entry : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
