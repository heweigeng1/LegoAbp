using Abp.Dependency;
using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LegoAbp.EntityFrameworkCore
{
    public class EntityConfigurationAssemblyFinder : FinderBase<Assembly>, IEntityConfigurationAssemblyFinder, ISingletonDependency
    {
        public IAppDomainAllAssemblyFinder _assemblyFinder;
        public EntityConfigurationAssemblyFinder(IAppDomainAllAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }
        protected override Assembly[] FindAllItems()
        {
            Type baseType = typeof(IEntityRegister);
            //获取所有继承IEntityRegister 的反射结果集
            Assembly[] assemblies = _assemblyFinder.FindAll().Where(a => a.GetTypes().Any(c => baseType.IsAssignableFrom(c) && c.IsAbstract)).ToArray();
            return assemblies;
        }
    }
}
