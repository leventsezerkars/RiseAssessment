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
            var response = await Client.PostAsJsonAsync<LocationReportDetailDto>("LocationReportDetail", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"LocationReportDetail/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<LocationReportDetailDto>> GetAllAsync()
        {
            var response = await Client.GetAsync("LocationReportDetail");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<LocationReportDetailDto>>>();

            return responseSuccess.Data;
        }
        public async Task<List<LocationReportDetailDto>> GetAllByReportIdAsync(string id)
        {
            var response = await Client.GetAsync($"LocationReportDetail/report/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<LocationReportDetailDto>>>();

            return responseSuccess.Data;
        }
        
        public async Task<LocationReportDetailDto> GetById(string id)
        {
            var response = await Client.GetAsync($"LocationReportDetail/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<LocationReportDetailDto>>();

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateAsync(LocationReportDetailDto model)
        {
            var response = await Client.PutAsJsonAsync<LocationReportDetailDto>("LocationReportDetail", model);

            return response.IsSuccessStatusCode;
        }
    }
}
