namespace AmortizationCalculator;

public class RateModifierAttribute : Attribute
{
    public int Modifier { get; }
    public RateModifierAttribute(int modifier)
    {
        this.Modifier = modifier;
    }
}