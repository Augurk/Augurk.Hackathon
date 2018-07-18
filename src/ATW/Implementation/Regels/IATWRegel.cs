using System.Collections.Generic;

namespace Augurk.Hackathon.ATW.Regels
{
    public interface IATWRegel
    {
        bool Valideer(IEnumerable<Dienst> diensten, IATWLog log);
    }
}
