using PhoneBookApp.Domain.Contracts.Common;
using PhoneBookApp.Domain.Core.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Domain.Contracts.Entries
{
    public interface IAddNewEntry: IApplicationService
    {
        Entry Execute(Entry entry);
    }
}
