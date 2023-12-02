using AutoMapper;
using RiseAssessment.Services.Contact.Dtos;

namespace RiseAssessment.Services.Contact.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Contact, ContactDto>().ReverseMap();
        }
    }
}