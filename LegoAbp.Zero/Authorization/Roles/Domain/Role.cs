using Abp.Authorization.Roles;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LegoAbp.Zero.Authorization.Roles.Domain
{
    public  class Role : AbpRole<User>
    {

    }
}
