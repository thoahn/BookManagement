using BookManagement.Services.Contact.Core.Models;
using BookManagement.Services.Contact.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Data.Repositories.EntityFramework
{
    public class PersonContactRepository : EfRepository<PersonContacts>, IPersonContactRepository
    {
        private BookManagementDbContext _appDbContext { get => _context as BookManagementDbContext; }

        public PersonContactRepository(BookManagementDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContactTypes>> GetContactTypeList()
        {
            return await _appDbContext.ContactTypes.ToListAsync();
        }
    }
}
