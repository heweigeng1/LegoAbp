﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WxOpenApi.AppPay.Dtos;
using WxOpenApi.Config;
using WxOpenApi.Utils;
using Microsoft.AspNetCore.Http;
using Abp.Domain.Services;

namespace WxOpenApi.AppPay
{
    public class MobliePayManager : DomainService
    {
        private const string unifiedorderUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        IHttpContextAccessor contextAccessor;
        public MobliePayManager(IHttpContextAccessor _contextAccessor)
        {
            contextAccessor = _contextAccessor;
        }


        public void Nodify()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                contextAccessor.HttpContext.Request.Body.CopyTo(ms);
                byte[] bytes = ms.ToArray();
                string requestxml = Encoding.UTF8.GetString(bytes);
                string return_string = string.Empty;
                SortedDictionary<string, string> map = new SortedDictionary<string, string>();
                object obj = WxUtils.XmlDeserialize(typeof(MobilePayCallbackDto), requestxml);
                if (obj is MobilePayCallbackDto && ((MobilePayCallbackDto)obj).result_code == "SUCCESS")
                {
                    //成功则在此对订单执行操作
                    map.Add("return_code", "SUCCESS");
                    map.Add("return_msg", "");
                }
                else
                {
                    map.Add("return_code", "FAIL");
                    map.Add("return_msg", "统一下单失败");
                }
                string xml = map.SortedDictionaryToWxXml();
                var respbyte = Encoding.UTF8.GetBytes(xml);
                contextAccessor.HttpContext.Response.Body.Write(respbyte, 0, respbyte.Length);
            }

        }
        /// <summary>
        ///统一下单接口
        /// </summary>
        /// <param name="total_fee">订单金额</param>
        /// <param name="out_trade_no">订单号</param>
        /// <returns></returns>
        public MobilePayOutput Paying(string total_fee,string out_trade_no)
        {
            #region 统一下单map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},
                {"attach" , "wxpay" },
                {"body", "订单支付"},
                {"mch_id", WxConfig.MCH_ID },
                {"nonce_str", WxUtils.RandomStr(16)},
                {"notify_url", WxConfig.AppPayNodifyUrl},
                {"spbill_create_ip",""},//用户IP
                {"total_fee", total_fee},//金额
                {"trade_type","APP" },
                {"out_trade_no",out_trade_no}//订单号
            };
            #endregion

            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            #endregion

            #region 请求微信统一下单接口 获取预支付订单号
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            string callbackXml = WxUtils.PostToWxOpenApi(unifiedorderUrl,xml);//请求微信统一下单接口
            MobilePayCallbackDto callbackobj = (MobilePayCallbackDto)WxUtils.XmlDeserialize(typeof(MobilePayCallbackDto), callbackXml);
            #endregion

            #region 用户端sign
            MobilePayOutput output = new MobilePayOutput
            {
                appid = WxConfig.AppId,
                noncestr = WxUtils.RandomStr(16),
                package = "Sign=WXPay",
                partnerid = WxConfig.PARTNER_ID,
                prepayid = callbackobj.prepay_id,
                timestamp = DateTime.UtcNow.ToTimeStamp(),
                sign = "",
            };
            var appmap = WxUtils.ObjToSortedDictionary(output);
            string appmd5key = $@"{ appmap.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            output.sign = WxUtils.GetSign(appmd5key, "utf-8");
            #endregion
            return output;
        }
    }
}
