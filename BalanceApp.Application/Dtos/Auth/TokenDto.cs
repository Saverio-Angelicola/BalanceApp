﻿namespace BalanceApp.Application.Dtos.Auth
{
    public record TokenDto
    {
        public string TokenJwt { get; set; }
        public DateTime ExpirationDate { get; set; }

        public TokenDto(string tokenJwt)
        {
            TokenJwt = tokenJwt;
            ExpirationDate = DateTime.Now.AddDays(1);
        }

        public TokenDto()
        {
            TokenJwt = string.Empty;
            ExpirationDate = DateTime.Now.AddDays(1);
        }
    }
}