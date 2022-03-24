using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Exceptions
{
    public class AddingBodyDataException : Exception
    {
        public AddingBodyDataException() : base("Adding body data failed") { }
    }
}
