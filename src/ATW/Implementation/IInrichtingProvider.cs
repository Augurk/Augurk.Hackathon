using System;

namespace Augurk.Hackathon.ATW
{
    public interface IInrichtingProvider
    {
        Nullable<T> GetWaarde<T>(string naam, int leeftijd) where T : struct;
        void SetWaarden<T>(string naam, (int leeftijd, T waarde)[] waarden) where T : struct;
    }
}
