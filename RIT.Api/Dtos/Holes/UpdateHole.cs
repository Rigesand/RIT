namespace RIT.Api.Dtos.Holes;

public class UpdateHole
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Depth { get; set; }
}