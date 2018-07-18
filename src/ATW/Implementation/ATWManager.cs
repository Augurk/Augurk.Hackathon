using Augurk.Hackathon.ATW.Regels;
using System.Collections.Generic;

namespace Augurk.Hackathon.ATW
{
    public class ATWManager
    {
        public bool ValideerATW(IEnumerable<Dienst> diensten, IATWLog log)
        {
            IATWRegel maximaleArbeidstijdRegel = new MaximaleArbeidstijdRegel();
            maximaleArbeidstijdRegel.Valideer(diensten, log);

            IATWRegel verplichteRustperiodeRegel = new VerplichteRustperiodeRegel();
            verplichteRustperiodeRegel.Valideer(diensten, log);

            return false;
        }
    }
}
