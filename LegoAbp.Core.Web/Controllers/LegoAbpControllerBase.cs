using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Core.Web.Controllers
{
    public abstract class LegoAbpControllerBase : AbpController
    {
        protected LegoAbpControllerBase()
        {
            LocalizationSourceName = LegoAbpConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
