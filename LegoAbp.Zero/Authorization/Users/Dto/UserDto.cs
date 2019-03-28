using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;

namespace LegoAbp.Zero.Authorization.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto : FullAuditedEntityDto<long>
    {
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
