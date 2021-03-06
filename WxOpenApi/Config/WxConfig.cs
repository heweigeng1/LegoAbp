﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WxOpenApi.Config
{
   public class WxConfig
    {
        public static string AppId = "APPID";
        public static string APP_SECRET = @"APP_SECRET"; //appsecret
        public static string MCH_ID = @"MCH_ID";
        public static string PARTNER_ID = @"PARTNER_ID";

        /// <summary>
        /// 移动支付回调接口
        /// </summary>
        public static string AppPayNodifyUrl = "不含参数的回调接口";
        /// <summary>
        /// 刷卡支付回调接口
        /// </summary>
        public static string PayByCardNodifyUrl = "不含参数的回调接口";
        
    }
}
