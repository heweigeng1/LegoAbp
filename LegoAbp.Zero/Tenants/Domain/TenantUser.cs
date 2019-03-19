using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LegoAbp.Entites;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Tenants.Domain
{
    /// <summary>
    /// 租户用户表
    /// </summary>
    public class TenantUser : IHasCreationTime, IHasModificationTime, ISoftDelete, IPhoneNumber
    {
        public int TenantId { get; set; }
        public long UserId { get; set; }
        [StringLength(EntityCommonConst.MaxNameLength)]
        public string NickName { get; set; }
        [StringLength(EntityCommonConst.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
