using Abp.Dependency;
using Abp.EntityFramework.Repositories;
using System.Reflection;

namespace LegoAbp.Repository
{
    public interface ILegoAbpModuleRepositoryRegistrar
    {
        /// <summary>
        /// 注册所有继承IEntityRegister 的Map的实体到通用IRepository
        /// </summary>
        /// <param name="assembly"></param>
        void ModuleRepositoryRegistrar(Assembly assembly);
    }
}
