using BookManagement.Services.Notification.Api.Services.Abstract;
using BookManagement.Shared;
using Microsoft.Extensions.Options;

namespace BookManagement.Services.Notification.Api.Services
{
    public class PersonService : IPersonService
    {

        private readonly HttpClient _client;
        private readonly Settings serviceSettings;

        public PersonService(HttpClient client, IOptionsSnapshot<Settings> serviceOptions)
        {
            _client = client;
            serviceSettings = serviceOptions.Value;
            _client.BaseAddress = new Uri(serviceSettings.PersonApiUrl);
        }

        public async Task<string> GetReportData()
        {
            var response = await _client.GetAsync($"api/Person/getReportData");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }
    }
}
