using BookManagement.Shared;
using BookManagement.Web.Models;
using BookManagement.Web.Services.Abstract;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace BookManagement.Web.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _client;
        private readonly Settings serviceSettings;


        public PersonService(HttpClient client, IOptionsSnapshot<Settings> serviceOptions)
        {
            serviceSettings = serviceOptions.Value;
            _client = client;
            _client.BaseAddress = new Uri(serviceSettings.PersonApiUrl);
        }

        public async Task<string> GetContactTypes()
        {
            var response = await _client.GetAsync("api/PersonContact/getContactTypes");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> GetPerson()
        {
            var response = await _client.GetAsync("​getall");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> GetPersonContactsByPersonId(Guid id)
        {
            var response = await _client.GetAsync($"api/PersonContact/getAllByPersonId/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> GetPersonList()
        {
            var response = await _client.GetAsync("api/Person/getall/");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> SavePerson(PersonDto model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/Person/savePerson/", data);

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> DeletePerson(Guid id)
        {
            var response = await _client.DeleteAsync($"api/Person/deletePerson/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            return "{'success': 'Başarılı'}";
        }

        public async Task<string> SavePersonContact(PersonContactDto model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/PersonContact/savePersonContact/", data);

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> DeletePersonContact(Guid id)
        {
            var response = await _client.DeleteAsync($"api/PersonContact/deletePersonContact/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            return "{'success': 'Başarılı'}";
        }
    }
}
