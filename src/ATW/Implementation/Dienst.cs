using System;

namespace Augurk.Hackathon.ATW
{
    public class Dienst
    {
        public DayOfWeek DagVanDeWeek { get; set; }

        public TimeSpan StartTijd { get; set; }

        public TimeSpan Eindtijd { get; set; }

        public TimeSpan Duur => Eindtijd - StartTijd;
    }
}