using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LegoAbp.Utils;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegoAbp.Zero.Authorization.Users.Dto
{
    [AutoMap(typeof(User))]
    public class CreateUser : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(User.MaxUserNameLength)]
        public string UserName { get; set; }
        [StringLength(User.MaxPasswordLength, MinimumLength = User.MinPasswordLength, ErrorMessage = "密码长度不正确!")]
        public string Password { get; set; }
        [RegularExpression(RegularExpressionHelper.IsPhoneNumer, ErrorMessage = "手机号格式不正确!")]
        public string PhoneNum { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
