using TechTalk.SpecFlow;

namespace Augurk.Hackathon.ATW.Specifications.Support
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
        public void SetupDefaultInrichting()
        {
            _inrichtingProvider.SetWaarden("MaximaleArbeidstijd", new[] { (0, 24) });
        }
    }
}
