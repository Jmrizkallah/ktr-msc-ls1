using System.Web;
using System.Web.Mvc;

namespace ktr_msc_ls1_BCM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
