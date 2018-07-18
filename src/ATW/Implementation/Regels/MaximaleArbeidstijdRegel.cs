using System;
using System.Collections.Generic;
using System.Linq;

namespace Augurk.Hackathon.ATW.Regels
{
    public class MaximaleArbeidstijdRegel : IATWRegel
    {
        public const string NAME = "maximale arbeidstijd";

        public bool Valideer(int leeftijd, IInrichtingProvider inrichting, IEnumerable<Dienst> diensten, IATWLog log)
        {
            log.StartATWRegel(NAME);

            int? maximaleArbeidstijd = inrichting.GetWaarde<int>("MaximaleArbeidstijd", leeftijd);
            if (!maximaleArbeidstijd.HasValue)
            {
                throw new InvalidOperationException("Geen waarde ingericht voor instelling 'MaximaleArbeidsTijd");
            }

            bool result = true;
            var dienstenPerDag = diensten.GroupBy(dienst => dienst.DagVanDeWeek);
            foreach (var dag in dienstenPerDag)
            {
                var duur = TimeSpan.FromSeconds(dag.Sum(dienst => dienst.Duur.TotalSeconds));
                if (duur.TotalHours > maximaleArbeidstijd)
                {
                    result = false;
                    break;
                }
            }

            log.EndATWRegel(NAME);
            return result;
        }
    }
}
