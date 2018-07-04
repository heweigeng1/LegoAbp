using Abp.Application.Services;
using Abp.Domain.Repositories;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Users.Dto;
using LegoAbp.Zero.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Users
{
    public class UserAppService : AsyncCrudAppService<User,UserDto,Guid>, IUserAppService
    {
        public IRepository<User, Guid> _repository;
        public IRepository<UserA, Guid> _userAsrepository;
        public UserAppService(IRepository<User, Guid> repository):base(repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public string Test1(string id)
        {
            return "hello world";
        }
    }
}
