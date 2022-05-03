using BalanceApp.Application.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Providers
{
    public interface IWithingsProvider
    {
        string CreateSignature(string action);
        Task<string> GetNonce(string signature);
        Task<WithingsTokenDto> Login(string code);
    }
}
