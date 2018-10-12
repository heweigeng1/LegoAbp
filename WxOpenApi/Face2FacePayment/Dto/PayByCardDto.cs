namespace WxOpenApi.Face2FacePayment.Dto
{
    /// <summary>
    /// 提交刷卡支付参数
    /// </summary>
    public class PayByCardDto
    {
        public string appid { get; set; }
        public string attach { get; set; }
        public string auth_code { get; set; }
        public string body { get; set; }
        public string device_info { get; set; }
        public string mch_id { get; set; }
        public string nonce_str { get; set; }
        public string out_trade_no { get; set; }
        public string spbill_create_ip { get; set; }
        public string total_fee { get; set; }
        public string sign { get; set; }
    }
}
