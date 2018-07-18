using Augurk.Hackathon.ATW;
using System.Collections.Generic;

namespace Augurk.Hackathon.Rooster.Specifications.Support
{
    public class DienstEqualityComparer : IEqualityComparer<Dienst>
    {
        public bool Equals(Dienst x, Dienst y)
        {
            return x.DagVanDeWeek.Equals(y.DagVanDeWeek) &&
                   x.StartTijd.Equals(y.StartTijd) &&
                   x.Eindtijd.Equals(y.Eindtijd) &&
                   x.Duur.Equals(y.Duur);
        }

        public int GetHashCode(Dienst obj)
        {
            return obj.DagVanDeWeek.GetHashCode() ^
                   obj.StartTijd.GetHashCode() ^
                   obj.Eindtijd.GetHashCode() ^
                   obj.Duur.GetHashCode();
        }
    }
}
