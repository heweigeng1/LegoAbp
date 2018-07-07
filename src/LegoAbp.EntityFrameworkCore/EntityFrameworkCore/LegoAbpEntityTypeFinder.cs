using Abp.Dependency;
using Abp.Domain.Entities;
using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpEntityTypeFinder : FinderBase<Type>, ILegoAbpEntityTypeFinder, ITransientDependency
    {
        private readonly IAppDomainAllAssemblyFinder _assemblyFinder;
        public LegoAbpEntityTypeFinder(IAppDomainAllAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }
        protected override Type[] FindAllItems()
        {
            Type[] baseType = new Type[] { typeof(Entity<>), typeof(Entity) };
            //Type type = typeof(UserA);
            Type type2 = typeof(Entity<>);
            var types = _assemblyFinder.FindAll();
            List<Type> ts2 = new List<Type>();

            foreach (var item in types)
            {
                var ts = item.GetTypes();
                foreach (var t in ts)
                {
                    if (t.IsSubclassOf(type2))
                    {
                        ts2.Add(t);
                    }
                }
            }
            //var types2 = types.Where(c => baseType.Any(bt => c.IsAssignableFrom(bt))).ToArray();
            return ts2.ToArray();
        }
    }
}
