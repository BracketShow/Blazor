using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.JSInterop;

namespace BlazorBierTekno.Client
{
    public class Navigator
    {
        private static int _currentIndex = 0;

        private static readonly List<string> Routes = new List<string>
        {
            "/",
            "/presentation",
            "/pourquoi-blazor",
            "/pourquoi-blazor/fullstack/1",
            "/pourquoi-blazor/fullstack/2",
            "/pourquoi-blazor/pourquoi/0",
            "/pourquoi-blazor/pourquoi/1",
            "/pourquoi-blazor/pourquoi/2",
            "/pourquoi-blazor/pourquoi/3",
            "/pourquoi-blazor/pourquoi/4",
            "/pourquoi-blazor/pourquoi/5",
            "/comment-fonctionne",
            "/comment-fonctionne/before-web-assembly",
            "/comment-fonctionne/web-assembly",
            "/comment-fonctionne/blazor/1",
            "/comment-fonctionne/blazor/2",
            "/fonctions-utilisables",
            "/fonctions-utilisables/components-html/1",
            "/fonctions-utilisables/components-html/2",
            "/fonctions-utilisables/components-code/1",
            "/fonctions-utilisables/components-code/2",
            "/fonctions-utilisables/components-code/3",
            "/fonctions-utilisables/routing/1",
            "/fonctions-utilisables/routing/2",
            "/fonctions-utilisables/routing/3",
            "/fonctions-a-venir",
            "/fonctions-a-venir/0",
            "/fonctions-a-venir/1",
            "/fonctions-a-venir/2",
            "/fonctions-a-venir/3",
            "/fonctions-a-venir/4",
            "/pourquoi-pas-blazor",
            "/pourquoi-pas-blazor/0",
            "/pourquoi-pas-blazor/1",
            "/pourquoi-pas-blazor/2",
            "/pourquoi-pas-blazor/3",
            "/conclusion",
            "/conclusion/1",
            "/conclusion/2",
            "/conclusion/3",
            "/conclusion/4",
        };

        private static void CheckIndex(string href)
        {
            href = href.Replace("http://localhost:57711", string.Empty);
            _currentIndex = Routes.IndexOf(href);
        }

        public static string GetVisibilityClass(int currentSection, int minimumSection)
        {
            return currentSection >= minimumSection ? "slide-element-visible" : "slide-element-hidden";
        }

        [JSInvokable]
        public static void NavigateBack(string href)
        {
            CheckIndex(href);
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = Routes.Count - 1;
            }
            BrowserUriHelper.Instance.NavigateTo(Routes.ElementAt(_currentIndex));
        }

        [JSInvokable]
        public static void NavigateForward(string href)
        {
            CheckIndex(href);
            _currentIndex++;
            if (_currentIndex >= Routes.Count)
            {
                _currentIndex = 0;
            }
            BrowserUriHelper.Instance.NavigateTo(Routes.ElementAt(_currentIndex));
        }
    }
}
