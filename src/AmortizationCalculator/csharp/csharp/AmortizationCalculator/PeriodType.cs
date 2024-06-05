namespace AmortizationCalculator;

public enum PeriodType
{
    [RateModifier(6)]
    BiMonthly,
    [RateModifier(12)]
    Monthly,
    [RateModifier(52)]
    Weekly,
    [RateModifier(26)]
    BiWeekly,
    [RateModifier(2)]
    SemiAnnual,
    [RateModifier(1)]
    Annual,
}
