using Abp.Application.Services;
using Abp.Domain.Services;
using LegoAbp.Zero.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto,Guid,SearchUserInput,CreateUserInput,UserDto>
    {
    }
}
