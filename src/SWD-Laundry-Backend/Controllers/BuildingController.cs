using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Controllers;
[ApiController]
public class BuildingController : ApiControllerBase
{
    private readonly IBuidingService _buildingService;

    public BuildingController(IBuidingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        var result = await _buildingService.GetAllAsync();
        return Ok(new BaseResponseModel<ICollection<Building>?>(StatusCodes.Status200OK, data: result));
    }

}
