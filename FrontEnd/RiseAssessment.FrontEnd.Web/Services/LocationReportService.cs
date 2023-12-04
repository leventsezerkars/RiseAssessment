using RiseAssessment.Core.Dtos;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Services
{
    public class LocationReportService : ILocationReportService
    {
        public LocationReportService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<bool> CreateAsync()
        {
            var response = await Client.PostAsJsonAsync<LocationReportDto>("LocationReport", new LocationReportDto() { });

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"LocationReport/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<LocationReportDto>> GetAllAsync()
        {
            var response = await Client.GetAsync("LocationReport");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<LocationReportDto>>>();

            return responseSuccess.Data;
        }

        public async Task<LocationReportDto> GetById(string id)
        {
            var response = await Client.GetAsync($"LocationReport/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<LocationReportDto>>();

            return responseSuccess.Data;
        }

    }
}
