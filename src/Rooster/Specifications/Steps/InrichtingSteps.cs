using Augurk.Hackathon.ATW;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.Rooster.Specifications.Steps
{
    [Binding]
    public class InrichtingSteps
    {
        private readonly InrichtingProvider _inrichtingProvider;

        public InrichtingSteps(InrichtingProvider inrichtingProvider)
        {
            _inrichtingProvider = inrichtingProvider;
        }

        [Given(@"de niet werkbare tijden voor iemand van (.*) zijn van (.*) tot (.*)")]
        public void GegevenDeNietWerkbareTijdenVoorIemandVanOfJaarZijnVanTot(int[] leeftijden, TimeSpan beginTijd, TimeSpan eindTijd)
        {
            _inrichtingProvider.SetWaarden("NietWerkbareTijden", leeftijden.Select(leeftijd =>
                (leeftijd, (beginTijd, eindTijd))).ToArray());
        }
    }
}
