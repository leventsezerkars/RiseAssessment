using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Report.Dtos;

namespace RiseAssessment.Services.Report.Services
{
    public interface ILocationReportService
    {
        Task<Response<List<LocationReportDto>>> GetAllAsync();

        Task<Response<LocationReportDto>> CreateAsync(LocationReportDto personDto);
        Task<Response<LocationReportDto>> UpdateAsync(LocationReportDto dataDto);
        Task<Response<LocationReportDto>> GetByIdAsync(string id);

        Task<Response<LocationReportDto>> DeleteAsync(string id);
    }
}