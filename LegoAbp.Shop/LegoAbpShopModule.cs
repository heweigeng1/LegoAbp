using Abp.AutoMapper;
using Abp.Modules;
using LegoAbp.Zero;
using System.Reflection;

namespace LegoAbp.Shop
{

    [DependsOn(
        typeof(LegoAbpZeroModule),
        typeof(LegoAbpCoreModule),
        typeof(AbpAutoMapperModule)
        )]
    public class LegoAbpShopModule : AbpModule
    {

        public override void PreInitialize()
        {
            //Configuration.Settings.Providers.Add<BodeAbpProductSettingProvider>();
            //Configuration.Authorization.Providers.Add<BodeAbpProductAuthorizationProvider>();
            //DefaultDbContextInitializer.Instance.MapperAssemblies.Add(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 初始化后执行
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
