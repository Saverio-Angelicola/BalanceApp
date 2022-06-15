using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.ResponseObjects
{
    public class MeasureGrps
    {
        public int attrib { get; set; }
        public int date { get; set; }
        public int created { get; set; }
        public int category { get; set; }
        public string deviceid { get; set; }
        public string hash_deviceid { get; set; }
        public List<Measures> measures { get; set; }
        public string timezone { get; set; }

        public MeasureGrps(int attrib, int date, int created, int category, string deviceid, string timezone, string hash_deviceId)
        {
            this.attrib = attrib;
            this.date = date;
            this.created = created;
            this.category = category;
            this.deviceid = deviceid;
            this.measures = new();
            this.timezone = timezone;
            this.hash_deviceid = hash_deviceId;
        }
    }
}
