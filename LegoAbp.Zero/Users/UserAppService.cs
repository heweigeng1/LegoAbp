using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LegoAbp.Zero.Common.Paged;
using LegoAbp.Zero.Users.Domain;
using LegoAbp.Zero.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users
{
    public class UserAppService:AsyncCrudAppService<User,UserDto,Guid, PagedAndSortedResultRequestDto, CreatedUserInput>,IUserAppService< UserDto, Guid, PagedAndSortedResultRequestDto, CreatedUserInput>
    {
        private readonly IRepository<User, Guid> _repository;
       public UserAppService(IRepository<User, Guid> repository) :base(repository)
        {
            _repository = repository;
        }
    }
}
