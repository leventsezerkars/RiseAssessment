using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Core.ControllerBases;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Services;

namespace RiseAssessment.Services.Person.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationReportController : CustomBaseController
    {
        private readonly ILocationReportService _locationReportService;

        public LocationReportController(ILocationReportService locationReportService)
        {
            _locationReportService = locationReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _locationReportService.GetAllAsync();

            return CreateActionResultInstance(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var person = await _locationReportService.GetByIdAsync(id);

            return CreateActionResultInstance(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var model = new LocationReportDto() { };
            var response = await _locationReportService.CreateAsync(model);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _locationReportService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}