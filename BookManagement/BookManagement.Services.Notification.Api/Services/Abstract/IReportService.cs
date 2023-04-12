namespace BookManagement.Services.Notification.Api.Services.Abstract
{
    public interface IReportService
    {
        Task<string> SaveReportData(Guid reportId, string data);
        Task SendSignalRMessage(Guid id);
    }
}
