using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace MoneyTrackinWS
{
    internal class RESTClient
    {
        private string GetBaseUrl()
        {

            return "https://www.moneytrackin.com/api/rest/";
        }

        private string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
        }

        public string MakeRequest(string url, string user, string password)
        {
            string reponseAsString = "";
            url = GetBaseUrl() + url;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(user, EncodePassword(password));
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();

                reponseAsString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }


    }
}
