using Abp.Application.Services;
using LegoAbp.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Users
{
    public interface IUserAppService: IAsyncCrudAppService<UserDto, Guid>
    {

    }
}
