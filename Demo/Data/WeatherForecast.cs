using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Data
{
    public class WeatherForecast
    {
        [DisplayName("تاریخ")]
        //[Display(Name ="تاریخ ما")]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
