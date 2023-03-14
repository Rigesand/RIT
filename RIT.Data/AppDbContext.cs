using Microsoft.EntityFrameworkCore;
using RIT.Data.Entities;

namespace RIT.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<DrillBlock> DrillBlocks => Set<DrillBlock>();
    public DbSet<DrillBlockPoints> DrillBlockPoints => Set<DrillBlockPoints>();
    public DbSet<Hole> Holes => Set<Hole>();
    public DbSet<HolePoints> HolePoints => Set<HolePoints>();
}