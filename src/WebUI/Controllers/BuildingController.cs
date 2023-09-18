using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Application.Buildings.Commands.CreateBuilding;
using SWD_Laundry_Backend.Application.Buildings.Commands.DeleteBuilding;
using SWD_Laundry_Backend.Application.Buildings.Commands.UpdateBuilding;
using SWD_Laundry_Backend.Application.Buildings.Queries;
using SWD_Laundry_Backend.WebUI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[ApiController]
public class BuildingController : ApiControllerBase
{
    // GET: api/<BuildingController>
    [HttpGet]
    public async Task<ActionResult<List<BuildingViewModel>>> Get()
    {
        return await Mediator.Send(new GetAllBuildingQuery()); 
    }

    // GET api/<BuildingController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BuildingViewModel>> Get(int id)
    {
        return await Mediator.Send(new GetBuildingQuery { Id = id });
    }

    // POST api/<BuildingController>
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreateBuildingCommand command)
    {
        return await Mediator.Send(command);
    }

    // PUT api/<BuildingController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Put([FromBody] UpdateBuildingCommand command)
    {
        return await Mediator.Send(command);
    }

    // DELETE api/<BuildingController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Delete(int id)
    {
        return await Mediator.Send(new DeleteBuildingCommand { Id = id });
    }
}
