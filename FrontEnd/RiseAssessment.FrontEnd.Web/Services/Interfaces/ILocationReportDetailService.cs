using RiseAssessment.FrontEnd.Web.Models;

namespace RiseAssessment.FrontEnd.Web.Services.Interfaces
{
    public interface ILocationReportDetailService
    {
        Task<List<LocationReportDetailDto>> GetAllAsync();
        Task<List<LocationReportDetailDto>> GetAllByReportIdAsync(string id);
        Task<LocationReportDetailDto> GetById(string id);

        Task<bool> CreateAsync(LocationReportDetailDto model);

        Task<bool> UpdateAsync(LocationReportDetailDto model);

        Task<bool> DeleteAsync(string id);
    }
}
