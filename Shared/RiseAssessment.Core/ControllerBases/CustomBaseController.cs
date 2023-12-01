using Microsoft.AspNetCore.Mvc;
using RiseAssessment.Core.Dtos;

namespace RiseAssessment.Core.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}