using PhoneBookApp.Domain.Contracts.Entries;
using PhoneBookApp.Domain.Core.Entries;
using PhoneBookApp.Infrastructures.Common;
using PhoneBookApp.Infrastructures.DataLayer.Common;

namespace PhoneBookApp.Infrastructures.DataLayer.Entries
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        public EntryRepository(PhoneBookAppContext dbContext) : base(dbContext)
        {
        }
    }
}
