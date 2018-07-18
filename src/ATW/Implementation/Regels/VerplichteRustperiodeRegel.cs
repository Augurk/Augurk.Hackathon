using System;
using System.Collections.Generic;
using System.Linq;

namespace Augurk.Hackathon.ATW.Regels
{
    public class VerplichteRustperiodeRegel : IATWRegel
    {
        public const string NAME = "verplichte rustperiode";

        public bool Valideer(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log)
        {
            log.StartATWRegel(NAME);
            bool valid = false;
            var verplichteRustperiode = inrichting.GetWaarde<(TimeSpan begintTijd, TimeSpan eindTijd)>("NietWerkbareTijden", leeftijd);

            if (verplichteRustperiode.HasValue)
            {
                valid = !diensten.Any(dienst => dienst.Eindtijd >= verplichteRustperiode.Value.begintTijd || dienst.StartTijd >= verplichteRustperiode.Value.eindTijd);
            }
            else
            {
                valid = true;
            }
            log.EndATWRegel(NAME);
            return valid;
        }
    }
}
