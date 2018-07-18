using Augurk.Hackathon.ATW.Regels;
using Augurk.Hackathon.ATW.Specifications.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class VerplichteRustperiodeRegelSteps
    {
        private readonly ATWDriver _atw;
        private readonly InrichtingProvider _inrichtingProvider;

        public VerplichteRustperiodeRegelSteps(ATWDriver atw, InrichtingProvider inrichtingProvider)
        {
            _atw = atw;
            _inrichtingProvider = inrichtingProvider;
        }

        [Given(@"de niet werkbare tijden voor iemand van (.*) zijn van (.*) tot (.*)")]
        public void GegevenDeNietWerkbareTijdenVoorIemandVanOfJaarZijnVanTot(int[] leeftijden, TimeSpan beginTijd, TimeSpan eindTijd)
        {
            _inrichtingProvider.SetWaarden("NietWerkbareTijden", leeftijden.Select(leeftijd =>
                (leeftijd, (beginTijd, eindTijd))).ToArray());
        }


        [When(@"de controle ""verplichte rustperiode"" wordt uitgevoerd")]
        public void AlsDeControleWordtUitgevoerd()
        {
            _atw.VoerRegelUit(new VerplichteRustperiodeRegel());
        }

    }
}
