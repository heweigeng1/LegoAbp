﻿using LegoAbp.Utils;
using LegoAbp.Zero.Authorization.Users.Domain;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Authorization.Accounts.Dto
{
    public class PhoneNumberRegisterInput
    {
        [RegularExpression(RegularExpressionHelper.IsPhoneNumer, ErrorMessage = "手机号格式不正确!")]
        public string PhoneNumber { get; set; }
        [StringLength(User.MaxPasswordLength, MinimumLength = User.MinPasswordLength, ErrorMessage = "密码最低为6位")]
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
