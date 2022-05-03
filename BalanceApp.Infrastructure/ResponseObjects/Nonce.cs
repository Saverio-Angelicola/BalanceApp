using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.ResponseObjects
{
    public record Nonce
    {
        public string nonce { get; set; }
    }
}
