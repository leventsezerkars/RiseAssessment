using AutoMapper;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Models;

namespace RiseAssessment.Services.Report.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<LocationReport, LocationReportDto>().ReverseMap();
            CreateMap<LocationReportDetail, LocationReportDetailDto>().ReverseMap();
        }
    }
}