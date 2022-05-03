using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.ResponseObjects
{
    record class Reponse<T> where T : class
    {
        public int status { get; set; }
        public T body { get; set; }
    }
}
