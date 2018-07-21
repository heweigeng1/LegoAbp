using Abp.Application.Services;
using LegoAbp.Zero.Tenants.Domain;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Tenants
{
    public class TenantAppService : ApplicationService, ITenantAppService
    {
        protected TenantManager _tenantManager { get; set; }
        public TenantAppService(TenantManager tenantManager)
        {
            _tenantManager = tenantManager;
        }
    }
}
