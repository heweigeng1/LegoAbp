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

        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
