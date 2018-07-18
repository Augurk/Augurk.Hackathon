using Shouldly;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Steps
{
    [Binding]
    public class InrichtingSteps
    {
        private readonly IInrichtingProvider inrichtingProvider;
        private readonly List<(int leeftijd, int maximaleArbeidstijd)> maximaleArbeidstijden = new List<(int leeftijd, int maximaleArbeidstijd)>();
        private int? retrievedWaarde;

        public InrichtingSteps(InrichtingProvider inrichtingProvider)
        {
            this.inrichtingProvider = inrichtingProvider;
        }

        [Given(@"het volgende is ingericht onder de naam ""(.*)""")]
        public void GegevenHetVolgendeIsIngerichtOnderDeNaam(string inrichtingsNaam, Table table)
        {
            List<(int leeftijd, int waarde)> waarden = new List<(int leeftijd, int waarde)>();
            foreach (TableRow row in table.Rows)
            {
                waarden.Add((int.Parse(row["Leeftijd"]), int.Parse(row["Waarde"])));
            }

            this.inrichtingProvider.SetWaarden(inrichtingsNaam, waarden.ToArray());
        }

        [Given(@"de maximaal toegestane arbeidstijd vanaf (.*) jaar is (.*) uur")]
        public void GegevenDeMaximaalToegestaneArbeidstijdVanafJaarIsUur(int leeftijd, int maximaleArbeidstijd)
        {
            maximaleArbeidstijden.Add((leeftijd, maximaleArbeidstijd));
            this.inrichtingProvider.SetWaarden("MaximaleArbeidstijd", maximaleArbeidstijden.ToArray());
        }

        [When(@"de inrichting van ""(.*)"" wordt opgevraagd voor een medewerker van (.*) jaar")]
        public void AlsDeInrichtingWordtOpgevraagdVoorEenMedewerkerVanJaar(string inrichtingsNaam, int leeftijd)
        {
            retrievedWaarde = this.inrichtingProvider.GetWaarde<int>(inrichtingsNaam, leeftijd);
        }

        [Then(@"wordt de waarde (.*) gevonden")]
        public void DanWordtDeWaardeGevonden(int waarde)
        {
            retrievedWaarde.ShouldBe(waarde);
        }

        [Then(@"wordt geen waarde gevonden")]
        public void DanWordtGeenWaardeGevonden()
        {
            retrievedWaarde.ShouldBeNull();
        }
    }
}
