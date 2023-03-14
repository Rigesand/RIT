using Microsoft.EntityFrameworkCore;
using RIT.Data;
using RIT.Data.Entities;

namespace RIT.Api.Services;

public class DrillBlockService
{
    private readonly AppDbContext _context;

    public DrillBlockService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateDrillBlock(DrillBlock drillBlock)
    {
        var isExist = await _context.DrillBlocks.AnyAsync(it => it.Name == drillBlock.Name);
        if (isExist)
        {
            throw new Exception("DrillBlock already exists");
        }

        await _context.DrillBlocks.AddAsync(drillBlock);
        await _context.SaveChangesAsync();
    }

    public async Task<DrillBlock> GetDrillBlock(Guid id)
    {
        var drillBlock = await _context.DrillBlocks.AsNoTracking().FirstOrDefaultAsync(it => it.Id == id);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        return drillBlock;
    }

    public async Task UpdateDrillBlock(DrillBlock updateDrillblock)
    {
        var drillBlock = await _context.DrillBlocks.FirstOrDefaultAsync(it => it.Id == updateDrillblock.Id);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        drillBlock.Name = updateDrillblock.Name;
        drillBlock.UpdateDate = updateDrillblock.UpdateDate;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDrillBlock(Guid id)
    {
        var drillBlock = await _context.DrillBlocks.FirstOrDefaultAsync(it => it.Id == id);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        _context.Remove(drillBlock);
        await _context.SaveChangesAsync();
    }
}