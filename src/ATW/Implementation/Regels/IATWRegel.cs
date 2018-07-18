using System.Collections.Generic;

namespace Augurk.Hackathon.ATW.Regels
{
    public interface IATWRegel
    {
        bool Valideer(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log);
    }
}
