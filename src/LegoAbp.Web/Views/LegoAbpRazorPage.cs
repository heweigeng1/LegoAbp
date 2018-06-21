using Abp.AspNetCore.Mvc.Views;

namespace LegoAbp.Web.Views
{
    public abstract class LegoAbpRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected LegoAbpRazorPage()
        {
            LocalizationSourceName = LegoAbpConsts.LocalizationSourceName;
        }
    }
}
