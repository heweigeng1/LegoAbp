using Abp.Dependency;
using Abp.EntityFramework.Repositories;
using System.Reflection;

namespace LegoAbp.Repository
{
    public interface ILegoAbpModuleRepositoryRegistrar
    {
        void ModuleRepositoryRegistrar(Assembly assembly);
    }
}
