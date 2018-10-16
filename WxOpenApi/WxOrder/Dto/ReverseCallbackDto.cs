namespace WxOpenApi.WxOrder.Dto
{
    public class ReverseCallbackDto
    {
        public string return_code { get; set; }
        public string return_msg { get; set; }
        public string appid { get; set; }
        public string mch_id { get; set; }
        public string nonce_str { get; set; }
        public string sign { get; set; }
        public string result_code { get; set; }
        public string recall { get; set; }
    }
}
