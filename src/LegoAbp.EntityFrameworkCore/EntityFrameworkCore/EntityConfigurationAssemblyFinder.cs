using LegoAbp.Reflection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    public class EntityConfigurationAssemblyFinder : FinderBase<Assembly>, IAssemblyFinder
    {
        public  IAssemblyFinder _allAssemblyFinder;
        public EntityConfigurationAssemblyFinder(IAssemblyFinder allAssemblyFinder)
        {
            _allAssemblyFinder = allAssemblyFinder;
        }
        protected override Assembly[] FindAllItems()
        {
            Type baseType = typeof(IEntityRegister);
            Assembly[] assemblies = _allAssemblyFinder.FindAll();
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
