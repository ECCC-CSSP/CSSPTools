using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSSPWebAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Start();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        config.AddJsonFile("appsettings_csspwebapis.json");
                        config.AddUserSecrets("41c4156a-4b42-42e9-923a-e9c8360dba12");
                    });
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseUrls("http://localhost:4446", "https://localhost:4447");
                });
    }
}
