using Augurk.Hackathon.ATW.Regels;
using Augurk.Hackathon.ATW.Specifications.Support;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class MaximaleArbeidstijdRegelSteps
    {
        private readonly ATWDriver _atw;

        public MaximaleArbeidstijdRegelSteps(ATWDriver atw)
        {
            _atw = atw;
        }

        [When(@"de controle ""maximale arbeidstijd"" wordt uitgevoerd")]
        public void AlsDeControleMaximaleArbeidstijdWordtUitgevoerd()
        {
            _atw.VoerRegelUit(new MaximaleArbeidstijdRegel());
        }
    }
}
