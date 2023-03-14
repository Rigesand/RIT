namespace RIT.Api.Dtos.HolePoints;

public class CreateHolePoint
{
    public Guid HoleId { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}