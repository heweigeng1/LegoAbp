using Abp.Application.Services.Dto;
using AbpTree.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpTree.Dtos
{
    public class AbpTreeDto<T> : EntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        [StringLength(AbpTreeEntity<T>.NodeNameMaxLength)]
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
        public List<T> Child { get; set; }
    }
}
