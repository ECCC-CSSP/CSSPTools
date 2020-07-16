using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
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
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICultureService CultureService { get; set; }
        private IUserService UserService { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
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
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(ServiceCollection);
            Assert.NotNull(UserService);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_Login_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var retValue = await UserService.Login(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.IsType<UserModel>(retValue.Value);
            Assert.Null(retValue.Result);
            UserModel userModel = retValue.Value;
            Assert.Equal(2, userModel.ContactTVItemID);
            Assert.Equal("Charles".ToLower(), userModel.FirstName.ToLower());
            Assert.False(string.IsNullOrWhiteSpace(userModel.Token));
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_Login_Good_Return_EmailCouldNotBeFound_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginEmail = "NotFound@email.ca";

            var retValue = await UserService.Login(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CultureServicesRes.__CouldNotBeFound, CultureServicesRes.Email, LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UserService_Login_Good_Return_Error_UnableToLoginAs_WithProvidedPassword_Test2(string culture)
        {
            Assert.True(await Setup(culture));

            Password = "NotAPassword!";

            var retValue = await UserService.Login(new LoginModel() { LoginEmail = LoginEmail, Password = Password });
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_userservices.json")
               .AddUserSecrets("ec761e00-6d1e-461d-8ba9-0247177a97be")
               .Build();

            Assert.NotNull(Configuration);

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICultureService, CultureService>();
            ServiceCollection.AddSingleton<IUserService, UserService>();

            string CSSPDB2 = Configuration.GetValue<string>("CSSPDB2");
            Assert.NotNull(CSSPDB2);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(CSSPDB2));

            ServiceCollection.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            ServiceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDB2));

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CultureService = ServiceProvider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            UserService = ServiceProvider.GetService<IUserService>();
            Assert.NotNull(UserService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
