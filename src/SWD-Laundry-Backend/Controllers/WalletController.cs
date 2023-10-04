using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Controllers;

[ApiController]
public class WalletController : ApiControllerBase
{
    private readonly IWalletService _service;

    public WalletController(IWalletService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<Wallet>?>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }
}
