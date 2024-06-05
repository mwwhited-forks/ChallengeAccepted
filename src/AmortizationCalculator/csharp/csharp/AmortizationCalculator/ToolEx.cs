namespace AmortizationCalculator;

public static class ToolEx
{
    public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
    {
        // https://stackoverflow.com/a/9276348/89586
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false).OfType<T>();
        return attributes.FirstOrDefault();
    }

    public static int Modifier(this PeriodType type)
    {
        return type.GetAttributeOfType<RateModifierAttribute>().Modifier;
    }

    public static DateTime Next(this DateTime start, PeriodType period)
    {
        switch (period)
        {
            case PeriodType.BiMonthly:
                return start.AddMonths(2);
            case PeriodType.Monthly:
                return start.AddMonths(1);
            case PeriodType.Weekly:
                return start.AddDays(7);
            case PeriodType.BiWeekly:
                return start.AddDays(14);
            case PeriodType.SemiAnnual:
                return start.AddMonths(6);
            case PeriodType.Annual:
                return start.AddYears(1);

            default:
                break;
        }

        throw new NotSupportedException();
    }
}
