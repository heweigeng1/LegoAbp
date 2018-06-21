using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbpTree.Domain
{
    public class TreeManager<TreeEntity> :  ISingletonDependency where TreeEntity : AbpTreeEntity<TreeEntity> 
    {
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<TreeEntity, Guid> _repository;
        public TreeManager(IRepository<TreeEntity, Guid> repository, ICacheManager cacheManager)
        {
            _repository = repository;
            _cacheManager = cacheManager;
        }

        public List<TreeEntity> GetAllListCache()
        {
            var cache = _cacheManager.GetCache("AbpTreeCache");
            return cache.Get("allTreeItem", () => { return _repository.GetAllList(); });
        }
        public TreeEntity InitTree(List<TreeEntity> list, TreeEntity entity)
        {
            RecursionToChild(list, entity);
            return entity;
        }
        public void BrotherNode()
        {

        }
        public void LevelNode()
        {

        }
        /// <summary>
        /// 递归填充树
        /// </summary>
        /// <param name="list">基础list</param>
        /// <param name="entity">要构筑的树</param>
        private void RecursionToChild(List<TreeEntity> list, TreeEntity entity)
        {
            var data = list.Where(c => c.ParentId == entity.Id).ToList();
            entity.Child = new List<TreeEntity>();
            if (data!=null)
            {
                entity.Child = data;
                foreach (var item in data)
                {
                    RecursionToChild(list, item);
                }
            }
        }
    }
}
