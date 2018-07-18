using Augurk.Hackathon.ATW.Specifications.Support;
using System.Linq;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class ATWSteps
    {
        private readonly ATWLogDriver _log;

        public ATWSteps(ATWLogDriver log)
        {
            _log = log;
        }

        [When(@"de ATW controle wordt uitgevoerd")]
        public void AlsDeATWControleWordtUitgevoerd()
        {
            ATWManager manager = new ATWManager();
            manager.ValideerATW(Enumerable.Empty<Dienst>(), _log);
        }

        [Then(@"is de controle op ""(.*)"" uitgevoerd")]
        public void DanIsDeControleOpUitgevoerd(string naam)
        {
            _log.AssertRegelUitgevoerd(naam);
        }
    }
}
