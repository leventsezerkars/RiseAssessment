using RiseAssessment.FrontEnd.Web.Models;

namespace RiseAssessment.FrontEnd.Web.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAllAsync();
        Task<List<ContactDto>> GetContactByPersonAsync(string id);
        Task<ContactDto> GetById(string id);

        Task<bool> CreateAsync(ContactDto model);

        Task<bool> UpdateAsync(ContactDto model);

        Task<bool> DeleteAsync(string id);
    }
}
