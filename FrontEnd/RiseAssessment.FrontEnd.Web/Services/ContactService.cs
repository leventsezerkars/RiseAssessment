using RiseAssessment.Core.Dtos;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Services
{
    public class ContactService : IContactService
    {
        public ContactService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<bool> CreateAsync(ContactDto model)
        {
            var response = await Client.PostAsJsonAsync<ContactDto>("Contacts", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"Contacts/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<ContactDto>> GetAllAsync()
        {
            var response = await Client.GetAsync("Contacts");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ContactDto>>>();

            return responseSuccess.Data;
        }

        public async Task<List<ContactDto>> GetContactByPersonAsync(string id)
        {
            var response = await Client.GetAsync($"Contacts/person/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ContactDto>>>();

            return responseSuccess.Data;
        }

        public async Task<ContactDto> GetById(string id)
        {
            var response = await Client.GetAsync($"Contacts/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ContactDto>>();

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateAsync(ContactDto model)
        {
            var response = await Client.PutAsJsonAsync<ContactDto>("Contacts", model);

            return response.IsSuccessStatusCode;
        }
    }
}
