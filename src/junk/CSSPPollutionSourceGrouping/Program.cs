using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSSPPollutionSourceGrouping
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
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
 * dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
 * dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
 * dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
 */
