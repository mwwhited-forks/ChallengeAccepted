namespace AmortizationCalculator;

public record AmortizationModel
{
    public int Term { get; init; }
    public DateTime Date { get; init; }
    public int Days { get; init; }
    public decimal Starting { get; init; }
    public decimal Principal { get; init; }
    public decimal Interest { get; init; }
    public decimal Tax { get; init; }
    public decimal Payment { get; init; }
    public decimal Balloon { get; init; }
    public decimal Ending { get; init; }
}