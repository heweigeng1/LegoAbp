using Abp.Collections.Extensions;
using Abp.Dependency;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.EntityFrameworkCore.Uow;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using System;
using System.Reflection;

namespace LegoAbp.EntityFrameworkCore
{
    [DependsOn(
        typeof(LegoAbpCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class LegoAbpEntityFrameworkCoreModule : AbpModule
    {
        private readonly ITypeFinder _typeFinder;

        public LegoAbpEntityFrameworkCoreModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public override void PreInitialize()
        {
            //IocManager.IocContainer.Register(Component.For(typeof(IDbContextProvider<>)).ImplementedBy(typeof(UnitOfWorkDbContextProvider<>)).LifestyleTransient());

          
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            var ass = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpEntityFrameworkCoreModule).GetAssembly());
            RegisterGenericRepositoriesAndMatchDbContexes();
        }

        /// <summary>
        /// 初始化后执行
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        private void RegisterGenericRepositoriesAndMatchDbContexes()
        {
            var dbContextTypes =
                _typeFinder.Find(type =>
                {
                    var typeInfo = type.GetTypeInfo();
                    return typeInfo.IsPublic &&
                           !typeInfo.IsAbstract &&
                           typeInfo.IsClass &&
                           typeof(AbpDbContext).IsAssignableFrom(type);
                });

            if (dbContextTypes.IsNullOrEmpty())
            {
                Logger.Warn("No class found derived from AbpDbContext.");
                return;
            }

            using (IScopedIocResolver scope = IocManager.CreateScope())
            {
                foreach (var dbContextType in dbContextTypes)
                {
                    Logger.Debug("Registering DbContext: " + dbContextType.AssemblyQualifiedName);

                    var re = scope.Resolve<ITestEfGenericRepositoryRegistrar>();
                    re.RegisterForDbContext(dbContextType, IocManager, EfCoreAutoRepositoryTypes.Default);
                    IocManager.IocContainer.Register(
                        Component.For<ISecondaryOrmRegistrar>()
                            .Named(Guid.NewGuid().ToString("N"))
                            .Instance(new EfCoreBasedSecondaryOrmRegistrar(dbContextType, scope.Resolve<IDbContextEntityFinder>()))
                            .LifestyleTransient()
                    );
                }

                scope.Resolve<IDbContextTypeMatcher>().Populate(dbContextTypes);
            }
        }
    }
}