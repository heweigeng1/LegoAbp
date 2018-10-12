using Abp.Domain.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WxOpenApi.Config;
using WxOpenApi.Face2FacePayment.Dto;
using WxOpenApi.Utils;

namespace WxOpenApi.Face2FacePayment
{
    public class PayByCardManager : DomainService
    {
        private IHttpContextAccessor _contextAccessor;
        public PayByCardManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// 回调地址
        /// </summary>
        public void Nodify()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                _contextAccessor.HttpContext.Request.Body.CopyTo(ms);
                byte[] bytes = ms.ToArray();
                string requestxml = Encoding.UTF8.GetString(bytes);
                string return_string = string.Empty;
                SortedDictionary<string, string> map = new SortedDictionary<string, string>();
                object obj = WxUtils.XmlDeserialize(typeof(PayByCardCallbackDto), requestxml);
                if (obj is PayByCardCallbackDto && ((PayByCardCallbackDto)obj).return_code == "SUCCESS")
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
                _contextAccessor.HttpContext.Response.Body.Write(respbyte, 0, respbyte.Length);
            }

        }
        /// <summary>
        /// 申请支付
        /// </summary>
        public PayByCardCallbackDto Paying()
        {
            #region 下单map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},//微信分配的公众账号ID（企业号corpid即为此appId）
                {"attach" , "wxpay" },//说明.
                {"auth_code" , "wxpay" },//扫码支付授权码
                {"body", "订单支付"},//xxx店-收银机收款
                {"device_info", "设备号"},//设备号
                {"mch_id", WxConfig.MCH_ID },//商户号
                {"nonce_str", WxUtils.RandomStr(16)},//随机16位字符串
                {"out_trade_no",DateTime.Now.ToString("yyyyMMddHHmmss")+WxUtils.RandomStr(2) },//订单号
                {"notify_url", WxConfig.PayByCardNodifyUrl},
                {"spbill_create_ip",""},//用户IP
                {"total_fee", "0.01"},//金额
            };
            #endregion

            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            #endregion

            #region 请求微信接口发起支付申请
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            string callbackXml = WxUtils.PostToMicropay(xml);
            PayByCardCallbackDto callbackobj = (PayByCardCallbackDto)WxUtils.XmlDeserialize(typeof(PayByCardCallbackDto), callbackXml);
            #endregion

            return callbackobj;
        }
    }
}
