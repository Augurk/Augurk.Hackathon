using Shouldly;
using System.Collections.Generic;

namespace Augurk.Hackathon.ATW.Specifications.Support
{
    public class ATWLogDriver : IATWLog
    {
        private readonly List<string> _regels = new List<string>();

        public void StartATWRegel(string naam)
        {
            _regels.Add(naam);
        }

        public void EndATWRegel(string naam)
        {
            // Niks te doen hier
        }

        public void AssertRegelUitgevoerd(string naam)
        {
            _regels.Contains(naam).ShouldBeTrue();
        }
    }
}
