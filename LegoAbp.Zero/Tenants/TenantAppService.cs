using Abp.Application.Services;
using LegoAbp.Zero.Tenants.Domain;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<string> TestTenant()
        {
            var b = _tenantManager._localizationManager.GetAllSources();
            var r = await _tenantManager.Testbb();
            return r;
        }
    }
}
