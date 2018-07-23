using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public interface IAccountAppService : IDomainService
    {
        /// <summary>
        /// 注册
        /// </summary>
        void Register();
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
