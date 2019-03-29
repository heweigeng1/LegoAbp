using Abp.Application.Services;
using LegoAbp.Zero.Tenants.Domain;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Tenants
{
    public class TenantAppService : ApplicationService, ITenantAppService
    {
        private readonly LegoAbpTenantManager _tenantManager;
        public TenantAppService(LegoAbpTenantManager tenantManager)
        {
            _tenantManager = tenantManager;
        }
        public async Task Test()
        {
             await _tenantManager.FindByTenancyNameAsync("default");
        }
    }
}
