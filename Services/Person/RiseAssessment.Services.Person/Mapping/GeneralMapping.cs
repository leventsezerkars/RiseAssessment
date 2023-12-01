using AutoMapper;
using RiseAssessment.Services.Person.Dtos;
using RiseAssessment.Services.Person.Models;

namespace RiseAssessment.Services.Person.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Person, PersonDto>().ReverseMap();
        }
    }
}