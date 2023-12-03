using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Core.ControllerBases;
using RiseAssessment.Services.Report.Dtos;
using RiseAssessment.Services.Report.Services;

namespace RiseAssessment.Services.Person.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationReportDetailController : CustomBaseController
    {
        private readonly ILocationReportDetailService _LocationReportDetailService;

        public LocationReportDetailController(ILocationReportDetailService LocationReportDetailService)
        {
            _LocationReportDetailService = LocationReportDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _LocationReportDetailService.GetAllAsync();

            return CreateActionResultInstance(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var person = await _LocationReportDetailService.GetByIdAsync(id);

            return CreateActionResultInstance(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationReportDetailDto personDto)
        {
            var response = await _LocationReportDetailService.CreateAsync(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(LocationReportDetailDto personDto)
        {
            var response = await _LocationReportDetailService.UpdateAsync(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _LocationReportDetailService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}