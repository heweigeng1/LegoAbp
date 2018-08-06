using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LegoAbp.Entites;
using LegoAbp.Zero.Authorization.Roles.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class User : LegoAbpEntityBase<Guid>, IMayHaveTenant, IPassivable, IHasCreationTime, IHasModificationTime, ISoftDelete
    {
        #region 常量
        /// <summary>
        /// 用户名长度<see cref="UserName"/>最大长度
        /// </summary>
        public const int MaxUserNameLength = 128;
        /// <summary>
        /// 密码<see cref="Password"/>最大长度
        /// </summary>
        public const int MaxPasswordLength = 128;
        /// <summary>
        /// 密码<see cref="Password"/>最短位数
        /// </summary>
        public const int MinPasswordLength = 6;
        /// <summary>
        /// 手机号<see cref="PhoneNumber"/>最大长度
        /// </summary>
        public const int MaxPhoneNumLength = 16;
        /// <summary>
        /// Maximum length of the <see cref="EmailAddress"/> property.
        /// </summary>
        public const int MaxEmailAddressLength = 256;
        /// <summary>
        /// Maximum length of the <see cref="SecurityStamp"/> property.
        /// </summary>
        public const int MaxSecurityStampLength = 128;
        #endregion

        #region 属性
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }
        [StringLength(MaxPhoneNumLength)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 是否验证过手机
        /// </summary>
        public virtual bool IsPhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(MaxPasswordLength)]
        public virtual string Password { get; set; }
        /// <summary>
        /// 统一规则用户名
        /// </summary>
        [StringLength(MaxUserNameLength)]
        public virtual string NormalizedUserName { get; set; }
        /// <summary>
        /// 统一规则邮箱
        /// </summary>
        [StringLength(MaxEmailAddressLength)]
        public virtual string NormalizedEmailAddress { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string EmailAddress { get; set; }
        /// <summary>
        ///邮箱是否验证 <see cref="EmailAddress"/> .
        /// </summary>
        public virtual bool IsEmailConfirmed { get; set; }
        /// <summary>
        /// 安全标记.
        /// </summary>
        [StringLength(MaxSecurityStampLength)]
        public virtual string SecurityStamp { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public virtual bool IsLockoutEnabled { get; set; }
        /// <summary>
        /// 锁定结束时间
        /// </summary>
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        /// <summary>
        /// 性别<see cref="EnumSex"/>
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 访问失败计数
        /// </summary>
        public virtual int AccessFailedCount { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserClaim> Claims { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserLogin> Logins { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserRole> Roles { get; set; }
        #endregion
        /// <summary>
        /// 统一规则
        /// </summary>
        public void SetNormalizedNames()
        {
            NormalizedUserName = UserName.ToUpperInvariant();
            NormalizedEmailAddress = EmailAddress.ToUpperInvariant();
        }
        public enum EnumSex
        {
            女,
            男
        }
        public enum EnumUserType
        {
            普通用户,
            商户,
            管理员,
        }
    }
}
