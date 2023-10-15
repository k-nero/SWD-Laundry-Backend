using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Controllers;

[ApiController]
public class PaypalController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePayment()
    {
        return Ok();
    }

}
