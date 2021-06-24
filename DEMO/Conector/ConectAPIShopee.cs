using DEMO.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Newtonsoft.Json.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Conector
{
    public class ConectAPIShopee : IConectAPIShopee
    {


        public RestClient CreateRestSharpClient(string url)
        {
            var client = new RestClient(url);
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            return client;
        }
        public string GenerateShopeeApiToken(string apiRoute, string bodyJson, string secretKey)
        {
            string shopeeInternetAPIUrl = "https://partner.shopeemobile.com";
            string key = string.Format("{0}{1}|{2}", shopeeInternetAPIUrl, apiRoute, bodyJson);
            return GeneratorSHA256HMAC(key, secretKey);
        }
        public string GeneratorSHA256HMAC(string input, string key)
        {
            var apiKey = Encoding.UTF8.GetBytes(key);
            string hashString = "";
            using (HMACSHA256 hmac = new HMACSHA256(apiKey))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                if (hash != null && hash.Length > 0)
                {
                    for (int i = 0; i < hash.Length; i++)
                    {
                        hashString += hash[i].ToString("X2").ToLower(); // hex format
                    }
                }
            }
            return hashString;
        }

        public APIResponse CallShopeeApi<T>(string route, BaseRequest objectRequest) where T : BaseResponse
        {
            APIResponse response = new APIResponse();
            var shopeeAPIUrl = "https://partner.shopeemobile.com";
            var client = CreateRestSharpClient(shopeeAPIUrl);
            string shopeeSecretKey = "2d5d8e7a66de94b05d100da579277ecfba973b6bd206c5b1c54cee074b4418e1";
            var request = new RestRequest(route, Method.POST);

            
            objectRequest.timestamp = (Int32)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string bodyJson = JsonConvert.SerializeObject(objectRequest);
            string token = GenerateShopeeApiToken(route, bodyJson, shopeeSecretKey);
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", token);
            request.AddJsonBody(objectRequest);

            IRestResponse clientResponse = client.Execute(request);
            response.code = (int)clientResponse.StatusCode;
            response.message = clientResponse.ErrorMessage;
            response.data = clientResponse.Content;
            response.error = clientResponse.ErrorMessage;
            return response;
        }

    }
}
