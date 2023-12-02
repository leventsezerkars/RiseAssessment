using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Core.ControllerBases;
using RiseAssessment.Services.Person.Dtos;
using RiseAssessment.Services.Person.Services;

namespace RiseAssessment.Services.Person.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : CustomBaseController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();

            return CreateActionResultInstance(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var person = await _personService.GetByIdAsync(id);

            return CreateActionResultInstance(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDto personDto)
        {
            var response = await _personService.CreateAsync(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _personService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}