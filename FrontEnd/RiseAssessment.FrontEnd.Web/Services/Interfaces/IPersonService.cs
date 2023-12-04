using RiseAssessment.FrontEnd.Web.Models;

namespace RiseAssessment.FrontEnd.Web.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllAsync();

        Task<PersonDto> GetById(string id);

        Task<bool> CreateAsync(PersonDto model);

        Task<bool> UpdateAsync(PersonDto model);

        Task<bool> DeleteAsync(string id);
    }
}
