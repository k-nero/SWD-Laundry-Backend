using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Application.Wallets.Commands.CreateWallet;
using SWD_Laundry_Backend.Application.Wallets.Commands.DeleteWallet;
using SWD_Laundry_Backend.Application.Wallets.Commands.UpdateWallet;
using SWD_Laundry_Backend.Application.Wallets.Queries;
using SWD_Laundry_Backend.WebUI.Controllers;

namespace WebUI.Controllers;

public class WalletController : ApiControllerBase
{
    // GET: api/<WalletController>
    [HttpGet]
    public async Task<ActionResult<List<WalletViewModel>>> Get()
    {
        return await Mediator.Send(new GetAllWalletQuery());
    }

    // GET api/<WalletController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WalletViewModel>> Get(int id)
    {
        return await Mediator.Send(new GetWalletQuery { Id = id });
    }

    // POST api/<WalletController>
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreateWalletCommand command)
    {
        return await Mediator.Send(command);
    }

    // PUT api/<WalletController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Put([FromBody] UpdateWalletCommand command)
    {
        return await Mediator.Send(command);
    }

    // DELETE api/<WalletController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Delete(int id)
    {
        return await Mediator.Send(new DeleteWalletCommand { Id = id });
    }
}
