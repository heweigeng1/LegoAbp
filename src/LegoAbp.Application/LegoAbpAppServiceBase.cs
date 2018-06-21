using Abp.Application.Services;

namespace LegoAbp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LegoAbpAppServiceBase : ApplicationService
    {
        protected LegoAbpAppServiceBase()
        {
            LocalizationSourceName = LegoAbpConsts.LocalizationSourceName;
        }
    }
}