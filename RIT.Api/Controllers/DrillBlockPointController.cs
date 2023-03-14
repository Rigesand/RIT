using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIT.Api.Dtos.DrillBlockPoints;
using RIT.Api.Services;
using RIT.Data.Entities;

namespace RIT.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DrillBlockPointController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly DrillBlockPointService _drillBlockPointService;

    public DrillBlockPointController(IMapper mapper, DrillBlockPointService drillBlockPointService)
    {
        _mapper = mapper;
        _drillBlockPointService = drillBlockPointService;
    }

    /// <summary>
    /// Endpoint создания drillBlockPoint
    /// </summary>
    /// <param name="createDrillBlockPoint"></param>
    [HttpPost]
    public async Task CreateDrillBlockPoint(CreateDrillBlockPoint createDrillBlockPoint)
    {
        var drillBlockPoint = _mapper.Map<DrillBlockPoints>(createDrillBlockPoint);
        await _drillBlockPointService.CreateDrillBlockPoint(drillBlockPoint);
    }

    /// <summary>
    /// Endpoint получения drillBlockPoint по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetDrillBlockPoint> GetDrillBlockPoint(Guid id)
    {
        var drillBlockPoint = await _drillBlockPointService.GetDrillBlockPoint(id);
        return _mapper.Map<GetDrillBlockPoint>(drillBlockPoint);
    }

    /// <summary>
    /// Endpoint изменения drillBlockPoint по Id
    /// </summary>
    /// <param name="updateDrillBlockPoint"></param>
    [HttpPut]
    public async Task UpdateDrillBlockPoint(UpdateDrillBlockPoint updateDrillBlockPoint)
    {
        var drillBlockPoints = _mapper.Map<DrillBlockPoints>(updateDrillBlockPoint);
        await _drillBlockPointService.UpdateDrillBlockPoint(drillBlockPoints);
    }

    /// <summary>
    /// Endpoint удаления drillBlockPoint по Id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    public async Task DeleteDrillBlockPoint(Guid id)
    {
        await _drillBlockPointService.DeleteDrillBlock(id);
    }
}