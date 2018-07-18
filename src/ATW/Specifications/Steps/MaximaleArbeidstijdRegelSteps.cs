using Augurk.Hackathon.ATW.Regels;
using Augurk.Hackathon.ATW.Specifications.Support;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class MaximaleArbeidstijdRegelSteps
    {
        private readonly List<(int leeftijd, int maximaleArbeidstijd)> maximaleArbeidstijden = new List<(int leeftijd, int maximaleArbeidstijd)>();
        private readonly ATWDriver _atw;
        private readonly InrichtingProvider _inrichtingProvider;

        public MaximaleArbeidstijdRegelSteps(ATWDriver atw, InrichtingProvider inrichtingProvider)
        {
            _atw = atw;
            _inrichtingProvider = inrichtingProvider;
        }

        [Given(@"de maximaal toegestane arbeidstijd vanaf (.*) jaar is (.*) uur")]
        public void GegevenDeMaximaalToegestaneArbeidstijdVanafJaarIsUur(int leeftijd, int maximaleArbeidstijd)
        {
            maximaleArbeidstijden.Add((leeftijd, maximaleArbeidstijd));
            _inrichtingProvider.SetWaarden("MaximaleArbeidstijd", maximaleArbeidstijden.ToArray());
        }

        [When(@"de controle ""maximale arbeidstijd"" wordt uitgevoerd")]
        public void AlsDeControleMaximaleArbeidstijdWordtUitgevoerd()
        {
            _atw.VoerRegelUit(new MaximaleArbeidstijdRegel());
        }
    }
}
