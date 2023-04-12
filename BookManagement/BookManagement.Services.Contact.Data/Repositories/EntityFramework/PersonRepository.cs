using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;
using BookManagement.Services.Contact.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Contact.Data.Repositories.EntityFramework
{
    public class PersonRepository : EfRepository<Persons>, IPersonRepository
    {
        private BookManagementDbContext _appDbContext { get => _context as BookManagementDbContext; }

        public PersonRepository(BookManagementDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ReportDataDto>> GetReportData()
        {
            var locations = await (from p in _appDbContext.Persons
                                   join pc in _appDbContext.PersonContacts on p.Id equals pc.PersonId
                                   where pc.ContactTypeId == 3
                                   group pc by pc.Value into list
                                   select new ReportDataDto
                                   {
                                       Location = list.Key,
                                       RegisteredPersonCount = list.Count(),
                                       RegisteredPhoneNoCount = (from pc2 in _appDbContext.PersonContacts
                                                                 join p2 in _appDbContext.Persons on pc2.PersonId equals p2.Id
                                                                 where pc2.ContactTypeId == 1
                                                                     && (from pc3 in _appDbContext.PersonContacts where pc3.PersonId == p2.Id && pc3.Value == list.Key select pc3).Any()
                                                                 select pc2).Count(),
                                   }).ToListAsync();

            return locations;

        }
    }
}
