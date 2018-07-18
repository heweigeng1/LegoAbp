using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Repository;
using LegoAbp.Zero;
using System.Reflection;

namespace LegoAbp.Zero
{
    [DependsOn(
        typeof(LegoAbpEntityFrameworkCoreModule),
        typeof(LegoAbpCoreModule),
        typeof(AbpTreeModule),
        typeof(AbpAutoMapperModule)
        )]
    public class LegoAbpZeroModule : AbpModule
    {
        public override void PreInitialize()
        {
            //配置Identity本地化文件
            Configuration.Localization.Sources.Extensions.Add(
                new LocalizationSourceExtensionInfo(
                    LegoAbpZeroConsts.LocalizationIdentitySourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LegoAbpZeroModule).GetAssembly(), "LegoAbp.Zero.Authorization.Identity.Localization.SourceExt"
                    )
                )
            );
            var b = new XmlEmbeddedFileLocalizationDictionaryProvider(
                       typeof(LegoAbpZeroModule).GetAssembly(), "LegoAbp.Zero.Authorization.Identity.Localization.SourceExt"
                   );
            var r = new XmlEmbeddedFileLocalizationDictionaryProvider(
                         typeof(LegoAbpZeroModule).GetAssembly(), "LegoAbp.Zero.Localization.Source"
                     );
            //添加租户的本地化文本
            Configuration.Localization.Sources.Extensions.Add(
               new LocalizationSourceExtensionInfo(
                   LegoAbpZeroConsts.LocalizationSourceName,
                   new XmlEmbeddedFileLocalizationDictionaryProvider(
                       typeof(LegoAbpZeroModule).GetAssembly(), "LegoAbp.Zero.Localization.Source"
                   )
               )
           );
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(LegoAbpZeroModule).Assembly, moduleName: "app", useConventionalHttpVerbs: true);
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(assembly);
            //注册通用IRepository
            IocManager.Resolve<ILegoAbpModuleRepositoryRegistrar>().ModuleRepositoryRegistrar(assembly);
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
