﻿using CSSPModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceGeneratedServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using CultureServices.Resources;

namespace ServicesClassNameServiceGeneratedServices.Tests
{
    public class ServicesClassNameServiceGeneratedServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IServicesClassNameServiceGeneratedService servicesClassNameServiceGeneratedService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IServiceProvider provider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("en-GB")] // good will default to en-CA
        public async Task ServicesClassNameServiceGeneratedService_Run_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture), "appsettings.json");

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(servicesClassNameServiceGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = await servicesClassNameServiceGeneratedService.Run(args);
            Assert.True(retBool);

            // all culture other than "fr-CA" should default to "en-CA"
            if (culture != "fr-CA")
            {
                culture = "en-CA";
            }
            CultureInfo Culture = new CultureInfo(culture);
            Assert.Equal(Culture, CultureServicesRes.Culture);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        public async Task ServicesClassNameServiceGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            await Setup(new CultureInfo(culture), "appsettings_bad1.json");

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(servicesClassNameServiceGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            bool retBool = await servicesClassNameServiceGeneratedService.Run(args);
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

            bool retBool = await ConfigureCSSPDBContext(serviceCollection);
            Assert.True(retBool);

            retBool = await ConfigureTestDBContext(serviceCollection);
            Assert.True(retBool);

            retBool = await ConfigureIActionCommandDBService();
            Assert.True(retBool);

            retBool = await ConfigureIAllOtherServices();
            Assert.True(retBool);

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureCSSPDBContext(IServiceCollection serviceCollection)
        {
            string CSSPDBConnString = configuration.GetValue<string>("CSSPDBConnectionString");
            if (CSSPDBConnString == null)
            {
                await actionCommandDBService.ConsoleWriteError($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBConnectionString") }");
                return await Task.FromResult(false);
            }

            try
            {
                serviceCollection.AddDbContext<CSSPDBContext>(options =>
                {
                    options.UseSqlServer(CSSPDBConnString);
                });
            }
            catch (Exception ex)
            {
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureTestDBContext(IServiceCollection serviceCollection)
        {
            string TestDBConnString = configuration.GetValue<string>("TestDBConnectionString");
            if (TestDBConnString == null)
            {
                await actionCommandDBService.ConsoleWriteError($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, "TestDBConnectionString") }");
                return await Task.FromResult(false);
            }

            try
            {
                serviceCollection.AddDbContext<TestDBContext>(options =>
                {
                    options.UseSqlServer(TestDBConnString);
                });
            }
            catch (Exception ex)
            {
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

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
                Assert.NotNull(actionCommandDBService);

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
                serviceCollection.AddSingleton<IServicesClassNameServiceGeneratedService, ServicesClassNameServiceGeneratedService>();

                provider = serviceCollection.BuildServiceProvider();
                Assert.NotNull(provider);

                servicesClassNameServiceGeneratedService = provider.GetService<IServicesClassNameServiceGeneratedService>();
                Assert.NotNull(servicesClassNameServiceGeneratedService);
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
