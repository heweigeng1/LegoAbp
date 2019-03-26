﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Core.Web.JwtBearer
{
    public class TokenAuthConfiguration
    {
        public SymmetricSecurityKey SecurityKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public TimeSpan Expiration { get; set; }
    }
}
