using BookManagement.Services.Contact.Core.Repositories;

namespace BookManagement.Services.Contact.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }

        IPersonContactRepository PersonContacts { get; }

        Task CommitAsync();

        void Commit();
    }
}
