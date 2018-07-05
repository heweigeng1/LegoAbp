using Abp.Dependency;
using Abp.Domain.Entities;
using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpEntityTypeFinder : FinderBase<Type>, ILegoAbpEntityTypeFinder
    {
        private readonly ILegoAbpAssemblyFinder _assemblyFinder;
        public LegoAbpEntityTypeFinder(ILegoAbpAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }
        protected override Type[] FindAllItems()
        {
            Type[] baseType = new Type[] { typeof(IEntity<>), typeof(IEntity) };
            var types = _assemblyFinder.FindAll().Select(a => a.GetType()).ToArray();
            return baseType;
        }
    }
}
