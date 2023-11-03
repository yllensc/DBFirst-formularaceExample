using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class DriverController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public DriverController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DriverDto>>> Get()
    {
        var driver = await unitofwork.Drivers.GetAllAsync();
        return mapper.Map<List<DriverDto>>(driver);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DriverDto>> Get(int id)
    {
        var driver = await unitofwork.Drivers.GetByIdAsync(id);
        if (driver == null){
            return NotFound();
        }
        return this.mapper.Map<DriverDto>(driver);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Driver>> Post(DriverDto driverDto)
    {
        var driver = this.mapper.Map<Driver>(driverDto);
        this.unitofwork.Drivers.Add(driver);
        await unitofwork.SaveAsync();
        if(driver == null)
        {
            return BadRequest();
        }
        driverDto.Id = driver.Id;
        return CreatedAtAction(nameof(Post), new {id = driverDto.Id}, driverDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DriverDto>> Put(int id, [FromBody]DriverDto driverDto){
        if(driverDto == null)
        {
            return NotFound();
        }
        var driver = this.mapper.Map<Driver>(driverDto);
        unitofwork.Drivers.Update(driver);
        await unitofwork.SaveAsync();
        return driverDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var driver = await unitofwork.Drivers.GetByIdAsync(id);
        if(driver == null)
        {
            return NotFound();
        }
        unitofwork.Drivers.Remove(driver);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}