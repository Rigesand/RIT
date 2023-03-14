namespace RIT.Data.Entities;

public class DrillBlockPoints
{
    public Guid Id { get; set; }
    public Guid DrillBlockId { get; set; }
    public DrillBlock DrillBlock { get; set; } = null!;
    public string Sequence { get; set; } = null!;
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}