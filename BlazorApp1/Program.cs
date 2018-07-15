using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // Add any custom services here
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");

            
        }
    }
}
