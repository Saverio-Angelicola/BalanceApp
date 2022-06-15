using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.ResponseObjects
{
    public class Measures
    {
        public int value { get; set; }
        public int type { get; set; }
        public int unit { get; set; }

        public Measures(int value, int type, int unit)
        {
            this.value = value;
            this.type = type;
            this.unit = unit;
        }
    }
}
