namespace RIT.Api.Dtos.DrillBlocks;

public class CreateDrillBlock
{
    public string Name { get; set; } = null!;
    public DateTimeOffset UpdateDate { get; set; }
}