using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WxOpenApi.AppPay.Dtos;

namespace WxOpenApi.AppPay
{
    public interface IMobliePayAppService
    {
        [HttpPost]
        PayingOutput Paying();
    }
}
