using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Zero;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    [DependsOn(typeof(LegoAbpZeroModule))]
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
