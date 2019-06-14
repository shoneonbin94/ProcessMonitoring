﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BServerMonitoring
{
    class BithumbApiData
    {
        private string m_sAPI_URL = "https://api.bithumb.com";              //Api Url
        private string m_sAPI_Key = "6bf4a1ee4365cc972f2615f2dd2c8bac";     //Connect Key
        private string m_sAPI_Secret = "-";                                 //Secret Key

        public BithumbApiData(string sAPI_Key, string sAPI_Secret)
        {
            this.m_sAPI_Key = sAPI_Key;
            this.m_sAPI_Secret = sAPI_Secret;
        }

        private string ByteToString(byte[] rgbyBuff)
        {
            string sHexStr = "";


            for (int nCnt = 0; nCnt < rgbyBuff.Length; nCnt++)
            {
                sHexStr += rgbyBuff[nCnt].ToString("x2"); // Hex format
            }

            return (sHexStr);
        }


        private byte[] StringToByte(string sStr)
        {
            byte[] rgbyBuff = Encoding.UTF8.GetBytes(sStr);

            return (rgbyBuff);
        }


        private long MicroSecTime()
        {
            long nEpochTicks = 0;
            long nUnixTimeStamp = 0;
            long nNowTicks = 0;
            long nowMiliseconds = 0;
            string sNonce = "";

            DateTime DateTimeNow;

            nEpochTicks = new DateTime(1970, 1, 1).Ticks;
            DateTimeNow = DateTime.UtcNow;
            nNowTicks = DateTimeNow.Ticks;
            nowMiliseconds = DateTimeNow.Millisecond;

            nUnixTimeStamp = ((nNowTicks - nEpochTicks) / TimeSpan.TicksPerSecond);

            sNonce = nUnixTimeStamp.ToString() + nowMiliseconds.ToString("D03");

            return (Convert.ToInt64(sNonce));
        }


        private string Hash_HMAC(string sKey, string sData)
        {
            byte[] rgbyKey = Encoding.UTF8.GetBytes(sKey);

            using (var hmacsha512 = new HMACSHA512(rgbyKey))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(sData));

                return (ByteToString(hmacsha512.Hash));
            }
        }


        public JObject BithumbApiCall(string sEndPoint, string sParams, ref string sRespBodyData)
        {
            string sAPI_Sign = "";
            string sPostData = sParams;
            string sHMAC_Key = "";
            string sHMAC_Data = "";
            string sResult = "";
            long nNonce = 0;
            HttpStatusCode nCode = 0;

            sPostData += "&endpoint=" + Uri.EscapeDataString(sEndPoint);

            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(this.m_sAPI_URL + sEndPoint);
                byte[] rgbyData = Encoding.ASCII.GetBytes(sPostData);

                nNonce = MicroSecTime();

                sHMAC_Key = this.m_sAPI_Secret;
                sHMAC_Data = sEndPoint + (char)0 + sPostData + (char)0 + nNonce.ToString();
                sResult = Hash_HMAC(sHMAC_Key, sHMAC_Data);
                sAPI_Sign = Convert.ToBase64String(StringToByte(sResult));

                Request.Headers.Add("Api-Key", this.m_sAPI_Key);
                Request.Headers.Add("Api-Sign", sAPI_Sign);
                Request.Headers.Add("Api-Nonce", nNonce.ToString());

                Request.Method = "POST";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.ContentLength = rgbyData.Length;

                using (var stream = Request.GetRequestStream())
                {
                    stream.Write(rgbyData, 0, rgbyData.Length);
                }

                var Response = (HttpWebResponse)Request.GetResponse();

                sRespBodyData = new StreamReader(Response.GetResponseStream()).ReadToEnd();

                return (JObject.Parse(sRespBodyData));
            }
            catch (WebException webEx)
            {
                using (HttpWebResponse Response = (HttpWebResponse)webEx.Response)
                {
                    nCode = Response.StatusCode;

                    using (StreamReader reader = new StreamReader(Response.GetResponseStream()))
                    {
                        sRespBodyData = reader.ReadToEnd();

                        return (JObject.Parse(sRespBodyData));
                    }
                }
            }

            return (null);
        }

      


    }
}
