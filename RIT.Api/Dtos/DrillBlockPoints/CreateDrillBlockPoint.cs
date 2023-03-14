namespace RIT.Api.Dtos.DrillBlockPoints;

public class CreateDrillBlockPoint
{
    public Guid DrillBlockId { get; set; }
    public string Sequence { get; set; } = null!;
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}