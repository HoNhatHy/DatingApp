using API.Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration()
                            .UseStartup<Startup>();
                })
                .Build();
             
            await host.RunAsync();
        }
    }
}