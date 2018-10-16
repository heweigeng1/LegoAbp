using Abp.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WxOpenApi.Config;
using WxOpenApi.Utils;

namespace WxOpenApi.Refund
{
    /// <summary>
    /// 申请退款 请求需要双向证书
    /// </summary>
    public class RefundManager : DomainService
    {
        /// <summary>
        /// 申请退款接口
        /// </summary>
        private const string refundUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        /// <summary>
        /// 查询退款接口
        /// </summary>
        private const string refundqueryUrl = "https://api.mch.weixin.qq.com/pay/refundquery";
        private IHttpContextAccessor _contextAccessor;
        public RefundManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// 查询退款
        /// </summary>
        public void Query()
        {

        }
        /// <summary>
        /// 申请退款订单
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="out_refund_no">商户退款单号</param>
        /// <param name="total_fee">订单金额,单位/分</param>
        /// <param name="refund_fee">申请退款金额,单位/分</param>
        /// <param name="notify_url">退款异步通知回调地址</param>
        /// <param name="refund_desc">退款原因</param>
        /// <returns>callback xml</returns>
        public string Refund(string out_trade_no, string out_refund_no, string total_fee, string refund_fee, string notify_url = null,string refund_desc=null)
        {
            #region 查询map
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},//微信分配的公众账号ID（企业号corpid即为此appId）
                {"mch_id", WxConfig.MCH_ID },//商户号
                {"nonce_str", WxUtils.RandomStr(16)},//随机16位字符串
                {"out_refund_no",out_refund_no},//商户内部退款单号,同一单号退款多次申请只退一次
                {"out_trade_no",out_trade_no },//商户订单号
                {"total_fee", total_fee},//订单总金额
                {"refund_fee",refund_fee},//申请退款金额,不能大于订单总金额
            };
            if (string.IsNullOrEmpty(notify_url))
            {
                sortedDictionary.Add("notify_url", notify_url);
            }
            if (string.IsNullOrEmpty(notify_url))
            {
                sortedDictionary.Add("refund_desc", refund_desc);
            }
            #endregion

            #region 生成sign
            string md5key = $@"{ sortedDictionary.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            string xml = sortedDictionary.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            #endregion

            return WxUtils.PostToWxOpenApi(refundUrl, xml);
        }
    }
}
