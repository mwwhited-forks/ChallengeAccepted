namespace AmortizationCalculator;

internal partial class Program
{
    static void Main(string[] args)
    {
        var contract = new
        {
            ScheduleRules = new[]
            {
                    new {
                        Terms = 24,
                        StartingPrincipal = 160000.00m,
                        Ballon = 60000.00m,
                        Rounding = 2,
                        StartingDate = new DateTime(2018, 3, 1),
                        PeriodType = PeriodType.Monthly,
                        Rate = .12m,
                        Tax = .16m,

                        OutstangingPrincipal = 160000.00m,
                    },
                },
        };

        var amort = AmortizationSchedule(new DateTime(2018, 1, 1), 0, 24, 4725.48m, 150000m, 50000, PeriodType.Monthly, .065m / 12).ToArray();


        //var payments = from sr in contract.ScheduleRules
        //               let bmp = (decimal)Math.Round(Financial.Pmt((double)sr.Rate / sr.PeriodType.Modifier(), sr.Terms, (double)-sr.OutstangingPrincipal, (double)sr.Ballon), sr.Rounding)
        //               let cmp = (decimal)Math.Round(Financial.Pmt((double)sr.Rate / sr.PeriodType.Modifier(), sr.Terms, (double)-sr.OutstangingPrincipal, (double)sr.Ballon), sr.Rounding)
        //               select new
        //               {
        //                   sr,
        //                   bmp,
        //                   cmp,

        //                   OriginalAmortization = from term in Enumerable.Range(1, sr.Terms)
        //                                          select new
        //                                          {

        //                                          }
        //               };
    }

    public static IEnumerable<AmortizationModel> AmortizationSchedule(DateTime startingDate, int currentTerm, int remainingTerms, decimal payment, decimal outstandingPrincipal, decimal balloon, PeriodType periodType, decimal periodaicRate)
    {
        var startingPrincipal = outstandingPrincipal;
        var nextDate = startingDate;

        foreach (var term in Enumerable.Range(currentTerm, remainingTerms))
        {
            var termLength = 1; // 30; //this should change based on period type

            var interest = Math.Round(outstandingPrincipal * periodaicRate * termLength, 2);
            var tax = Math.Round(interest * .16m, 2);
            var principal = Math.Max(payment - interest, 0);


            var endingPrincipal = startingPrincipal - principal;
            if (endingPrincipal < balloon)
            {
                var diff = balloon - endingPrincipal;
                principal = Math.Max(principal - diff, 0);
            }

            yield return new AmortizationModel
            {
                Term = term,
                Date = nextDate,
                Days = termLength,

                Starting = startingPrincipal,

                Principal = principal,
                Interest = interest,
                Tax = tax,

                Payment = principal + interest + tax,

                Balloon = term == remainingTerms ? balloon : 0,

                Ending = endingPrincipal
            };

            nextDate = nextDate.Next(periodType);
            startingPrincipal = endingPrincipal;
        }
    }
}