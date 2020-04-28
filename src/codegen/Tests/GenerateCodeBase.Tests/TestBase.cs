using GenerateCodeBase.Services;
using GenerateCodeBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class Tests
    {
        #region Variables
        public static IConfiguration configuration;
        public static IServiceCollection serviceCollection;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        public static IGenerateCodeBaseService generateCodeBaseService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public Tests()
        {
            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileNameTest").Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Assert.True(fiDB.Exists);
            }

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            generateCodeBaseService = provider.GetService<IGenerateCodeBaseService>();
            if (generateCodeBaseService == null)
            {
                Assert.NotNull(generateCodeBaseService);
            }

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                Assert.NotNull(generateCodeStatusDBService);
            }

            Init(new CultureInfo("en-CA"));
        }
        #endregion Constructors

        #region Functions public
        public void Init(CultureInfo culture)
        {
            generateCodeStatusDBService.Culture = culture;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Error = new StringBuilder();
            generateCodeStatusDBService.Status = new StringBuilder();


        }
        #endregion Functions public
    }

}
