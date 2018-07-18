using System.Collections.Generic;

namespace Augurk.Hackathon.ATW.Regels
{
    public class MaximaleArbeidstijdRegel : IATWRegel
    {
        public const string NAME = "maximale arbeidstijd";

        public bool Valideer(IEnumerable<Dienst> diensten, IATWLog log)
        {
            log.StartATWRegel(NAME);
            log.EndATWRegel(NAME);
            return false;
        }
    }
}
