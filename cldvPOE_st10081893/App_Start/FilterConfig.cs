using System.Web;
using System.Web.Mvc;

namespace cldvPOE_st10081893
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
