using BalanceApp.Application.Withings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.Withings
{
    public class WithingsApi : IWithingsApi
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;

        public WithingsApi()
        {
            _httpClient = new HttpClient();
            baseUrl = "https://wbsapi.withings.net/v2/";
        }
        public async Task CreateUser(string json)
        {
            try
            {
                HttpContent content = new StringContent(json,Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(baseUrl + "user",content);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
