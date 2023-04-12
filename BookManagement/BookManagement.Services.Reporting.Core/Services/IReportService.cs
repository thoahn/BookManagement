using BookManagement.Services.Reporting.Core.DTO;
using BookManagement.Services.Reporting.Core.Models;

namespace BookManagement.Services.Reporting.Core.Services
{
    public interface IReportService : IService<Reports>
    {
        Task<IEnumerable<ReportDto>> GetListAsync();
        
        Task<ReportDto> AddAsync();

        Task<bool> SaveRepotData(Guid id, string data);

        Task<string> GetRepotData(Guid id);
    }
}
