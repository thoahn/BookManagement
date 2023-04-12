using BookManagement.Services.Contact.Core.Repositories;
using BookManagement.Services.Contact.Data.Repositories.EntityFramework;
using BookManagement.Services.Contact.Core.UnitOfWork;

namespace BookManagement.Services.Contact.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookManagementDbContext _context;

        private PersonContactRepository _personContactRepository;

        private PersonRepository _personRepository;

        public IPersonContactRepository PersonContacts => _personContactRepository = _personContactRepository ?? new PersonContactRepository(_context);

        public IPersonRepository Persons => _personRepository = _personRepository ?? new PersonRepository(_context);

        public UnitOfWork(BookManagementDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
