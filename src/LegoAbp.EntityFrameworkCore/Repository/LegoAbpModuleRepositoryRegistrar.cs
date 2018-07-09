using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using LegoAbp.EntityFrameworkCore;

namespace LegoAbp.Repository
{
    public class LegoAbpModuleRepositoryRegistrar : ILegoAbpModuleRepositoryRegistrar, ITransientDependency
    {
        private readonly ITestEfGenericRepositoryRegistrar _repositoryRegistrar;
        private readonly IIocManager _iocManager;
        public LegoAbpModuleRepositoryRegistrar(ITestEfGenericRepositoryRegistrar repositoryRegistrar, IIocManager iocManager)
        {
            _repositoryRegistrar = repositoryRegistrar;
            _iocManager = iocManager;
        }
        public void ModuleRepositoryRegistrar(Assembly assembly)
        {
            Type baseType = typeof(IEntityRegister);
            var entityTypes = assembly.GetTypes().Where(c => baseType.IsAssignableFrom(c));
            foreach (var item in entityTypes)
            {
                var info = item.GetTypeInfo().BaseType.GenericTypeArguments;
                var info3 = item.GetProperties();
                //var primaryKeyType = EntityHelper.GetPrimaryKeyType(info.EntityType);
            }
        }
        private void RegistraTo(Type dbContextType,
            IIocManager iocManager,
            Type repositoryInterface,
            Type repositoryInterfaceWithPrimaryKey,
            Type repositoryImplementation,
            Type repositoryImplementationWithPrimaryKey
            )
        {

        }
    }
}
