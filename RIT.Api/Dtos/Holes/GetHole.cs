namespace RIT.Api.Dtos.Holes;

public class GetHole
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid DrillBlockId { get; set; }
    public decimal Depth { get; set; }
}