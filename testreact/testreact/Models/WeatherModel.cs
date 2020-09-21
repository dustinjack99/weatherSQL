using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testreact.Models
{
        [Table("weather")]
    public class WeatherModel
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        public double Temp { get; set; }
        public double TempFeel { get; set; }
        public string DateTime { get; set; }
        public string Weather { get; set; }
    }
}
