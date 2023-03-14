namespace RIT.Api.Dtos.HolePoints;

public class GetHolePoint
{
    public Guid Id { get; set; }
    public Guid HoleId { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}