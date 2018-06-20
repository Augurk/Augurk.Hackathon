using System.Collections.Generic;
using System.Linq;

namespace Augurk.Hackathon.ATW
{
    public class InrichtingProvider : IInrichtingProvider
    {
        private readonly Dictionary<string, object> waarden;

        public InrichtingProvider()
        {
            this.waarden = new Dictionary<string, object>();
        }

        public T? GetWaarde<T>(string naam, int leeftijd) where T : struct
        {
            if (this.waarden.TryGetValue(naam, out object waarden))
            {
                var inrichtingWaarden = ((int leeftijd, T waarde)[])waarden;
                if (inrichtingWaarden.Any(w => w.leeftijd == leeftijd))
                {
                    return inrichtingWaarden.FirstOrDefault(w => w.leeftijd == leeftijd).waarde;
                }
            }

            return null;
        }

        public void SetWaarden<T>(string naam, (int leeftijd, T waarde)[] waarden) where T : struct
        {
            this.waarden[naam] = waarden;
        }
    }
}
