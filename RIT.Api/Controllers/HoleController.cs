using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIT.Api.Dtos.Holes;
using RIT.Api.Services;
using RIT.Data.Entities;

namespace RIT.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly HoleService _holeService;

    public HoleController(IMapper mapper, HoleService holeService)
    {
        _mapper = mapper;
        _holeService = holeService;
    }

    /// <summary>
    /// Endpoint создания Hole
    /// </summary>
    /// <param name="createHole"></param>
    [HttpPost]
    public async Task CreateHole(CreateHole createHole)
    {
        var hole = _mapper.Map<Hole>(createHole);
        await _holeService.CreateHole(hole);
    }

    /// <summary>
    /// Endpoint получения Hole по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetHole> GetHole(Guid id)
    {
        var hole = await _holeService.GetHole(id);
        return _mapper.Map<GetHole>(hole);
    }

    /// <summary>
    /// Endpoint изменения Hole по Id
    /// </summary>
    /// <param name="updateHole"></param>
    [HttpPut]
    public async Task UpdateHole(UpdateHole updateHole)
    {
        var hole = _mapper.Map<Hole>(updateHole);
        await _holeService.UpdateHole(hole);
    }

    /// <summary>
    /// Endpoint удаления Hole по Id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    public async Task DeleteHole(Guid id)
    {
        await _holeService.DeleteHole(id);
    }
}