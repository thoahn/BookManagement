using Microsoft.AspNetCore.SignalR;

namespace BookManagement.Web.Hubs
{
    public class ReportHub : Hub
    {
        public async Task SendReportReadyMessage(Guid reportId)
        {
            await Clients.All.SendAsync("reportCreated", reportId.ToString());
        }
    }
}
