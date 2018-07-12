﻿using Abp.Application.Services;
using Abp.Domain.Services;
using LegoAbp.Zero.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto,Guid,SearchUserInput,CreateUser,UserDto>
    {
    }
}