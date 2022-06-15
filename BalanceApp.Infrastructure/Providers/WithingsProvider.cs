using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Providers;
using BalanceApp.Application.Services.Providers;
using BalanceApp.Domain.ValueObjects;
using BalanceApp.Infrastructure.Http;
using BalanceApp.Infrastructure.ResponseObjects;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BalanceApp.Infrastructure.Providers
{

    public class WithingsProvider : IWithingsProvider
    {
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly IHttpClient http;

        public WithingsProvider(IHttpClient http, IConfiguration configuration)
        {
            this.http = http;
            clientId = configuration.GetSection("AppSettings:ClientId").Value;
            clientSecret = configuration.GetSection("AppSettings:ClientSecret").Value;
        }

        public async Task<WithingsTokenDto> Login(string code)
        {
            Dictionary<string, string> values = new()
            {
                { "action", "requesttoken" },
                { "grant_type", "authorization_code" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "code", code },
                { "redirect_uri", "https://balance-app-blaise-pascal.herokuapp.com/api/auth/withings/register" }
            };

            FormUrlEncodedContent content = new(values);

            try
            {
                string response = await (await http.PostAsync("https://wbsapi.withings.net/v2/oauth2", content)).Content.ReadAsStringAsync();
                Reponse<Token>? token = JsonSerializer.Deserialize<Reponse<Token>>(response);

                if (token is null)
                    throw new Exception("token null!");

                return new(token.body.access_token, token.body.refresh_token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WithingsTokenDto> RefreshToken(string token)
        {
            Dictionary<string, string> values = new()
            {
                { "action", "requesttoken" },
                { "grant_type", "refresh_token" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "refresh_token", token },
            };

            FormUrlEncodedContent content = new(values);

            try
            {
                string response = await (await http.PostAsync("https://wbsapi.withings.net/v2/oauth2", content)).Content.ReadAsStringAsync();
                Reponse<Token>? tokens = JsonSerializer.Deserialize<Reponse<Token>>(response);

                if (tokens is null)
                    throw new Exception("token null!");

                return new(tokens.body.access_token, tokens.body.refresh_token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BodyData>> GetMeasures(string withingsToken, string startDate, double height)
        {
            Dictionary<string, string> values = new()
            {
                { "action", "getmeas" },
                { "meastype", "1,8,76,88,77" },
                { "client_id", clientId },
                { "startdate", startDate },
                { "client_secret", clientSecret },
            };

            FormUrlEncodedContent content = new(values);
            try
            {
                http.getRequestHeader().Authorization = new AuthenticationHeaderValue("Bearer", withingsToken);
                string response = await (await http.PostAsync("https://wbsapi.withings.net/measure", content)).Content.ReadAsStringAsync();
                Reponse<Measure>? measure = JsonSerializer.Deserialize<Reponse<Measure>>(response);
                if(measure is null)
                {
                    throw new Exception("measure is null");
                }

                List<BodyData> body = new();
                foreach(var valuegrps in measure.body.measuregrps)
                {
                    int? wheight = valuegrps.measures.FirstOrDefault(m => m.type == 1)?.value;
                    int? fatMass = valuegrps.measures.FirstOrDefault(m => m.type == 8)?.value;
                    int? muscleMass = valuegrps.measures.FirstOrDefault(m => m.type == 76)?.value;
                    int? boneMass = valuegrps.measures.FirstOrDefault(m => m.type == 88)?.value;
                    int? waterMass = valuegrps.measures.FirstOrDefault(m => m.type == 77)?.value;

                    double wheightKilo = wheight is null ? 0.0 : (double)wheight / 1000.0;
                    double fatMassKilo = fatMass is null ? 0.0 : (double)fatMass / 100.0;
                    double muscleMassKilo = muscleMass is null ? 0.0 : (double)muscleMass / 100.0;
                    double boneMassKilo = boneMass is null ? 0.0 : (double)boneMass / 100.0;
                    double waterMassKilo = muscleMass is null ? 0.0 : (double)muscleMass / 100.0;
                    if(wheightKilo != 0)
                    {
                        body.Add(new BodyData(wheightKilo, fatMassKilo, waterMassKilo, muscleMassKilo, boneMassKilo, wheightKilo/(height*height), valuegrps.created.ToString()));
                    }
                    
                }
                return body;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }
    }
}
