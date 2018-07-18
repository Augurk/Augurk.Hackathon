using Augurk.Hackathon.ATW;
using Augurk.Hackathon.Rooster.Models;
using Augurk.Hackathon.Rooster.Repositories;
using System;
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
            throw new NotImplementedException();
        }
    }
}