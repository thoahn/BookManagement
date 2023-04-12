namespace BookManagement.Web.Services.Abstract
{
    public interface IReportService
    {
        Task<string> GetList();

        Task<string> SaveReport();

        Task<string> GetReportData(Guid id);

    }
}
