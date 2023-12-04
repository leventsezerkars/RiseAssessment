using RiseAssessment.FrontEnd.Web.Models;

namespace RiseAssessment.FrontEnd.Web.Services.Interfaces
{
    public interface ILocationReportService
    {
        Task<List<LocationReportDto>> GetAllAsync();

        Task<LocationReportDto> GetById(string id);

        Task<bool> CreateAsync();

        Task<bool> DeleteAsync(string id);
    }
}
