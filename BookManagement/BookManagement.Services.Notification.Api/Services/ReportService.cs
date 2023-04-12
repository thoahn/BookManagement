using BookManagement.Services.Notification.Api.Services.Abstract;
using BookManagement.Shared;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;

namespace BookManagement.Services.Notification.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _client;
        private readonly Settings serviceSettings;
        HubConnection connection;

        public ReportService(HttpClient client, IOptionsSnapshot<Settings> serviceOptions)
        {
            serviceSettings = serviceOptions.Value;
            _client = client;
            _client.BaseAddress = new Uri(serviceSettings.ReportApiUrl);
            connection = new HubConnectionBuilder()
                .WithUrl($"{serviceSettings.SignalRHub}/reportHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        public async Task<string> SaveReportData(Guid reportId, string data)
        {

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("value", data),
                new KeyValuePair<string, string>("id", reportId.ToString())
            });

            var response = await _client.PostAsync($"api/Report/saveReportData", content);

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task SendSignalRMessage(Guid id)
        {
            await connection.StartAsync();
            await connection.InvokeAsync("SendReportReadyMessage", id.ToString());
        }
    }
}
