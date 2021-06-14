using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Request / GET
        //**********************************************

        static string DoRequestGet(string url, string authorizationHeader)
        {
            var httpRequest = WebRequest.CreateHttp(url);
            httpRequest.Method = "GET";
            httpRequest.Headers.Add("Authorization", authorizationHeader);

            var responseBody = ReadHttpResponse(httpRequest);
            return responseBody;
        }

        //**********************************************
        // Request / POST
        //**********************************************

        static string DoRequestPost(string url, string authorizationHeader, string contentType, string requestBody)
        {
            var httpRequest = WebRequest.CreateHttp(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = contentType;
            httpRequest.Headers.Add("Authorization", authorizationHeader);
            var requestStream = httpRequest.GetRequestStream();
            using (var streamWriter = new StreamWriter(requestStream))
                streamWriter.Write(requestBody);

            var responseBody = ReadHttpResponse(httpRequest);
            return responseBody;
        }

        //**********************************************
        // Support functions
        //**********************************************

        static string CreateAuthorizationHeader(string username, string password)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var usernamePassword = username + ":" + password;
            var usernamePasswordBase64 = Convert.ToBase64String(encoding.GetBytes(usernamePassword));
            var authHeader = "Basic " + usernamePasswordBase64;
            return authHeader;
        }

        static string ReadHttpResponse(HttpWebRequest httpRequest)
        {
            string responseBody;
            var httpResponse = GetHttpResponse(httpRequest);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                responseBody = streamReader.ReadToEnd();
            return responseBody;
        }

        static HttpWebResponse GetHttpResponse(HttpWebRequest httpRequest)
        {
            try
            {
                return (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException webEx)
            {
                return (HttpWebResponse)webEx.Response;
            }
        }
    }
}
