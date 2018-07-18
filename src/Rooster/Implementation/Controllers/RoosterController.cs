using Augurk.Hackathon.ATW;
using Augurk.Hackathon.Rooster.Models;
using Augurk.Hackathon.Rooster.Repositories;
using System;
using System.Linq;
using System.Web.Http;

namespace Augurk.Hackathon.Rooster.Controllers
{
    public class RoosterController : ApiController
    {
        private readonly IRoosterRepository _repository;
        private readonly InrichtingProvider _inrichtingProvider;
        private readonly IATWLog _log;

        public RoosterController(IRoosterRepository repository, InrichtingProvider inrichtingProvider, IATWLog log)
        {
            _repository = repository;
            _inrichtingProvider = inrichtingProvider;
            _log = log;
        }

        public MedewerkerRooster Get()
        {
            return _repository.GetRooster();
        }

        public MedewerkerRooster Post([FromBody]Dienst dienst)
        {
            var rooster = _repository.GetRooster();
            rooster.Diensten.Add(dienst);

            ATWManager manager = new ATWManager();
            rooster.ATWOvertreden = !manager.ValideerATW(rooster.Leeftijd, _inrichtingProvider, rooster.Diensten, _log);

            _repository.OpslaanRooster(rooster);
            return rooster;
        }

        public MedewerkerRooster Delete(Dienst dienst)
        {
            var rooster = _repository.GetRooster();
            var bestaandeDienst = rooster.Diensten.FirstOrDefault(d => d.StartTijd == dienst.StartTijd &&
                                                                       d.Eindtijd == dienst.Eindtijd &&
                                                                       d.DagVanDeWeek == dienst.DagVanDeWeek);
            rooster.Diensten.Remove(bestaandeDienst);

            _repository.OpslaanRooster(rooster);
            return rooster;
        }
    }
}