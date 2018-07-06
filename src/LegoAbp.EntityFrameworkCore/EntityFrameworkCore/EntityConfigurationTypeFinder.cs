using Abp;
using Abp.Dependency;
using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoAbp.EntityFrameworkCore
{
    public class EntityConfigurationTypeFinder : FinderBase<Type>, IEntityConfigurationTypeFinder, ITransientDependency
    {
        private IEntityConfigurationAssemblyFinder _assemblyFinder;
        private Dictionary<Type, IEntityRegister[]> _entityRegistersDict;
        public EntityConfigurationTypeFinder(IEntityConfigurationAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }

        /// <summary>
        /// 获取 各个上下文的实体注册信息字典
        /// </summary>
        protected Dictionary<Type, IEntityRegister[]> EntityRegistersDict
        {
            get
            {
                if (_entityRegistersDict == null)
                {
                    Type[] types = FindAll(true);
                    EntityRegistersInit(types);
                }
                return _entityRegistersDict;
            }
        }

        /// <summary>
        /// 获取指定上下文类型的实体配置注册信息
        /// </summary>
        /// <param name="dbContextType">数据上下文类型</param>
        /// <returns></returns>
        public IEntityRegister[] GetEntityRegisters(Type dbContextType)
        {
            return EntityRegistersDict.ContainsKey(dbContextType) ? EntityRegistersDict[dbContextType] : new IEntityRegister[0];
        }

        /// <summary>
        /// 获取 实体类所属的数据上下文类
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns>数据上下文类型</returns>
        public Type GetDbContextTypeForEntity(Type entityType)
        {
            var dict = EntityRegistersDict;
            if (dict.Count == 0)
            {
                throw new AbpException($"未发现任何数据上下文实体映射配置，请通过对各个实体继承基类“EntityTypeConfigurationBase<TEntity, TKey>”以使实体加载到上下文中");
            }
            foreach (var item in EntityRegistersDict)
            {
                if (item.Value.Any(m => m.EntityType == entityType))
                {
                    return item.Key;
                }
            }
            throw new AbpException($"无法获取实体类“{entityType}”的所属上下文类型，请通过继承基类“EntityTypeConfigurationBase<TEntity, TKey>”配置实体加载到上下文中");
        }

        protected override Type[] FindAllItems()
        {
            Type baseType = typeof(IEntityRegister);
            Type[] types = _assemblyFinder.FindAll()
                .SelectMany(assembly => assembly.GetTypes().Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract && type.IsPublic))
                .ToArray();
            return types;
        }
        /// <summary>
        /// 初始化实体映射对象字典
        /// </summary>
        /// <param name="types"></param>
        private void EntityRegistersInit(Type[] types)
        {
            if (types.Length == 0)
            {
                if (_entityRegistersDict == null)
                {
                    _entityRegistersDict = new Dictionary<Type, IEntityRegister[]>();
                }
                return;
            }
            List<IEntityRegister> registers = types.Select(type => Activator.CreateInstance(type) as IEntityRegister).ToList();
            Dictionary<Type, IEntityRegister[]> dict = new Dictionary<Type, IEntityRegister[]>();
            List<IGrouping<Type, IEntityRegister>> groups = registers.GroupBy(m => m.DbContextType).ToList();
            Type key;
            foreach (IGrouping<Type, IEntityRegister> group in groups)
            {
                key = group.Key ?? typeof(LegoAbpDbContext);
                List<IEntityRegister> list = new List<IEntityRegister>();
                if (group.Key == null || group.Key == typeof(LegoAbpDbContext))
                {
                    list.AddRange(group);
                }
                else
                {
                    list = group.ToList();
                }
                if (list.Count > 0)
                {
                    dict[key] = list.ToArray();
                }
            }
            //添加框架的一些默认实体的实体映射信息（如果不存在）
           
            _entityRegistersDict = dict;
        }

    }
}
