using Abp.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WxOpenApi.Config;
using WxOpenApi.Utils;

namespace WxOpenApi.WxOrder
{
    public class WxOrderManager : DomainService
    {
        /// <summary>
        /// 微信订单查询接口
        /// </summary>
        private const string orderQueryUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
        /// <summary>
        /// 撤销订单
        /// </summary>
        private const string reverseUrl = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
        private readonly IHttpContextAccessor _contextAccessor;
        public WxOrderManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
      /// <summary>
      /// 查询微信支付状态
      /// </summary>
      /// <param name="transaction_id">微信订单流水号</param>
      /// <returns></returns>
        public string OrderQuery(string transaction_id)
        {
            #region 查询map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},//微信分配的公众账号ID（企业号corpid即为此appId）
                {"mch_id", WxConfig.MCH_ID },//商户号
                {"nonce_str", WxUtils.RandomStr(16)},//随机16位字符串
                {"transaction_id",transaction_id }//微信订单号
            };
            #endregion

            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            #endregion

            return WxUtils.PostToWxOpenApi(orderQueryUrl, xml);
        }
        /// <summary>
        /// 根据商户订单号查询微信支付状态
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns></returns>
        public string OrderQueryByOrderNumber(string out_trade_no)
        {
            #region 查询map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},//微信分配的公众账号ID（企业号corpid即为此appId）
                {"mch_id", WxConfig.MCH_ID },//商户号
                {"nonce_str", WxUtils.RandomStr(16)},//随机16位字符串
                {"out_trade_no",out_trade_no }//微信订单号
            };
            #endregion
            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            #endregion

            return WxUtils.PostToWxOpenApi(orderQueryUrl, xml); 
        }
    }
}
