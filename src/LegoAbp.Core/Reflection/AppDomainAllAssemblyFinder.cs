using Abp.Dependency;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LegoAbp.Reflection
{
    public class AppDomainAllAssemblyFinder : FinderBase<Assembly>, IAssemblyFinder, ISingletonDependency
    {
        protected override Assembly[] FindAllItems()
        {
            string[] filters =
            {
                "System",
                "Microsoft",
                "netstandard",
                "dotnet",
                "Window",
                "mscorlib"
            };
            DependencyContext context = DependencyContext.Default;
            List<string> names = new List<string>();
            string[] dllNames = context.CompileLibraries.SelectMany(m => m.Assemblies).Distinct().Select(m => m.Replace(".dll", "")).ToArray();
            names = (from name in dllNames
                     let i = name.LastIndexOf('/') + 1
                     select name.Substring(i, name.Length - i)).Where(c => !filters.Any(c.StartsWith))
                     .Distinct()
                .ToList();
            return LoadFiles(names);
        }
        private static Assembly[] LoadFiles(IEnumerable<string> files)
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (string file in files)
            {
                AssemblyName name = new AssemblyName(file);
                try
                {
                    assemblies.Add(Assembly.Load(name));
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies.ToArray();
        }
    }
}
