namespace RIT.Api.Dtos.DrillBlocks;

public class UpdateDrillBlock
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset UpdateDate { get; set; }
}