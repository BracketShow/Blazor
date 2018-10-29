using BlazorBierTekno.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Newtonsoft.Json;

namespace BlazorBierTekno.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly HttpClient _http;

        public SampleDataController(HttpClient http)
        {
            _http = http;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public async Task<ResponseWeather> WeatherForecasts(string city)
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //});

            HttpWebRequest apiRequest =
                WebRequest.Create(
                        $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=a21ff7bf210de8be6ea2214336b0c7de")
                    as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/
            ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
            return rootObject;
            //return await _http.GetJsonAsync<ResponseWeather[]>(
            //    $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=a21ff7bf210de8be6ea2214336b0c7de");
        }
    }
}
