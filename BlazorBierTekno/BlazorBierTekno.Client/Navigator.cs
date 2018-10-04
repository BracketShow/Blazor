using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.JSInterop;

namespace BlazorBierTekno.Client
{
    public class Navigator
    {
        private static int _currentIndex = 0;

        private static readonly List<string> Routes = new List<string>
        {
            "/",
            "/pourquoi-blazor",
            "/pourquoi-blazor/1",
            "/comment-fonctionne",
            "/fonctions-utilisables",
            "/fonctions-a-venir",
            "/pourquoi-pas-blazor",
            "/conclusion"
        };

        [JSInvokable]
        public static void NavigateBack()
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = Routes.Count - 1;
            }
            BrowserUriHelper.Instance.NavigateTo(Routes.ElementAt(_currentIndex));
        }

        [JSInvokable]
        public static void NavigateForward()
        {
            _currentIndex++;
            if (_currentIndex >= Routes.Count)
            {
                _currentIndex = 0;
            }
            BrowserUriHelper.Instance.NavigateTo(Routes.ElementAt(_currentIndex));
        }
    }
}
