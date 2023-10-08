using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WalletController : ApiControllerBase
{
    private readonly IWalletService _service;
    private readonly ITransactionService _service2;

    public WalletController(IWalletService service, ITransactionService service2)
    {
        _service = service;
        _service2 = service2;
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

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        try
        {
            var result = await _service.GetByIdAsync(userId);
            if (result == null)
            {
                return NotFound(new BaseResponseModel<string>(StatusCodes.Status404NotFound, "Not Found"));
            }
            return Ok(new BaseResponseModel<Wallet?>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(WalletModel model)
    {
        try
        {
            var result = await _service.CreateAsync(model);
            return Ok(new BaseResponseModel<string>
                (StatusCodes.Status201Created, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>
                (StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpPut("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DepositWallet(string userId, WalletModel model)
    {
        try
        {
            var result = await _service.UpdateAsync(userId, model);
            if (result == 0)
            {
                return NotFound(new BaseResponseModel<string>(StatusCodes.Status404NotFound, "Not Found"));
            }

            var result2 = await _service2.CreateAsync(new TransactionModel()
            {
                WalletID = userId,
                TransactionType = AllowedTransactionType.Deposit,
                PaymentType = PaymentType.Paypal,
                Amount = model.Balance,
                Description = $"Deposit: {model.Balance} into WalletId: {userId}",
                PaymentID = null
            }); 

            return Ok(new BaseResponseModel<int>(StatusCodes.Status200OK, data: result, additionalData: result2));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound(new BaseResponseModel<string>(StatusCodes.Status404NotFound, "Not Found"));
            }
            return Ok(new BaseResponseModel<int>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }
}