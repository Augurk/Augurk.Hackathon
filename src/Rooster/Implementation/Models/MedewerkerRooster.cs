using Augurk.Hackathon.ATW;
using System.Collections.Generic;

namespace Augurk.Hackathon.Rooster.Models
{
    public class MedewerkerRooster
    {
        public MedewerkerRooster(int leeftijd, List<Dienst> diensten, bool atwOvertreden)
        {
            Leeftijd = leeftijd;
            Diensten = diensten;
            ATWOvertreden = atwOvertreden;
        }

        public int Leeftijd { get; }

        public List<Dienst> Diensten { get; }

        public bool ATWOvertreden { get; set; }
    }
}