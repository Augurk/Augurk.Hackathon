using Augurk.Hackathon.Rooster.Models;

namespace Augurk.Hackathon.Rooster.Repositories
{
    public interface IRoosterRepository
    {
        MedewerkerRooster GetRooster();

        void OpslaanRooster(MedewerkerRooster rooster);
    }
}