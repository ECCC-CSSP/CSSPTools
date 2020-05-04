using EnumsCompareWithOldEnumsServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class EnumsCompareWithOldEnumsServicesTests
    {
        #region Variables
        private static IServiceCollection serviceCollection;
        private static IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService;
        private static IServiceProvider provider;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsServicesTests()
        {
            Init();
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public void EnumsCompareWithOldEnumsServices_Constructor_Good_Test(string culture)
        {
            Init();

            Assert.NotNull(serviceCollection);
            Assert.NotNull(provider);
            Assert.NotNull(enumsCompareWithOldEnumsService);
            Assert.Equal(2, enumsCompareWithOldEnumsService.Args0Allowables.Count);
            Assert.Equal("en-CA", enumsCompareWithOldEnumsService.Args0Allowables[0]);
            Assert.Equal("fr-CA", enumsCompareWithOldEnumsService.Args0Allowables[1]);
            Assert.Equal("DBFileName", enumsCompareWithOldEnumsService.DBFileName);
            Assert.Null(enumsCompareWithOldEnumsService.fiDB);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_ConsoleWriteEnd_Good_Test(string culture)
        {
            Init();

            bool retBool = await enumsCompareWithOldEnumsService.Setup();
            Assert.True(retBool);

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();

            await enumsCompareWithOldEnumsService.ConsoleWriteEnd();
            Assert.Equal("", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
            Assert.Contains(AppRes.Done, enumsCompareWithOldEnumsService.generateCodeStatusDBService.Status.ToString());

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();
            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Status = new StringBuilder();

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.AppendLine("rouge");

            await enumsCompareWithOldEnumsService.ConsoleWriteEnd();
            Assert.Contains("rouge", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
            Assert.Contains(AppRes.Done, enumsCompareWithOldEnumsService.generateCodeStatusDBService.Status.ToString());

        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_ConsoleWriteError_Good_Test(string culture)
        {
            Init();

            bool retBool = await enumsCompareWithOldEnumsService.Setup();
            Assert.True(retBool);

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();

            await enumsCompareWithOldEnumsService.ConsoleWriteError("testing");
            Assert.Equal("testing\r\n", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_ConsoleWriteStart_Good_Test(string culture)
        {
            Init();

            bool retBool = await enumsCompareWithOldEnumsService.Setup();
            Assert.True(retBool);

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();

            await enumsCompareWithOldEnumsService.ConsoleWriteStart();
            Assert.Equal("", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_DoValidateAppSettings_Good_Test(string culture)
        {
            Init();

            bool retBool = await enumsCompareWithOldEnumsService.Setup();
            Assert.True(retBool);

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();

            await enumsCompareWithOldEnumsService.DoValidateAppSettings();
            Assert.Equal("", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EnumsCompareWithOldEnumsServices_DoValidateAppSettings_Error_Test(string culture)
        {
            Init();

            bool retBool = await enumsCompareWithOldEnumsService.Setup();
            Assert.True(retBool);

            enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error = new StringBuilder();

            var mockServiceProvider = new Mock<IValidateAppSettingsService>();
                mockServiceProvider.Setup(x => x.VerifyAppSettings()).Callback(() =>
                {
                    enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.AppendLine("aaaa");
                });

            await enumsCompareWithOldEnumsService.DoValidateAppSettings();
            Assert.Contains("aaaa", enumsCompareWithOldEnumsService.generateCodeStatusDBService.Error.ToString());
        }
        #endregion Functions public

        #region Functions private
        private void Init()
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

            provider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(provider);

            enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();
            Assert.NotNull(enumsCompareWithOldEnumsService);
        }
        #endregion Functions private
    }

}
