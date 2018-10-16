using Abp.Domain.Services;
using Microsoft.AspNetCore.Http;
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
        private const string payByCardUrl = "https://api.mch.weixin.qq.com/pay/micropay";
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
                    map.Add("return_msg", "支付失败");
                }
                string xml = map.SortedDictionaryToWxXml();
                var respbyte = Encoding.UTF8.GetBytes(xml);
                _contextAccessor.HttpContext.Response.Body.Write(respbyte, 0, respbyte.Length);
            }
        }
        /// <summary>
        /// 申请支付
        /// </summary>
        public string Paying(string auth_code, string device_info, string body, string out_trade_no, string notify_url, string total_fee)
        {
            string ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            #region 下单map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},//微信分配的公众账号ID（企业号corpid即为此appId）
                {"attach" , "wxpay" },//说明.
                {"auth_code" ,auth_code},//扫码支付授权码
                {"body", body},//xxx店-收银机收款
                {"device_info",device_info},//设备号
                {"mch_id", WxConfig.MCH_ID },//商户号
                {"nonce_str", WxUtils.RandomStr(16)},//随机16位字符串
                {"out_trade_no",out_trade_no },//订单号
                {"notify_url", notify_url},
                {"spbill_create_ip",ip},//用户IP
                {"total_fee",total_fee},//金额
            };
            #endregion

            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            #endregion

            return WxUtils.PostToWxOpenApi(payByCardUrl, xml);
        }
    }
}
