using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public class LocalServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ILocalService LocalService { get; set; }
        #endregion Properties

        #region Constructors
        public LocalServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalService_CheckInternetConnection_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(await LocalService.CheckInternetConnection());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalService_Scramble_And_DeScramble_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> TextToScrambleList = new List<string>()
            {
                "bonjour", "rouge", "1214123", "lsjf slefij", "@#$%^!&", "     "
            };

            foreach (string toScramble in TextToScrambleList)
            {
                string scrambleText = await LocalService.Scramble(toScramble);
                Assert.Equal(toScramble.Length + 1, scrambleText.Length);
                Assert.Equal(toScramble, await LocalService.Descramble(scrambleText));
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspservicestests.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ILocalService, LocalService>();

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            LocalService = ServiceProvider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
