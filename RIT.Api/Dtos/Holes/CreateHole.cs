namespace RIT.Api.Dtos.Holes;

public class CreateHole
{
    public string Name { get; set; } = null!;
    public DateTimeOffset UpdateDate { get; set; }
    public Guid DrillBlockId { get; set; }
    public decimal Depth { get; set; }
}