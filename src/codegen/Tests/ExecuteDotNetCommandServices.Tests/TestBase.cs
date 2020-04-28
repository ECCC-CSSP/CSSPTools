using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Tests
{
    public partial class Tests
    {
        #region Variables
        public static IConfiguration configuration;
        public static IServiceCollection serviceCollection;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        public static IValidateAppSettingsService validateAppSettingsService;
        public static IExecuteDotNetCommandService executeDotNetCommandService;
        #endregion Variables

        #region Properties
        public DotNetCommand dotNetCommand { get; set; }
        #endregion Properties

        #region Constructors
        public Tests()
        {
            serviceCollection = new ServiceCollection();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo($"{appDataPath}\\CSSP\\GenerateCodeStatusTest.db");

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            serviceCollection.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            executeDotNetCommandService = provider.GetService<IExecuteDotNetCommandService>();

            dotNetCommand = new DotNetCommand()
            {
                CultureName = "en-CA",
                Action = "run",
                SolutionFileName = @"C:\CSSPTools\src\codegen\EnumsCompareWithOldEnums\bin\Debug\netcoreapp3.1\EnumsCompareWithOldEnums.exe"
            };
        }
        #endregion Constructors

    }

}
