using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants
{
    public interface ITenantAppService : IDomainService
    {
        string TestTenant();

    }
}
