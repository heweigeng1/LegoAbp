using Abp.Domain.Entities;
using LegoAbp.Entites;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class Tenant : LegoAbpEntityBase<int>, IPassivable
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
        public bool IsActive { get; set; }
    }
}
