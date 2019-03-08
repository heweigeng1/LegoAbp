﻿using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    //public class AbpUserManager : UserManager<User>
    public class LegoAbpUserManager : UserManager<User>, IDomainService, ITransientDependency
    {
        private readonly IRepository<User, long> _userRepository;
        public LegoAbpUserManager(IRepository<User, long> userRepository, 
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services,
            ILogger<UserManager<User>> logger) : base(store,
                optionsAccessor,
                passwordHasher,
                userValidators,
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                logger)
        {
            _userRepository = userRepository;
        }
    }
}
