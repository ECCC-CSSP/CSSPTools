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
using GenerateCodeStatusDB.Resources;

namespace GenerateCodeStatusDB.Tests
{
    public partial class GenerateCodeStatusDBTests
    {
        #region Variables
        public static IConfiguration configuration;
        public static IServiceCollection serviceCollection;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        #endregion Variables

        #region Constructors
        public GenerateCodeStatusDBTests()
        {
            Setup();
            Init(new CultureInfo("en-CA"));
        }
        #endregion Constructors

        #region Functions public
        [Fact]
        public async Task ConstructorsOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                Assert.NotNull(configuration);
                Assert.NotNull(serviceCollection);
                Assert.NotNull(generateCodeStatusDBService);

                Assert.Equal(new CultureInfo(culture), generateCodeStatusDBService.Culture);
                Assert.Equal("GenerateCodeStatusDB.Tests", generateCodeStatusDBService.Command);
                Assert.Equal("", generateCodeStatusDBService.Error.ToString());
                Assert.Equal("", generateCodeStatusDBService.Status.ToString());

                await generateCodeStatusDBService.SetCulture(new CultureInfo(culture));
                Assert.Equal(new CultureInfo(culture), AppRes.Culture);
                //Assert.Null(generateCodeStatusDBService.DBFileFullName);
            }
        }
        [Fact]
        public async Task CreateDeleteGetGetOrCreateUpdateOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                // Clearing object in DB
                GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.Get();

                if (generateCodeStatus != null)
                {
                    await generateCodeStatusDBService.Delete();
                    generateCodeStatus = await generateCodeStatusDBService.Get();
                    Assert.Null(generateCodeStatus);
                }

                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.Null(generateCodeStatus);

                // Creating object in DB
                generateCodeStatus = await generateCodeStatusDBService.Create();
                Assert.NotNull(generateCodeStatus);

                // Should not create a second objct but just return the existing one
                generateCodeStatus = await generateCodeStatusDBService.Create();
                Assert.NotNull(generateCodeStatus);

                // Should delete the object
                generateCodeStatus = await generateCodeStatusDBService.Delete();
                Assert.NotNull(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.Null(generateCodeStatus);

                // Recreating the object in DB using the GetOrCreate
                generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();
                Assert.NotNull(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.NotNull(generateCodeStatus);

                // Should just return the existing object
                generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();
                Assert.NotNull(generateCodeStatus);

                // Should update the existing object with info
                generateCodeStatusDBService.Error.AppendLine("Testing");
                generateCodeStatusDBService.Status.AppendLine("Bonjour");
                generateCodeStatus = await generateCodeStatusDBService.Update(33);
                Assert.NotNull(generateCodeStatus);
                Assert.Equal(generateCodeStatusDBService.Error.ToString(), generateCodeStatus.ErrorText);
                Assert.Equal(generateCodeStatusDBService.Status.ToString(), generateCodeStatus.StatusText);
                Assert.Equal(33, generateCodeStatus.PercentCompleted);

                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.NotNull(generateCodeStatus);

                await generateCodeStatusDBService.Delete();
                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.Null(generateCodeStatus);
            }
        }
        [Fact]
        public async Task CreateDeleteGetGetOrCreateEmptyCommandTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.Get();

                if (generateCodeStatus != null)
                {
                    await generateCodeStatusDBService.Delete();
                    generateCodeStatus = await generateCodeStatusDBService.Get();
                    Assert.Null(generateCodeStatus);
                }

                string TempCommand = generateCodeStatusDBService.Command;
                generateCodeStatusDBService.Command = "";

                generateCodeStatus = await generateCodeStatusDBService.Create();
                Assert.Null(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.Delete();
                Assert.Null(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.Get();
                Assert.Null(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();
                Assert.Null(generateCodeStatus);

                generateCodeStatus = await generateCodeStatusDBService.Update(0);
                Assert.Null(generateCodeStatus);

                generateCodeStatusDBService.Command = TempCommand;
            }
        }
        [Fact]
        public async Task SetCommandOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                await generateCodeStatusDBService.SetCommand("test");
                Assert.Equal("test", generateCodeStatusDBService.Command);
            }
        }
        [Fact]
        public async Task SetCultureOKTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                await generateCodeStatusDBService.SetCulture(new CultureInfo(culture));
                Assert.Equal(new CultureInfo(culture), generateCodeStatusDBService.Culture);
            }
        }
        #endregion Functions public

        #region Functions private
        private void Init(CultureInfo culture)
        {
            generateCodeStatusDBService.Culture = culture;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Error = new StringBuilder();
            generateCodeStatusDBService.Status = new StringBuilder();
        }
        private void Setup()
        {
            serviceCollection = new ServiceCollection();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Assert.True(fiDB.Exists);
            }

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            if (provider == null)
            {
                Assert.NotNull(provider);
            }

            generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (generateCodeStatusDBService == null)
            {
                Assert.NotNull(generateCodeStatusDBService);
            }
        }
        #endregion Functions private

    }
}
