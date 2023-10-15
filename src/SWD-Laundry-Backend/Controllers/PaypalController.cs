using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.ValueObject;
using static SWD_Laundry_Backend.Core.ValueObject.PaypalApiObjectModel.PaypalOrder;

namespace SWD_Laundry_Backend.Controllers;

[ApiController]
public class PaypalController : ApiControllerBase
{
    private readonly IPaypalService _paypalService;

    public PaypalController(IPaypalService paypalService)
    {
        _paypalService = paypalService;
    }

    [HttpPost("/deposite-wallet")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreatePayment(TransactionModel model)
    {
        try
        {
            var result = await _paypalService.CreatePaypalOrderAsync(model);
            return Ok(new BaseResponseModel<PaypalOrderResponse>(StatusCodes.Status201Created, result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpGet("/capture-paypal-order/{orderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CapturePaypalOrder(string orderId)
    {
        try
        {
            var result = await _paypalService.CapturePaypalOrderAsync(orderId);
            return Ok(new BaseResponseModel<object?>(StatusCodes.Status200OK, result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

}
