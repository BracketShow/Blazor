using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System.Net.Http;
using System.Threading.Tasks;
using VanillaBlazor.Shared;

namespace VanillaBlazor.Client.Pages
{
    public class FetchDataModel : BlazorComponent
    {
        protected WeatherForecast[] forecasts;

        [Inject]
        protected HttpClient Http { get; set; }

        protected override async Task OnInitAsync()
        {
            const string url = "api/SampleData/WeatherForecasts";
            forecasts = await Http.GetJsonAsync<WeatherForecast[]>(url);
        }
    }
}
