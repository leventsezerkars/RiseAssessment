using AutoMapper;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Models;

namespace RiseAssessment.Services.Report.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<LocationReportDto, LocationReportDto>().ReverseMap();
            CreateMap<LocationReportDetailDto, LocationReportDto>().ReverseMap();
        }
    }
}