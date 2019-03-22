using Abp.Application.Services;
using LegoAbp.Zero.Tenants.Domain;

namespace LegoAbp.Zero.Tenants
{
    public class TenantAppService : ApplicationService, ITenantAppService
    {
        protected LegoAbpTenantManager _tenantManager { get; set; }
        public TenantAppService(LegoAbpTenantManager tenantManager)
        {
            _tenantManager = tenantManager;
        }
        
    }
}
