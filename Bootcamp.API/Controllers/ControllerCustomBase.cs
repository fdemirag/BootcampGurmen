using Bootcamp.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerCustomBase : ControllerBase
{
    [NonAction] 
    public IActionResult CreateActionResult<T>(ResponseDto<T> response)
    {

        if (response.StatusCode == 204)
        {
            return new ObjectResult(null) { StatusCode = response.StatusCode }; 
        }
        return new ObjectResult(response) { StatusCode = response.StatusCode };
  
    }

}