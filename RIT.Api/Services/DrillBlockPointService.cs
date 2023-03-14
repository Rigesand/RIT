using Microsoft.EntityFrameworkCore;
using RIT.Data;
using RIT.Data.Entities;

namespace RIT.Api.Services;

public class DrillBlockPointService
{
    private readonly AppDbContext _context;

    public DrillBlockPointService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateDrillBlockPoint(DrillBlockPoints drillBlockPoint)
    {
        var drillBlock = await _context.DrillBlocks.FirstOrDefaultAsync(it => it.Id == drillBlockPoint.DrillBlockId);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        drillBlockPoint.DrillBlock = drillBlock;
        await _context.DrillBlockPoints.AddAsync(drillBlockPoint);
        await _context.SaveChangesAsync();
    }

    public async Task<DrillBlockPoints> GetDrillBlockPoint(Guid id)
    {
        var drillBlockPoint = await _context.DrillBlockPoints.AsNoTracking().FirstOrDefaultAsync(it => it.Id == id);
        if (drillBlockPoint == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        return drillBlockPoint;
    }

    public async Task UpdateDrillBlockPoint(DrillBlockPoints updateDrillblockPoint)
    {
        var drillBlock = await _context.DrillBlockPoints.FirstOrDefaultAsync(it => it.Id == updateDrillblockPoint.Id);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlockPoint does not exist");
        }

        drillBlock.Sequence = updateDrillblockPoint.Sequence;
        drillBlock.X = updateDrillblockPoint.X;
        drillBlock.Y = updateDrillblockPoint.Y;
        drillBlock.Z = updateDrillblockPoint.Z;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDrillBlock(Guid id)
    {
        var drillBlockPoint = await _context.DrillBlockPoints.FirstOrDefaultAsync(it => it.Id == id);
        if (drillBlockPoint == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        _context.Remove(drillBlockPoint);
        await _context.SaveChangesAsync();
    }
}