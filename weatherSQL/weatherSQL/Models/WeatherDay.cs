using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherSQL.Models
{
    public class WeatherDay
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string Summary { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF{ get; set; }
    }
}
