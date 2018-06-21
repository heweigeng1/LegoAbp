using Abp.AspNetCore.Mvc.Controllers;

namespace LegoAbp.Web.Controllers
{
    public abstract class LegoAbpControllerBase: AbpController
    {
        protected LegoAbpControllerBase()
        {
            LocalizationSourceName = LegoAbpConsts.LocalizationSourceName;
        }
    }
}