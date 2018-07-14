using Abp.Domain.Repositories;
using LegoAbp.Paged;
using LegoAbp.Zero.Users.Domain;
using LegoAbp.Zero.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using System;

namespace LegoAbp.Zero.Users
{

    public class UserAppService: AsyncLegoAbpCrudAppService<User,UserDto,Guid,SearchUserInput,CreateUser,UserDto>,IUserAppService
    {
        private readonly IRepository<User, Guid> _repository;
        public UserAppService(IRepository<User, Guid> repository) : base(repository)
        {
            _repository = repository;
        }
        public string Test()
        {
            return "hi app";
        }
    }
}
