using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
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
using Xunit;

namespace ContactServices.Tests
{
    public partial class ContactServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IContactService ContactService { get; set; }
        private LoginModel loginModel { get; set; } = new LoginModel();
        #endregion Properties

        #region Constructors
        public ContactServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Constructors_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(ServiceCollection);
            Assert.NotNull(ContactService);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var retValue = await ContactService.Login(loginModel);
            Assert.IsType<Contact>(retValue.Value);
            Assert.Null(retValue.Result);
            Contact contact = retValue.Value;
            Assert.Equal(2, contact.ContactTVItemID);
            Assert.Equal("Charles".ToLower(), contact.FirstName.ToLower());
            Assert.False(string.IsNullOrWhiteSpace(contact.Token));
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Return_EmailCouldNotBeFound_Test(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.LoginEmail = "NotFound@email.ca";

            var retValue = await ContactService.Login(loginModel);
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CSSPCultureServicesRes.__CouldNotBeFound, CSSPCultureServicesRes.Email, loginModel.LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Return_Error_UnableToLoginAs_WithProvidedPassword_Test2(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.Password = "NotAPassword!";

            var retValue = await ContactService.Login(loginModel);
            Assert.Null(retValue.Value);
            Assert.Equal(400, ((BadRequestObjectResult)retValue.Result).StatusCode);
            string expected = String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail);
            var value = ((BadRequestObjectResult)retValue.Result).Value;
            Assert.Equal(expected, value);

        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("ec761e00-6d1e-461d-8ba9-0247177a97be")
               .Build();

            Assert.NotNull(Configuration);

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IEnums, Enums>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();
            ServiceCollection.AddSingleton<IAspNetUserService, AspNetUserService>();
            ServiceCollection.AddSingleton<ILoginModelService, LoginModelService>();
            ServiceCollection.AddSingleton<IRegisterModelService, RegisterModelService>();
            ServiceCollection.AddSingleton<IContactService, ContactService>();

            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            loginModel.LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(loginModel.LoginEmail);

            loginModel.Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(loginModel.Password);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(TestDB));

            ServiceCollection.AddDbContext<CSSPDBInMemoryContext>(options =>
                    options.UseInMemoryDatabase(TestDB));

            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            ServiceCollection.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLocalFileName);

            ServiceCollection.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ServiceCollection.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            ServiceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(TestDB));

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactService = ServiceProvider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
