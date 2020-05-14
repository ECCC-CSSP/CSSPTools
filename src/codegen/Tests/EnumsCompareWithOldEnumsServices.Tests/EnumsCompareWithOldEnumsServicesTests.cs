﻿using EnumsCompareWithOldEnumsServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using ActionCommandDBServices.Resources;
using ValidateAppSettingsServices.Resources;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class EnumsCompareWithOldEnumsServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("es-TU")] // good will default to en-CA
        [InlineData("en-GB")] // good will default to en-CA
        public async Task AngularEnumsGeneratedService_Run_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture), "appsettings.json");

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(enumsCompareWithOldEnumsService);

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = await enumsCompareWithOldEnumsService.Run(args);
            Assert.True(retBool);

            // all culture other than "fr-CA" should default to "en-CA"
            if (culture != "fr-CA")
            {
                culture = "en-CA";
            }
            CultureInfo Culture = new CultureInfo(culture);
            Assert.Equal(Culture, EnumsCompareWithOldEnumsServicesRes.Culture);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        public async Task AngularEnumsGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            await Setup(new CultureInfo(culture), "appsettings_bad1.json");

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(enumsCompareWithOldEnumsService);

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = await enumsCompareWithOldEnumsService.Run(args);
            Assert.False(retBool);
        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture, string appsettingjsonFileName)
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            Assert.NotNull(configuration);

            bool retBool = await ConfigureServices();
            Assert.True(retBool);
        }
        private async Task<bool> ConfigureServices()
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            bool retBool = await ConfigureIActionCommandDBService();
            Assert.True(retBool);

            retBool = await ConfigureIAllOtherServices();
            Assert.True(retBool);

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureIActionCommandDBService()
        {
            try
            {
                serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Assert.NotNull(configuration.GetValue<string>(DBFileName));

                FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));
                Assert.True(fiDB.Exists);

                serviceCollection.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });

                provider = serviceCollection.BuildServiceProvider();
                Assert.NotNull(provider);

                actionCommandDBService = provider.GetService<IActionCommandDBService>();
                if (actionCommandDBService == null)
                {
                    Console.WriteLine($"{ AppDomain.CurrentDomain.FriendlyName } actionCommandDBService   == null");
                    return await Task.FromResult(false);
                }

                actionCommandDBService.Action = configuration.GetValue<string>("Action");
                actionCommandDBService.Command = configuration.GetValue<string>("Command");

                await actionCommandDBService.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.True(false);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureIAllOtherServices()
        {
            try
            {
                serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
                serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
                serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

                provider = serviceCollection.BuildServiceProvider();
                if (provider == null)
                {
                    await actionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
                    return await Task.FromResult(false);
                }

                enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();
                if (enumsCompareWithOldEnumsService == null)
                {
                    await actionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService  == null");
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                Assert.True(false);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
