using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Report.Dtos;

namespace RiseAssessment.Services.Report.Services
{
    public interface ILocationReportDetailService
    {
        Task<Response<List<LocationReportDetailDto>>> GetAllAsync();

        Task<Response<LocationReportDetailDto>> CreateAsync(LocationReportDetailDto personDto);

        Task<Response<LocationReportDetailDto>> UpdateAsync(LocationReportDetailDto personDto);

        Task<Response<LocationReportDetailDto>> GetByIdAsync(string id);

        Task<Response<LocationReportDetailDto>> DeleteAsync(string id);
    }
}