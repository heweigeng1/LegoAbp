using Abp.Dependency;
using System.Reflection;

namespace LegoAbp.Reflection
{
    public interface IAppDomainAllAssemblyFinder : ILegoAbpFinder<Assembly>
    {
    }
}
