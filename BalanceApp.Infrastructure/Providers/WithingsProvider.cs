using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Providers;
using BalanceApp.Infrastructure.Http;
using BalanceApp.Infrastructure.ResponseObjects;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BalanceApp.Infrastructure.Providers
{
    
    public class WithingsProvider : IWithingsProvider
    {
        private string clientId;
        private string clientSecret;
        private readonly IHttpClient http;

        public WithingsProvider(IHttpClient http)
        {
            clientId = "cb9810b32ebb519c18488ff6b725e5230816d876a8aac4286eb1eb5b6f2652d5";
            clientSecret = "f48a5ea5498be4a405c4d9c411d494c989a4c0c3e5595322c2b4d73ff8192943";
            this.http = http;
        }

        public string CreateSignature(string action)
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            List<string> dataList = new()
            {
                action,
                clientId,
                timestamp.ToString(),
            };

            string data = $"{dataList.First()},{dataList[1]},{dataList.Last()}";
            HMACSHA256 sha256Hash = new(Encoding.UTF8.GetBytes(clientSecret));
            byte[] signature = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

            return Convert.ToHexString(signature).ToLower();
        }

        public async Task<string> GetNonce(string signature)
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            Dictionary<string, string> values = new()
            {
                { "action", "getnonce" },
                { "client_id", clientId },
                { "timestamp" , timestamp.ToString()},
                { "signature" , signature}
            };

            FormUrlEncodedContent content = new(values);

            try
            {
                string response = await (await http.PostAsync("https://wbsapi.withings.net/v2/signature", content)).Content.ReadAsStringAsync();
                Reponse<Nonce>? nonce = JsonSerializer.Deserialize<Reponse<Nonce>>(response);

                if (nonce is null)
                    throw new Exception("Nonce not found !");

                return nonce.body.nonce;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WithingsTokenDto> Login(string code)
        {
            Dictionary<string,string> values = new()
            {
                { "action", "requesttoken" },
                { "authorization_code", "grant_type" },
                { "client_id" , clientId},
                { "client_secret" , clientSecret},
                { "code", code },
                { "redirect_uri", "https://angelicola-saverio.fr" }
            };

            FormUrlEncodedContent content = new(values);

            try
            {
                string response = await (await http.PostAsync("https://wbsapi.withings.net/v2/oauth2", content)).Content.ReadAsStringAsync();
                Reponse<Token>? token = JsonSerializer.Deserialize<Reponse<Token>>(response);

                if (token is null)
                    throw new Exception("Not Authorized!");

                return new(token.body.AccessToken, token.body.RefreshToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* public async Task GetMeasure(string withingsToken)
        {
            http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", withingsToken);
        } */
    }
}
