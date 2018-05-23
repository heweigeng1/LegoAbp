using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.AspNetCore.Configuration;

namespace LegoAbp.Core.AbpExp
{
    public static class AbpAspNetCoreConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP ASP.NET Core module.
        /// </summary>
        public static IAbpAspNetCoreConfiguration AbpAspNetCore2(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpAspNetCoreConfiguration>();
        }
    }
}
