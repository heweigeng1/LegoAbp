using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using LegoAbp.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace LegoAbp.Repository
{
    public class LegoAbpModuleRepositoryRegistrar : ILegoAbpModuleRepositoryRegistrar, ITransientDependency
    {
        private readonly IIocManager _iocManager;
        public LegoAbpModuleRepositoryRegistrar(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        public void ModuleRepositoryRegistrar(Assembly assembly)
        {
            Type baseType = typeof(IEntityRegister);
            var entityTypes = assembly.GetTypes().Where(c => baseType.IsAssignableFrom(c));
            Type contextType = typeof(LegoAbpDbContext);
            var autoRepositoryAttr = contextType.GetTypeInfo().GetSingleAttributeOrNull<AutoRepositoryTypesAttribute>() ?? EfCoreAutoRepositoryTypes.Default;
            foreach (var item in entityTypes)
            {
                var info = item.GetTypeInfo().BaseType.GenericTypeArguments;
                Type entityType = info[0];
                Type key = info[1];
                if (key == typeof(int))
                {
                    var genericRepositoryType = autoRepositoryAttr.RepositoryInterface.MakeGenericType(entityType);
                    if (!_iocManager.IsRegistered(genericRepositoryType))
                    {
                        var implType = autoRepositoryAttr.RepositoryImplementation.GetGenericArguments().Length == 1
                            ? autoRepositoryAttr.RepositoryImplementation.MakeGenericType(entityType)
                            : autoRepositoryAttr.RepositoryImplementation.MakeGenericType(contextType,
                                entityType);

                        _iocManager.IocContainer.Register(
                            Component
                                .For(genericRepositoryType)
                                .ImplementedBy(implType)
                                .Named(Guid.NewGuid().ToString("N"))
                                .LifestyleTransient()
                        );
                    }
                }

                var genericRepositoryTypeWithPrimaryKey = autoRepositoryAttr.RepositoryInterfaceWithPrimaryKey.MakeGenericType(entityType, key);
                if (!_iocManager.IsRegistered(genericRepositoryTypeWithPrimaryKey))
                {
                    var implType = autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.GetGenericArguments().Length == 2
                        ? autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.MakeGenericType(entityType, key)
                        : autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.MakeGenericType(contextType, entityType, key);

                    _iocManager.IocContainer.Register(
                        Component
                            .For(genericRepositoryTypeWithPrimaryKey)
                            .ImplementedBy(implType)
                            .Named(Guid.NewGuid().ToString("N"))
                            .LifestyleTransient()
                    );
                }
            }
        }

    }
}
