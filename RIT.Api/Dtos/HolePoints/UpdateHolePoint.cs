namespace RIT.Api.Dtos.HolePoints;

public class UpdateHolePoint
{
    public Guid Id { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}