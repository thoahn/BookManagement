using BookManagement.Services.Reporting.Core.Models;
using BookManagement.Services.Reporting.Core.Repositories;
using BookManagement.Services.Reporting.Data;
using BookManagement.Services.Reporting.Data.Repositories.EntityFramework;

namespace PhoneBook.Services.Report.Data.Repositories.EntityFramework
{
    public class ReportsRepository : EfRepository<Reports>, IReportsRepository
    {
        private BookManagementReportDbContext _appDbContext { get => _context as BookManagementReportDbContext; }

        public ReportsRepository(BookManagementReportDbContext context) : base(context)
        {
        }

    }
}
