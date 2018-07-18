using Augurk.Hackathon.ATW.Regels;
using System.Collections.Generic;

namespace Augurk.Hackathon.ATW
{
    public class ATWManager
    {
        public bool ValideerATW(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log)
        {
            bool result = true;

            IATWRegel maximaleArbeidstijdRegel = new MaximaleArbeidstijdRegel();
            result = maximaleArbeidstijdRegel.Valideer(leeftijd, inrichting, diensten, log);

            IATWRegel verplichteRustperiodeRegel = new VerplichteRustperiodeRegel();
            result = result && verplichteRustperiodeRegel.Valideer(leeftijd, inrichting, diensten, log);

            return result;
        }
    }
}
