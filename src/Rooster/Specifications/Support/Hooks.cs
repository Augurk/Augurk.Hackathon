using Augurk.Hackathon.ATW;
using TechTalk.SpecFlow;

namespace Augurk.Hackathon.Rooster.Specifications.Support
{
    [Binding]
    public class Hooks
    {
        private readonly InrichtingProvider _inrichtingProvider;

        public Hooks(InrichtingProvider inrichtingProvider)
        {
            _inrichtingProvider = inrichtingProvider;
        }

        [BeforeScenario]
        public void DefaultInrichting()
        {
            var waarden = new (int leeftijd, int waarde)[100];
            for (int i = 0; i < 100; i++)
            {
                waarden[i] = (i, 24);
            }

            _inrichtingProvider.SetWaarden("MaximaleArbeidstijd", waarden);
        }
    }
}
