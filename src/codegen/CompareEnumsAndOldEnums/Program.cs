using CompareEnumsAndOldEnums.Models;
using CompareEnumsAndOldEnums.Resources;
using CompareEnumsAndOldEnums.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CompareEnumsAndOldEnums
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo($@"{appDataPath}\CSSP\GenerateCodeStatus.db");


            Console.WriteLine("appsettings.json");
            Console.WriteLine("");
            Console.WriteLine(configuration.GetValue<string>("NewEnumsDll"));
            Console.WriteLine(configuration.GetValue<string>("OldEnumsDll"));
            Console.WriteLine($"Will save status in [{fiDB.FullName}]");
            Console.WriteLine("");


            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddScoped<IGenerateService, GenerateService>();

            var provider = serviceCollection.BuildServiceProvider();

            var userService = provider.GetService<IGenerateService>();


            if (args.Length != 1 || !(args[0].ToLower() == "en-ca" || args[0].ToLower() == "fr-ca"))
            {
                WriteConsoleHelp();
                return;
            }

            string retStr = userService.Start(configuration).GetAwaiter().GetResult();
            
            Console.WriteLine(retStr);
        }

        static void WriteConsoleHelp()
        {
            string AppName = AppRes.CompareEnumsAndOldEnums;

            Console.WriteLine($"\t{ AppRes.Application } { AppName }");
            Console.WriteLine("\t---------------------------------------------------------");
            Console.WriteLine($"\t{ AppRes.HowToUse }");
            Console.WriteLine($"\t{ AppName } { AppRes.en_CA } | { AppRes.fr_CA }");
            Console.WriteLine($"\t{ AppRes.Example }: { AppName } { AppRes.en_CA }");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{ AppRes.Result } { AppRes.WillCompare }");
            Console.WriteLine($"\t" + configuration.GetValue<string>("NewEnumsDll"));
            Console.WriteLine("\tand");
            Console.WriteLine($"\t" + configuration.GetValue<string>("OldEnumsDll"));
            Console.WriteLine($"\t{ AppRes.ToSeeIfTheNewEnumsDllHasTheSameEnumsAsTheOld }");

        }
    }
}
