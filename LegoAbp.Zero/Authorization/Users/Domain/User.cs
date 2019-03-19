using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LegoAbp.Entites;
using LegoAbp.Zero.Authorization.Roles.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class User : AbpUser<User>
    {
        #region 常量
        /// <summary>
        /// 密码<see cref="Password"/>最短位数
        /// </summary>
        public const int MinPasswordLength = 6;
        /// <summary>
        /// Maximum length of the <see cref="EmailAddress"/> property.
        /// </summary>
        #endregion

        #region 属性
        /// <summary>
        /// 性别<see cref="EnumSex"/>
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 邮箱/>
        /// </summary>
        public new string EmailAddress { get; set; }
        /// <summary>
        /// 规范化邮箱地址(大写)
        /// </summary>
        public new string NormalizedEmailAddress { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public new string Surname { get; set; }
        #endregion
        public enum EnumSex
        {
            女,
            男
        }
        public enum EnumUserType
        {
            商户,
            Host,
        }
    }
}
