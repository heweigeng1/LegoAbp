using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Utils
{
    public static class RegularExpressionHelper
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public const string IsEmaill = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        /// <summary>
        /// URL地址
        /// </summary>
        public const string IsUrl = @"[a-zA-z]+://[^\s]*";
        /// <summary>
        /// 整数
        /// </summary>
        public const string IsNum = @"^-?[1-9]\d*$";
        /// <summary>
        /// 手机号
        /// </summary>
        public const string IsPhoneNum = @"^[1]\d{10}$";
    }
}
