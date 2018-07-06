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
            Type[] baseType = new Type[] { typeof(IEntity<>), typeof(IEntity) };
            var types = _assemblyFinder.FindAll();
            foreach (var item in types)
            {
                var ts = item.GetTypes();
                foreach (var t in ts)
                {
                    if (baseType[0].IsAssignableFrom(t))
                    {
                        var a = t;
                    }
                }
            }
            //var types2 = types.Where(c => baseType.Any(bt => c.IsAssignableFrom(bt))).ToArray();
            return baseType;
        }
    }
}
