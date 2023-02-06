using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.DTO.DTOs;

namespace NTierArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCodes == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCodes };

            return new ObjectResult(response) { StatusCode = response.StatusCodes };
        }
    }
}
