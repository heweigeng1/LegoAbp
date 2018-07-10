using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Users.Domain
{
    public class User : FullAuditedEntity<Guid>, IMayHaveTenant, IPassivable
    {
        #region 常量
        /// <summary>
        /// 用户名长度<see cref="UserName"/>最大长度
        /// </summary>
        public const int MaxUserNameLength = 256;
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
        /// 性别<see cref="EnumSex"/>
        /// </summary>
        public int Sex { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
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
