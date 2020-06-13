﻿using AngularModelsGeneratedServices.Services;
using ConfigServices.Services;
using CultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AngularModelsGeneratedServices.Tests
{
    public class AngularModelsGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        IAngularModelsGeneratedService AngularModelsGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public AngularModelsGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task AngularModelsGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AngularModelsGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await AngularModelsGeneratedService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task AngularModelsGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AngularModelsGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await AngularModelsGeneratedService.Run(args));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture, string appsettingjsonFileName)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            Services = new ServiceCollection();
            Assert.True(await ConfigureBaseServices());

            Services.AddSingleton<IAngularModelsGeneratedService, AngularModelsGeneratedService>();

            Assert.True(await BuildServiceProvider());

            AngularModelsGeneratedService = Provider.GetService<IAngularModelsGeneratedService>();
            Assert.NotNull(AngularModelsGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
