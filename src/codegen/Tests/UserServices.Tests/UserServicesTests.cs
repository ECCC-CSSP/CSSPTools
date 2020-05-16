using CSSPModels;
using CultureServices.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserServices.Models;
using UserServices.Services;
using Xunit;

namespace UserServices.Tests
{
    public partial class UserServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IUserService userService { get; set; }
        private IServiceProvider provider { get; set; }

        #endregion Properties

        #region Constructors
        public UserServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_Constructors_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(userService);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_CheckPassword_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            string LoginEmail = "Charles.LeBlanc2@canada.ca";
            string Password = "Charles2!";

            var retValue = await userService.CheckPassword(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.IsType<UserModel>(retValue.Value);
            Assert.Null(retValue.Result);
            UserModel userModel = retValue.Value;
            Assert.Equal(2, userModel.ContactTVItemID);
            Assert.Equal("Charles.LeBlanc2@canada.ca".ToLower(), userModel.LoginEmail.ToLower());
            Assert.Equal("Charles".ToLower(), userModel.FirstName.ToLower());
            Assert.Equal("LeBlanc".ToLower(), userModel.LastName.ToLower());
            Assert.False(string.IsNullOrWhiteSpace(userModel.Token));
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_CheckPassword_Good_Return_EmailCouldNotBeFound_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            string LoginEmail = "NotFound_Charles.LeBlanc2@canada.ca";
            string Password = "Charles2!";

            var retValue = await userService.CheckPassword(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CultureServicesRes.__CouldNotBeFound, CultureServicesRes.Email, LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_CheckPassword_Good_Return_Error_UnableToLoginAs_WithProvidedPassword_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            string LoginEmail = "Charles.LeBlanc2@canada.ca";
            string Password = "Not_Charles2!";

            var retValue = await userService.CheckPassword(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Assert.NotNull(configuration);

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IUserService, UserService>();

            IConfigurationSection connectionStringsSection = configuration.GetSection("ConnectionStrings");
            serviceCollection.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();
            Assert.NotNull(connectionStrings);

            serviceCollection.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(connectionStrings.CSSPDB2));

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.CSSPDB2));

            serviceCollection.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            provider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(provider);

            userService = provider.GetService<IUserService>();
            Assert.NotNull(userService);

            await userService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);

        }
        #endregion Functions private
    }

}
