using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSSPCodeGenWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        config.AddJsonFile("appsettings_csspwebapis.json");
                        config.AddUserSecrets("dd0c74e5-2064-419f-9779-c12942e685ee");
                    });
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:4444", "https://localhost:4445");
                });

    }
}
