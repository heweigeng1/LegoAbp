using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace LegoAbp.EntityFrameworkCore
{
    [DependsOn(
        typeof(LegoAbpCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class LegoAbpEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpEntityFrameworkCoreModule).GetAssembly());
        }
    }
}