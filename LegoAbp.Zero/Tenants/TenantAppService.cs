﻿using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants
{
    public class TenantAppService : ApplicationService, ITenantAppService
    {
        public TenantAppService()
        {
            LocalizationSourceName = "LegoAbpZero";
        }
        public string TestTenant()
        {
            return L("InvalidTenancyName");
        }
    }
}
