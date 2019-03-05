using Abp.Domain.Entities;
using LegoAbp.Entites;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class Tenant : LegoAbpEntityBase<int>, IPassivable, IStartTimeToEndTime
    {
        /// <summary>
        /// 商户名<see cref="TenantName"/>长度
        /// </summary>
        public const int MaxTenantNameLength = 32;
        /// <summary>
        /// 商户名规则
        /// </summary>
        public const string TenancyNameRegex = "^[a-zA-Z][a-zA-Z0-9_-]{1,}$";
        /// <summary>
        /// 商户号<see cref="TenantCode"/>长度
        /// </summary>
        public const int MaxTenantCodeLength = 12;
        /// <summary>
        /// 商户名
        /// </summary>
        [StringLength(MaxTenantNameLength)]
        public string TenantName { get; set; }
        /// <summary>
        /// 商户编号
        /// </summary>
        [StringLength(MaxTenantCodeLength)]
        public string TenantCode { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }
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
