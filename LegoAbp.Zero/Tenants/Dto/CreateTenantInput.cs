using Abp.AutoMapper;
using LegoAbp.Zero.Tenants.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants.Dto
{
    [AutoMap(typeof(Tenant))]
    public class CreateTenantInput
    {

    }
}
