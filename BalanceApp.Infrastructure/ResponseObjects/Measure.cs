using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.ResponseObjects
{
    public record Measure
    {
        public int updatetime { get; set; }
        public string timezone { get; set; }
        public List<MeasureGrps> measuregrps { get; set; }
        public int more { get; set; }
        public int offset { get; set; }

        public Measure(int updatetime, string timezone, int more, int offset)
        {
            this.updatetime = updatetime;
            this.timezone = timezone;
            this.measuregrps = new();
            this.more = more;
            this.offset = offset;
        }
    }
}
