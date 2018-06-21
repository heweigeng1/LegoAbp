using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace LegoAbp
{
    [DependsOn(
        typeof(LegoAbpCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LegoAbpApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpApplicationModule).GetAssembly());
        }
    }
}