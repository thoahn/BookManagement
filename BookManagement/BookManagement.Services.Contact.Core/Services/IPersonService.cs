using BookManagement.Services.Contact.Core.DTO;
using BookManagement.Services.Contact.Core.Models;

namespace BookManagement.Services.Contact.Core.Services
{
    public interface IPersonService : IService<Persons>
    {
        Task<PersonDto> AddorUpdateAsync(PersonDto person);

        Task<IEnumerable<PersonDto>> GetListAsync();

        Task<IEnumerable<ReportDataDto>> GetReportData();

    }
}
