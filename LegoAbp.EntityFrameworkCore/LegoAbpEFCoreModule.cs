using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpEFCoreModule : AbpModule
    {
        
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpEFCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            
        }
    }
}
