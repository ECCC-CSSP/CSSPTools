using System;
using System.IO;
using System.Threading.Tasks;
using CSSPDesktopServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CSSPDesktopServices.Tests
{
    public class LoginTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Login_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            string Password = Configuration.GetValue<string>("Password");

            bool retBool = await CSSPDesktopService.Login(LoginEmail, Password);
            Assert.True(retBool);
        }
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdesktopservices.json")
               .AddUserSecrets("6277018e-7198-41f3-9906-f8a6ccfa30e5")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
            Assert.NotNull(CSSPDesktopService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
