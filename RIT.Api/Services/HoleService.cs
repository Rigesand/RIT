using Microsoft.EntityFrameworkCore;
using RIT.Data;
using RIT.Data.Entities;

namespace RIT.Api.Services;

public class HoleService
{
    private readonly AppDbContext _context;

    public HoleService(AppDbContext context)
    {
        _context = context;
    }


    public async Task CreateHole(Hole hole)
    {
        var isExist = await _context.Holes.AnyAsync(it => it.Name == hole.Name);
        if (isExist)
        {
            throw new Exception("Hole already exists");
        }

        var drillBlock = await _context.DrillBlocks.FirstOrDefaultAsync(it => it.Id == hole.DrillBlockId);
        if (drillBlock == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        hole.DrillBlock = drillBlock;

        await _context.Holes.AddAsync(hole);
        await _context.SaveChangesAsync();
    }

    public async Task<Hole> GetHole(Guid id)
    {
        var hole = await _context.Holes.AsNoTracking().FirstOrDefaultAsync(it => it.Id == id);
        if (hole == null)
        {
            throw new Exception("Hole does not exist");
        }

        return hole;
    }

    public async Task UpdateHole(Hole updateHole)
    {
        var hole = await _context.Holes.FirstOrDefaultAsync(it => it.Id == updateHole.Id);
        if (hole == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        hole.Name = updateHole.Name;
        hole.Depth = updateHole.Depth;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHole(Guid id)
    {
        var hole = await _context.Holes.FirstOrDefaultAsync(it => it.Id == id);
        if (hole == null)
        {
            throw new Exception("Hole does not exist");
        }

        _context.Remove(hole);
        await _context.SaveChangesAsync();
    }
}