using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpTree.Domain
{
    public class AbpTreeEntity<T> : Entity<Guid>
    {
        public const int NodeNameMaxLength = 128;

        [StringLength(NodeNameMaxLength)]
        public string NodeName { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sorted { get; set; }
        public virtual Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<T> Child { get; set; }
    }
}
