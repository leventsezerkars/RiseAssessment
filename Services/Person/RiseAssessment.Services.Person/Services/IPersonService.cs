using RiseAssessment.Core.Dtos;
using RiseAssessment.Services.Person.Dtos;

namespace RiseAssessment.Services.Person.Services
{
    public interface IPersonService
    {
        Task<Response<List<PersonDto>>> GetAllAsync();

        Task<Response<PersonDto>> CreateAsync(PersonDto personDto);

        Task<Response<PersonDto>> UpdateAsync(PersonDto personDto);

        Task<Response<PersonDto>> GetByIdAsync(string id);

        Task<Response<PersonDto>> DeleteAsync(string id);
    }
}