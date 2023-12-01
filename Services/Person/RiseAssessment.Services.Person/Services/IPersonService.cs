using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Person.Dtos;

namespace RiseAssessment.Services.Person.Services
{
    public interface IPersonService
    {
        Task<Response<List<PersonDto>>> GetAllAsync();

        Task<Response<PersonDto>> CreateAsync(PersonDto category);

        Task<Response<PersonDto>> GetByIdAsync(Guid id);
    }
}