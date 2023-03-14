namespace RIT.Data.Entities;

public class Hole
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid DrillBlockId { get; set; }
    public DrillBlock DrillBlock { get; set; } = null!;
    public decimal Depth { get; set; }
}