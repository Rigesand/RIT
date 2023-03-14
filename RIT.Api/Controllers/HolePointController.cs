using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIT.Api.Dtos.HolePoints;
using RIT.Api.Services;
using RIT.Data.Entities;

namespace RIT.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HolePointController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly HolePointService _holePointService;

    public HolePointController(IMapper mapper, HolePointService holePointService)
    {
        _mapper = mapper;
        _holePointService = holePointService;
    }

    /// <summary>
    /// Endpoint создания HolePoint
    /// </summary>
    /// <param name="createHolePoint"></param>
    [HttpPost]
    public async Task CreateHolePoint(CreateHolePoint createHolePoint)
    {
        var holePoint = _mapper.Map<HolePoints>(createHolePoint);
        await _holePointService.CreateHolePoint(holePoint);
    }

    /// <summary>
    /// Endpoint получения HolePoint по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetHolePoint> GetHolePoint(Guid id)
    {
        var hole = await _holePointService.GetHolePoint(id);
        return _mapper.Map<GetHolePoint>(hole);
    }

    /// <summary>
    /// Endpoint изменения HolePoint по Id
    /// </summary>
    /// <param name="updateHolePoint"></param>
    [HttpPut]
    public async Task UpdateHolePoint(UpdateHolePoint updateHolePoint)
    {
        var holePoint = _mapper.Map<HolePoints>(updateHolePoint);
        await _holePointService.UpdateHolePoint(holePoint);
    }

    /// <summary>
    /// Endpoint удаления HolePoint по Id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    public async Task DeleteHolePoint(Guid id)
    {
        await _holePointService.DeleteHolePoint(id);
    }
}