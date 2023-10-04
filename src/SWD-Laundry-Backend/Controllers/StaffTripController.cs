﻿using Microsoft.AspNetCore.Mvc;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Controllers;

[ApiController]
public class StaffTripController : ApiControllerBase
{
    private readonly IStaffTripService _service;

    public StaffTripController(IStaffTripService service)
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
            return Ok(new BaseResponseModel<ICollection<Staff_Trip>?>(StatusCodes.Status200OK, data: result));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponseModel<string>(StatusCodes.Status500InternalServerError, e.Message));
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new BaseResponseModel<string>(StatusCodes.Status404NotFound, "Not Found"));
            }
            return Ok(new BaseResponseModel<Staff_Trip?>(StatusCodes.Status200OK, data: result));
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
    public async Task<IActionResult> Create(StaffTripModel model)
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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(string id, StaffTripModel model)
    {
        try
        {
            var result = await _service.UpdateAsync(id, model);
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