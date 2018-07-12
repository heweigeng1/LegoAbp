using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LegoAbp.Zero.Users.Domain;
using System;

namespace LegoAbp.Zero.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto : FullAuditedEntityDto<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
