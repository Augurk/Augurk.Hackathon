using System.Web;
using System.Web.Mvc;

namespace Augurk.Hackathon.Rooster
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
