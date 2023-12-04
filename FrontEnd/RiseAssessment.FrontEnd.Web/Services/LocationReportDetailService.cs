using RiseAssessment.Core.Dtos;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Services
{
    public class LocationReportDetailService : ILocationReportDetailService
    {
        public LocationReportDetailService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<bool> CreateAsync(LocationReportDetailDto model)
        {
            var response = await Client.PostAsJsonAsync<LocationReportDetailDto>("LocationReportDetails", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"LocationReportDetails/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<LocationReportDetailDto>> GetAllAsync()
        {
            var response = await Client.GetAsync("LocationReportDetails");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<LocationReportDetailDto>>>();

            return responseSuccess.Data;
        }

        public async Task<LocationReportDetailDto> GetById(string id)
        {
            var response = await Client.GetAsync($"LocationReportDetails/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<LocationReportDetailDto>>();

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateAsync(LocationReportDetailDto model)
        {
            var response = await Client.PutAsJsonAsync<LocationReportDetailDto>("courses", model);

            return response.IsSuccessStatusCode;
        }
    }
}
