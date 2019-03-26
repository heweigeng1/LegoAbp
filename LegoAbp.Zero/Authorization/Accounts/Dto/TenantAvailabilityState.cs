using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Accounts.Dto
{
    public enum TenantAvailabilityState
    {
        Available = 1,
        InActive,
        NotFound
    }
}
