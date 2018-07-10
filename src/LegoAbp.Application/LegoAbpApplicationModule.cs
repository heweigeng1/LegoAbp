using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Zero;

namespace LegoAbp
{
    [DependsOn(
        typeof(LegoAbpCoreModule),
        typeof(AbpAutoMapperModule))]
    public class LegoAbpApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {

            base.PreInitialize();
        }
        public override void Initialize()
        {
            var assembly = typeof(LegoAbpApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(assembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
               // Scan the assembly for classes which inherit from AutoMapper.Profile
               cfg => cfg.AddProfiles(assembly));
        }
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}