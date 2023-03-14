using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIT.Api.Dtos.DrillBlocks;
using RIT.Api.Services;
using RIT.Data.Entities;

namespace RIT.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DrillBlockController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly DrillBlockService _drillBlockService;

    public DrillBlockController(IMapper mapper, DrillBlockService drillBlockService)
    {
        _mapper = mapper;
        _drillBlockService = drillBlockService;
    }

    /// <summary>
    /// Endpoint создания DrillBlock
    /// </summary>
    /// <param name="createDrillBlock"></param>
    [HttpPost]
    public async Task CreateDrillBlock(CreateDrillBlock createDrillBlock)
    {
        var dataDrillblock = _mapper.Map<DrillBlock>(createDrillBlock);
        await _drillBlockService.CreateDrillBlock(dataDrillblock);
    }

    /// <summary>
    /// Endpoint получения DrillBlock по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetDrillBlock> GetDrillBlock(Guid id)
    {
        var drillblock = await _drillBlockService.GetDrillBlock(id);
        return _mapper.Map<GetDrillBlock>(drillblock);
    }

    /// <summary>
    /// Endpoint изменения DrillBlock по Id
    /// </summary>
    /// <param name="updateCreateDrillBlock"></param>
    [HttpPut]
    public async Task UpdateDrillBlock(UpdateDrillBlock updateCreateDrillBlock)
    {
        var drillblock = _mapper.Map<DrillBlock>(updateCreateDrillBlock);
        await _drillBlockService.UpdateDrillBlock(drillblock);
    }

    /// <summary>
    /// Endpoint удаления DrillBlock по Id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    public async Task DeleteDrillBlock(Guid id)
    {
        await _drillBlockService.DeleteDrillBlock(id);
    }
}