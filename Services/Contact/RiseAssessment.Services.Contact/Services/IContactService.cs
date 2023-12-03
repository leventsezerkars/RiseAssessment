using RiseAssessment.Core.Dtos;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Contact.Dtos;

namespace RiseAssessment.Services.Contact.Services
{
    public interface IContactService
    {
        Task<Response<List<ContactDto>>> GetAllAsync();

        Task<Response<ContactDto>> CreateAsync(ContactDto personDto);

        Task<Response<ContactDto>> UpdateAsync(ContactDto personDto);

        Task<Response<ContactDto>> GetByIdAsync(string id);

        Task<Response<ContactDto>> DeleteAsync(string id);
        Task<Response<List<ReportDetail>>> GetLocationReportDatas();
    }
}