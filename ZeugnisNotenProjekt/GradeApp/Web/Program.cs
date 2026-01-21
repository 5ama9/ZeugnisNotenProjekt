using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Services;

namespace Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Register handler
        builder.Services.AddScoped<CustomHttpHandler>();

        // ONE HttpClient with JWT handler
        builder.Services.AddScoped(sp =>
        {
            var handler = sp.GetRequiredService<CustomHttpHandler>();
            handler.InnerHandler = new HttpClientHandler();

            return new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7038/")
            };
        });

        // Services use the SAME HttpClient
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IGradeService, GradeService>();

        await builder.Build().RunAsync();
    }
}