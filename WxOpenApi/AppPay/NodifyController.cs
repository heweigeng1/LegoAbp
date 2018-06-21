using Abp.AspNetCore.Mvc.Controllers;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WxOpenApi.AppPay.Dtos;
using WxOpenApi.Utils;

namespace WxOpenApi.AppPay
{
    public class NodifyController:AbpController
    {
      
        [HttpPost]
        [DontWrapResult]
        public void MobliePay()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Request.Body.CopyTo(ms);
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
                Stream stream = ms;
                var respbyte = Encoding.UTF8.GetBytes(xml);
                //contextAccessor.HttpContext.Response.Body.EndWrite(stream.WriteAsync(respbyte, 0, respbyte.Length));
                Response.Body.Write(respbyte, 0, respbyte.Length);
            }
        }
    }
}
