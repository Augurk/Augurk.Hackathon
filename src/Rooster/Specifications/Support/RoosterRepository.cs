using Augurk.Hackathon.Rooster.Models;
using Augurk.Hackathon.Rooster.Repositories;
using Newtonsoft.Json;

namespace Augurk.Hackathon.Rooster.Specifications.Support
{
    public class RoosterRepository : IRoosterRepository
    {
        private string _rooster;

        public MedewerkerRooster GetRooster()
        {
            // Clone the object we have so we don't share memory with our consumers, possibly causing weirdness in the tests
            return JsonConvert.DeserializeObject<MedewerkerRooster>(_rooster);
        }

        public void OpslaanRooster(MedewerkerRooster rooster)
        {
            _rooster = JsonConvert.SerializeObject(rooster);
        }
    }
}
