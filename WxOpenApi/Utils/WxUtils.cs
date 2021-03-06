﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace WxOpenApi.Utils
{
    public static class WxUtils
    {
        private static readonly string randomStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
       
        public static string RandomStr(int length)
        {
            string result = string.Empty;
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                result += randomStr[rd.Next(randomStr.Length)];
            }
            return result;
        }
        public static string SortedDictionaryToWxUrl(this SortedDictionary<string, string> map)
        {
            string buff = "";
            foreach (var pair in map)
            {
                if (pair.Value == null)
                {
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }
                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            return buff.Trim('&');
        }
        public static string SortedDictionaryToWxXml(this SortedDictionary<string, string> map)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in map)
            {
                if (item.Value.GetType() == typeof(int))
                {
                    sb.Append($@"<{item.Key}>{item.Value}</{item.Key}>");
                }
                else if (item.Value.GetType() == typeof(string))
                {
                    if (item.Key != "sign")
                    {
                        sb.Append($@"<{item.Key}><![CDATA[{item.Value}]]></{item.Key}>");
                    }
                }
                else
                {
                    throw new Exception("xml里不能包含int 类型与string 类型以外的类型");
                }
            }
            return $@"<xml>{sb.ToString()}</xml>";
        }
        /// <summary>
        /// 根据算法生成sign(MD5)
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetSign(string encypStr, string charset)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
        public static string PostToWxOpenApi(string url, string postData)
        {
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                return wc.UploadString(url, "POST", postData);
            }
        }
        public static object XmlDeserialize(Type type, string xml)
        {
            try
            {
                xml = xml.Replace("xml", type.Name);
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ToTimeStamp(this DateTime date)
        {
            TimeSpan time = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ((long)time.TotalSeconds).ToString();
        }
        public static SortedDictionary<string, string> ObjToSortedDictionary(object obj)
        {
            SortedDictionary<string, string> map = new SortedDictionary<string, string>();
            Type type = obj.GetType();
            foreach (PropertyInfo item in type.GetProperties())
            {
                map.Add(item.Name, item.GetValue(obj).ToString());
            }
            return map;
        }
    }
}
