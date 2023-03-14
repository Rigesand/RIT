namespace RIT.Data.Entities;

public class DrillBlock
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset UpdateDate { get; set; }
    public ICollection<DrillBlockPoints>? DrillBlockPoints { get; set; }
    public ICollection<Hole>? Holes { get; set; }
}