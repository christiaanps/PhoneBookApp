using PhoneBookApp.Domain.Contracts.Common;
using PhoneBookApp.Domain.Core.PhoneBooks;

namespace PhoneBookApp.Domain.Contracts.PhoneBooks
{
    public interface IPhoneBookRepository : IBaseRepository<PhoneBook>
    {
    }
}
