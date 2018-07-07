using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LegoAbp.Zero.Users
{
    public class User : FullAuditedEntity<Guid>, IMayHaveTenant, IPassivable
    {
        /// <summary>
        /// Maximum length of the <see cref="UserName"/> property.
        /// </summary>
        public const int MaxUserNameLength = 256;
        /// <summary>
        /// 密码长度
        /// </summary>
        public const int MaxPasswordLength = 128;

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }
        public string Test { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(MaxPasswordLength)]
        public virtual string Password { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
