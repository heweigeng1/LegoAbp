using Abp.Domain.Services;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public interface IAccountAppService : IDomainService
    {
        /// <summary>
        /// 手机注册
        /// </summary>
        void RegisterByPhone(PhoneNumberRegisterInput input);
        /// <summary>
        /// 登录
        /// </summary>
        void Login();
        /// <summary>
        /// 注销
        /// </summary>
        void Logout();
    }
}
