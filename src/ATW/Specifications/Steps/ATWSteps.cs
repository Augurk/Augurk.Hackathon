using Augurk.Hackathon.ATW.Specifications.Support;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class ATWSteps
    {
        private readonly ATWDriver _atw;
        private readonly ATWLogDriver _log;
        private readonly InrichtingProvider _inrichtingProvider;

        public ATWSteps(ATWDriver atw, ATWLogDriver log, InrichtingProvider inrichtingProvider)
        {
            _atw = atw;
            _log = log;
            _inrichtingProvider = inrichtingProvider;
        }

        [Given(@"de medewerker is (.*) jaar oud")]
        public void GegevenDeMedewerkerIsJaarOud(int leeftijd)
        {
            _atw.Leeftijd = leeftijd;
        }

        [Given(@"de medewerker heeft de volgende geroosterde uren")]
        public void GegevenDeMedewerkerHeeftDeVolgendeGeroosterdeUren(Table table)
        {
            _atw.Diensten = table.CreateSet(row => new Dienst { DagVanDeWeek = StepArgumentTransformations.DutchToEnglish(row["Dag"]) })
                                 .ToList();
        }

        [When(@"de ATW controle wordt uitgevoerd")]
        public void AlsDeATWControleWordtUitgevoerd()
        {
            ATWManager manager = new ATWManager();
            manager.ValideerATW(0, _inrichtingProvider, Enumerable.Empty<Dienst>(), _log);
        }

        [Then(@"is de controle op ""(.*)"" uitgevoerd")]
        public void DanIsDeControleOpUitgevoerd(string naam)
        {
            _log.AssertRegelUitgevoerd(naam);
        }

        [Then(@"wordt de regel ""(.*)"" overschreden")]
        public void DanWordtDeRegelOverschreden(string naam)
        {
            _atw.AssertRegelOverschreden();
        }

        [Then(@"wordt de regel ""(.*)"" NIET overschreden")]
        public void DanWordtDeRegelNIETOverschreden(string naam)
        {
            _atw.AssertRegelNietOverschreden();
        }
    }
}
