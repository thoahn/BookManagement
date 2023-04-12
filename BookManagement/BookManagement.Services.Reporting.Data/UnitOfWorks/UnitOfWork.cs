using BookManagement.Services.Reporting.Core.Repositories;
using BookManagement.Services.Reporting.Core.UnitOfWorks;
using PhoneBook.Services.Report.Data.Repositories.EntityFramework;

namespace BookManagement.Services.Reporting.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookManagementReportDbContext _context;

        private ReportsRepository _reportsRepository;

        public IReportsRepository Report => _reportsRepository = _reportsRepository ?? new ReportsRepository(_context);

        public UnitOfWork(BookManagementReportDbContext appDbContext)
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
