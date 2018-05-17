using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users
{
    public interface IUserAppService<TEntityDto,TPrimaryKey,TGetAllInput,TCreatedInput>:IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput,TCreatedInput>
        where TCreatedInput:IEntityDto<TPrimaryKey>
        where TEntityDto:IEntityDto<TPrimaryKey>
    {
    }
}
