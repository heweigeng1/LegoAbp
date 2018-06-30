using Abp.Dependency;
using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LegoAbp.EntityFrameworkCore
{
    public class EntityConfigurationAssemblyFinder : FinderBase<Assembly>, IEntityConfigurationAssemblyFinder, ISingletonDependency
    {
        public ILegoAbpAssemblyFinder  _assemblyFinder;
        public EntityConfigurationAssemblyFinder(ILegoAbpAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }
        protected override Assembly[] FindAllItems()
        {
            Type baseType = typeof(IEntityRegister);
            Assembly[] assemblies = _assemblyFinder.FindAll();
            List<Type> entitys = new List<Type>();
            foreach (var item in assemblies)
            {
                var types = item.GetTypes();
                foreach (var type in types)
                {
                    if (baseType.IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        entitys.Add(type);
                    }
                }
            }
                //.Any(type => baseType.IsAssignableFrom(type) && !type.IsAbstract));
             return assemblies;
        }
    }
}
