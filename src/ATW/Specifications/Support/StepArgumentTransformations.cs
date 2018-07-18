using System;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Support
{
    [Binding]
    public class StepArgumentTransformations
    {
        [StepArgumentTransformation("(.*)")]
        public static DayOfWeek DutchToEnglish(string input)
        {
            switch (input)
            {
                case "Maandag":
                    return DayOfWeek.Monday;
                case "Dinsdag":
                    return DayOfWeek.Tuesday;
                case "Woensdag":
                    return DayOfWeek.Wednesday;
                case "Donderdag":
                    return DayOfWeek.Thursday;
                case "Vrijdag":
                    return DayOfWeek.Friday;
                case "Zaterdag":
                    return DayOfWeek.Saturday;
                case "Zondag":
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentException($"Onbekende dag '{input}'", nameof(input));
            }
        }
    }
}
