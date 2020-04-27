using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Data
{
    public class WeatherForecast
    {
        [Display(Name = "تاریخ")]

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Display(Name = "توضیحات")]

        public string Summary { get; set; }

        [Display(Name ="وضعیت جوی")]
        public WeatherType WeatherType { get; set; }
    }


    public enum WeatherType
    {
        [Display(Name ="آفتابی")]
        suny,
        rainy,
        cloudly,
        foggy,

    }
}
