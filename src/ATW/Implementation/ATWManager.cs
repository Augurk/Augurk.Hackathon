using Augurk.Hackathon.ATW.Regels;
using System.Collections.Generic;

namespace Augurk.Hackathon.ATW
{
    public class ATWManager
    {
        public bool ValideerATW(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log)
        {
            IATWRegel maximaleArbeidstijdRegel = new MaximaleArbeidstijdRegel();
            maximaleArbeidstijdRegel.Valideer(leeftijd, inrichting, diensten, log);

            IATWRegel verplichteRustperiodeRegel = new VerplichteRustperiodeRegel();
            verplichteRustperiodeRegel.Valideer(leeftijd, inrichting, diensten, log);

            return false;
        }
    }
}
