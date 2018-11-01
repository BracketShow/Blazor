using System;
using System.Collections.Generic;

namespace BlazorBierTekno.Shared
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        public string IconImagePath => $"http://openweathermap.org/img/w/{icon}.png";
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
        
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class ResponseWeather
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }

        public Coord coord { get; set; }
        public string @base { get; set; }
        public int visibility { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public DateTime FormattedDate => epoch.AddSeconds(dt);

        public double Temperature => main?.temp ?? 0;

        public int Humidity => main?.humidity ?? 0;

        public double WindSpeed => wind?.speed ?? 0;

        public string IconUrl { get; set; }
    }

    public class ResponseWeatherForecast
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public IList<ResponseWeather> list { get; set; }
        public City city { get; set; }
    }
}
