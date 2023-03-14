using Microsoft.EntityFrameworkCore;
using RIT.Data;
using RIT.Data.Entities;

namespace RIT.Api.Services;

public class HolePointService
{
    private readonly AppDbContext _context;

    public HolePointService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateHolePoint(HolePoints holePoint)
    {
        var hole = await _context.Holes.FirstOrDefaultAsync(it => it.Id == holePoint.HoleId);
        if (hole == null)
        {
            throw new Exception("HolePoint does not exist");
        }

        holePoint.Hole = hole;

        await _context.HolePoints.AddAsync(holePoint);
        await _context.SaveChangesAsync();
    }

    public async Task<HolePoints> GetHolePoint(Guid id)
    {
        var holePoint = await _context.HolePoints.AsNoTracking().FirstOrDefaultAsync(it => it.Id == id);
        if (holePoint == null)
        {
            throw new Exception("HolePoint does not exist");
        }

        return holePoint;
    }

    public async Task UpdateHolePoint(HolePoints updateHolePoint)
    {
        var holePoints = await _context.HolePoints.FirstOrDefaultAsync(it => it.Id == updateHolePoint.Id);
        if (holePoints == null)
        {
            throw new Exception("DrillBlock does not exist");
        }

        holePoints.X = updateHolePoint.X;
        holePoints.Y = updateHolePoint.Y;
        holePoints.Z = updateHolePoint.Z;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHolePoint(Guid id)
    {
        var holePoints = await _context.HolePoints.FirstOrDefaultAsync(it => it.Id == id);
        if (holePoints == null)
        {
            throw new Exception("HolePoints does not exist");
        }

        _context.Remove(holePoints);
        await _context.SaveChangesAsync();
    }
}