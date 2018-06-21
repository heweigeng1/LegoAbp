using System;
using System.Collections.Generic;
using System.Text;

namespace WxOpenApi.AppPay.Dtos
{
    public class PayingInput
    {
        public string Spbill_Create_Ip { get; set; }
        public Guid UserId { get; set; }
        public string Amount { get; set; }
        public int PayType { get; set; }
    }
}
