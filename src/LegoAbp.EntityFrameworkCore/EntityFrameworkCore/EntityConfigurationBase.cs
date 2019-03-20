﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.EntityFrameworkCore
{
    /// <summary>
    /// 数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public abstract class EntityConfigurationBase<TEntity, TKey> : IEntityTypeConfiguration<TEntity>, IEntityRegister
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 获取 所属的上下文类型，如为null，将使用默认上下文， 否则使用指定类型的上下文类型
        /// </summary>
        public virtual Type DbContextType => null;

        /// <summary>
        /// 获取 相应的实体类型
        /// </summary>
        public Type EntityType => typeof(TEntity);

        /// <summary>
        /// 获取主键类型
        /// </summary>
        public Type EntityKey => typeof(TKey);
        /// <summary>
        /// 将当前实体类映射对象注册到数据上下文模型构建器中
        /// </summary>
        /// <param name="modelBuilder">上下文模型构建器</param>
        public virtual void RegistTo(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
