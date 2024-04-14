using BlazorDB;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazorDB(options =>
            {
                options.Name = "Test";
                options.Version = 1;
                options.StoreSchemas = new List<StoreSchema>()
                        {
                            new StoreSchema()
                            {
                                Name = "Posts",
                                PrimaryKey = "id",
                                PrimaryKeyAuto = true,
                                UniqueIndexes = new List<string> { "title" }
                            }
                        };
            });




            await builder.Build().RunAsync();
        }
    }
}
