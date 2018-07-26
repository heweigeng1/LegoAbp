using Abp.Domain.Entities;
using LegoAbp.Entites;
using LegoAbp.Zero.Authorization.Roles.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class User : LegoAbpEntityBase<Guid>, IMayHaveTenant, IPassivable
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
        /// 手机号<see cref="PhoneNum"/>最大长度
        /// </summary>
        public const int MaxPhoneNumLength = 16;
        /// <summary>
        /// Maximum length of the <see cref="EmailAddress"/> property.
        /// </summary>
        public const int MaxEmailAddressLength = 256;
        #endregion

        #region 属性
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }
        [StringLength(MaxPhoneNumLength)]
        public string PhoneNum { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(MaxPasswordLength)]
        public virtual string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(MaxEmailAddressLength)]
        public virtual string NormalizedEmailAddress { get; set; }
        /// <summary>
        /// 性别<see cref="EnumSex"/>
        /// </summary>
        public int Sex { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserClaim> Claims { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserLogin> Logins { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserRole> Roles { get; set; }
        #endregion

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
