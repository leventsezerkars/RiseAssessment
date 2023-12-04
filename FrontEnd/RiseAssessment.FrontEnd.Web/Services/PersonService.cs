using RiseAssessment.Core.Dtos;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Services
{
    public class PersonService : IPersonService
    {

        public PersonService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<bool> CreateAsync(PersonDto model)
        {
            var response = await Client.PostAsJsonAsync<PersonDto>("persons", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"persons/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var response = await Client.GetAsync("persons");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<PersonDto>>>();

            return responseSuccess.Data;
        }

        public async Task<PersonDto> GetById(string id)
        {
            var response = await Client.GetAsync($"persons/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<PersonDto>>();

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateAsync(PersonDto model)
        {
            var response = await Client.PutAsJsonAsync<PersonDto>("persons", model);

            return response.IsSuccessStatusCode;
        }
    }
}
