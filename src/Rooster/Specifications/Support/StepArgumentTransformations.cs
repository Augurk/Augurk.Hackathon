using System;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.Rooster.Specifications.Support
{
    [Binding]
    public class StepArgumentTransformations
    {
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

        [StepArgumentTransformation(@"(\d*) of (\d*) jaar")]
        public int[] TwoAges(int age1, int age2)
        {
            return new[] { age1, age2 };
        }

        [StepArgumentTransformation(@"(\d{1,2}):(\d{2})")]
        public TimeSpan TimeSpanParse(int hours, int minutes)
        {
            return new TimeSpan(hours, minutes, 0);
        }
    }
}
