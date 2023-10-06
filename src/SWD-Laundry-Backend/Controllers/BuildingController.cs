using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Controllers;

[Authorize(Roles = "Admin, Staff")]
[ApiController]
public class BuildingController : ApiControllerBase
{
    private readonly IBuidingService _buildingService;

    public BuildingController(IBuidingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _buildingService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<Building>?>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var result = await _buildingService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new BaseResponseModel<string>(StatusCodes.Status404NotFound, "Not Found"));
            }
            return Ok(new BaseResponseModel<Building?>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(BuildingModel model)
    {
        try
        {
            var result = await _buildingService.CreateAsync(model);
            return Ok(new BaseResponseModel<string>(StatusCodes.Status201Created, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(string id, BuildingModel model)
    {
        try
        {
            var result = await _buildingService.UpdateAsync(id, model);
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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var result = await _buildingService.DeleteAsync(id);
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