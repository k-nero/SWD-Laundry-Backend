﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Controllers;

//[Authorize(Roles = "Admin, Staff")]
[ApiController]
public class BuildingsController : ApiControllerBase
{
    private readonly IBuidingService _buildingService;

    public BuildingsController(IBuidingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get([FromQuery] BuildingQuery query)
    {
        try
        {
            var pgresult = await _buildingService.GetPaginatedAsync(query);
            return Ok(new BaseResponseModel<PaginatedList<Building>?>(StatusCodes.Status200OK, data: pgresult));
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
    public async Task<IActionResult> GetById([FromRoute] string id)
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
    public async Task<IActionResult> Create([FromBody] BuildingModel model)
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
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] BuildingModel model)
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
    public async Task<IActionResult> Delete([FromRoute] string id)
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
