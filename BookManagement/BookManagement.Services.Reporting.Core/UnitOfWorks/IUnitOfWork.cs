using BookManagement.Services.Reporting.Core.Repositories;

namespace BookManagement.Services.Reporting.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IReportsRepository Report { get; }

        Task CommitAsync();

        void Commit();
    }
}
