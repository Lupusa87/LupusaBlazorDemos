using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            //services.AddResponseCompression(options =>
            //{
            //    options.MimeTypes = new[]
            //    {
            //// Default
            //"text/plain",
            //"text/css",
            //"application/javascript",
            //"text/html",
            //"application/xml",
            //"text/xml",
            //"application/json",
            //"text/json",
            //// Custom
            //"image/svg+xml"



            // };

            //    options.EnableForHttps = true;
            //});


        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
