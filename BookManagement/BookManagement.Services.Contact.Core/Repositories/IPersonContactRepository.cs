using BookManagement.Services.Contact.Core.Models;

namespace BookManagement.Services.Contact.Core.Repositories
{
    public interface IPersonContactRepository : IRepository<PersonContacts>
    {
        Task<IEnumerable<ContactTypes>> GetContactTypeList();
    }
}
