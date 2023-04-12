using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;

namespace BookManagement.Services.Contact.Core.Repositories
{
    public interface IPersonRepository : IRepository<Persons>
    {
        Task<IEnumerable<ReportDataDto>> GetReportData();
    }
}
