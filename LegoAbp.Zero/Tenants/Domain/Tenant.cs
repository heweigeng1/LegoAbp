using Abp.Domain.Entities;
using Abp.MultiTenancy;
using LegoAbp.Entites;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class Tenant : AbpTenant<User>
    {
        /// <summary>
        /// 商户名<see cref="Name"/>长度
        /// </summary>
        public const int MaxTenantNameLength = 32;
        /// <summary>
        /// 商户号<see cref="TenantCode"/>长度
        /// </summary>
        public const int MaxTenantCodeLength = 12;
        /// <summary>
        /// 商户编号
        /// </summary>
        [StringLength(MaxTenantCodeLength)]
        [Required]
        public string TenantCode { get; set; }
        /// <summary>
        /// LOGO路径
        /// </summary>
        [StringLength(EntityCommonConst.MaxFileNameLength)]
        public string LogoPath { get; set; }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyProfile { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(EntityCommonConst.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }
        [StringLength(EntityCommonConst.MaxPhoneNumberLength)]
        public string QQNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(EntityCommonConst.MaxAddressLength)]
        public string Address { get; set; }
        /// <summary>
        /// 开始付费或测试时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 测试或付费到期时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
