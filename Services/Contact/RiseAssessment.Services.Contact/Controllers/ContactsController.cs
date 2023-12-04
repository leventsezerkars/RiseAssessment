using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Core.ControllerBases;
using RiseAssessment.Services.Contact.Dtos;
using RiseAssessment.Services.Contact.Services;

namespace RiseAssessment.Services.Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : CustomBaseController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService personService)
        {
            _contactService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _contactService.GetAllAsync();

            return CreateActionResultInstance(datas);
        }

        [HttpGet("person/{id}")]
        public async Task<IActionResult> GetContactByPerson(string id)
        {
            var datas = await _contactService.GetContactByPersonAsync(id);

            return CreateActionResultInstance(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _contactService.GetByIdAsync(id);

            return CreateActionResultInstance(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDto personDto)
        {
            var response = await _contactService.CreateAsync(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _contactService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}