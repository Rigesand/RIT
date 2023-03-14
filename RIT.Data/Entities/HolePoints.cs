namespace RIT.Data.Entities;

public class HolePoints
{
    public Guid Id { get; set; }
    public Guid HoleId { get; set; }
    public Hole Hole { get; set; } = null!;
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}