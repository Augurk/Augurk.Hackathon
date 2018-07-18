using System.Collections.Generic;

namespace Augurk.Hackathon.ATW.Regels
{
    public class VerplichteRustperiodeRegel : IATWRegel
    {
        public const string NAME = "verplichte rustperiode";

        public bool Valideer(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log)
        {
            log.StartATWRegel(NAME);
            log.EndATWRegel(NAME);
            return false;
        }
    }
}
