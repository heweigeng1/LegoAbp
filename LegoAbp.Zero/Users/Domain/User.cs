using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users.Domain
{
    public class User : FullAuditedEntity<Guid>, IMayHaveTenant, IPassivable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int? TenantId { get; set; }
    }
}
