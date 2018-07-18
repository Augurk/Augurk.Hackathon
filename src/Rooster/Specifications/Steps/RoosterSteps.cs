using Augurk.Hackathon.ATW;
using Augurk.Hackathon.Rooster.Controllers;
using Augurk.Hackathon.Rooster.Models;
using Augurk.Hackathon.Rooster.Specifications.Support;
using Shouldly;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Augurk.Hackathon.Rooster.Specifications.Steps
{
    [Binding]
    public class RoosterSteps
    {
        private readonly RoosterRepository _repository;
        private readonly InrichtingProvider _inrichtingProvider;
        private readonly RoosterController _controller;
        private int _leeftijd;

        public RoosterSteps(RoosterRepository repository, InrichtingProvider inrichtingProvider, ATWLogDriver log)
        {
            _repository = repository;
            _inrichtingProvider = inrichtingProvider;
            _controller = new RoosterController(_repository, _inrichtingProvider, log);
        }

        [Given(@"de medewerker is (.*) jaar oud")]
        public void GegevenDeMedewerkerIsJaarOud(int leeftijd)
        {
            _leeftijd = leeftijd;
        }

        [Given(@"de volgende diensten zijn reeds ingeroosterd")]
        public void GegevenDeVolgendeDienstenZijnReedsIngeroosterd(Table table)
        {
            var diensten = table.CreateSet(row => new Dienst { DagVanDeWeek = StepArgumentTransformations.DutchToEnglish(row["Dag"]) }).ToList();
            var rooster = new MedewerkerRooster(_leeftijd, diensten, false);
            _repository.OpslaanRooster(rooster);
        }

        [When(@"ik een dienst van (.*) tot (.*) inrooster op (.*)")]
        public void AlsIkEenDienstVanTotInroosterOpWoensdag(TimeSpan beginTijd, TimeSpan eindTijd, string dag)
        {
            Dienst dienst = new Dienst
            {
                DagVanDeWeek = StepArgumentTransformations.DutchToEnglish(dag),
                StartTijd = beginTijd,
                Eindtijd = eindTijd
            };

            _controller.Post(dienst);
        }

        [When(@"de dienst van (.*) tot (.*) op (.*) wordt verwijderd")]
        public void AlsDeDienstOpDinsdagVanTotWordtVerwijderd(TimeSpan beginTijd, TimeSpan eindTijd, string dag)
        {
            var rooster = _controller.Get();
            var dienst = rooster.Diensten.FirstOrDefault(d => d.StartTijd == beginTijd &&
                                                              d.Eindtijd == eindTijd &&
                                                              d.DagVanDeWeek == StepArgumentTransformations.DutchToEnglish(dag));

            if (dienst == null)
            {
                throw new InvalidOperationException($"Er is geen dienst geroosterd van {beginTijd} tot {eindTijd} op {dag}");
            }

            _controller.Delete(dienst);
        }

        [Then(@"zijn de volgende diensten ingeroosterd")]
        public void DanZijnDeVolgendeDienstenIngeroosterd(Table table)
        {
            var rooster = _repository.GetRooster();
            table.CreateSet(row => new Dienst { DagVanDeWeek = StepArgumentTransformations.DutchToEnglish(row["Dag"]) })
                 .SequenceEqual(rooster.Diensten, new DienstEqualityComparer()).ShouldBeTrue();
        }

        [Then(@"er zijn geen ATW regels overtreden")]
        public void DanErZijnGeenATWRegelsOvertreden()
        {
            var rooster = _repository.GetRooster();
            rooster.ATWOvertreden.ShouldBeFalse();
        }

        [Then(@"er zijn ATW regels overtreden")]
        public void DanErZijnATWRegelsOvertreden()
        {
            var rooster = _repository.GetRooster();
            rooster.ATWOvertreden.ShouldBeTrue();
        }
    }
}
