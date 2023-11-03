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
    public class TeamController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public TeamController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TeamDto>>> Get()
    {
        var team = await unitofwork.Teams.GetAllAsync();
        return mapper.Map<List<TeamDto>>(team);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeamDto>> Get(int id)
    {
        var team = await unitofwork.Teams.GetByIdAsync(id);
        if (team == null){
            return NotFound();
        }
        return this.mapper.Map<TeamDto>(team);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Team>> Post(TeamDto teamDto)
    {
        var team = this.mapper.Map<Team>(teamDto);
        this.unitofwork.Teams.Add(team);
        await unitofwork.SaveAsync();
        if(team == null)
        {
            return BadRequest();
        }
        teamDto.Id = team.Id;
        return CreatedAtAction(nameof(Post), new {id = teamDto.Id}, teamDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TeamDto>> Put(int id, [FromBody]TeamDto teamDto){
        if(teamDto == null)
        {
            return NotFound();
        }
        var team = this.mapper.Map<Team>(teamDto);
        unitofwork.Teams.Update(team);
        await unitofwork.SaveAsync();
        return teamDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var team = await unitofwork.Teams.GetByIdAsync(id);
        if(team == null)
        {
            return NotFound();
        }
        unitofwork.Teams.Remove(team);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}