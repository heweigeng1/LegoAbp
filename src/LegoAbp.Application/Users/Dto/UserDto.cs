using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LegoAbp.Zero.Users;
using System;

namespace LegoAbp.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto: EntityDto<Guid>
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
