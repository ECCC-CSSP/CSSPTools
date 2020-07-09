using CSSPEnums;
using CSSPModels;
using CSSPWebServices.Services;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using UserServices.Models;
using UserServices.Services;
using Xunit;

namespace CSSPWebServices.Tests
{
    public partial class WebServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IWebService WebService { get; set; }
        private IUserService UserService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBContext db { get; set; }
        private UserModel userModel { get; set; }
        #endregion Properties

        #region Constructors
        public WebServiceTests() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebservicestest.json")
               .AddUserSecrets("b6a0dab2-10cf-4e23-b9bd-63af631406b6")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDBConnString));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IWebService, WebService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            UserService = Provider.GetService<IUserService>();
            Assert.NotNull(UserService);

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Config.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            var actionUserModel = await UserService.Login(loginModel);
            Assert.NotNull(actionUserModel.Value);
            userModel = actionUserModel.Value;

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInContactInfo(userModel.Id);
            Assert.NotNull(LoggedInService.GetLoggedInContactInfo());

            WebService = Provider.GetService<IWebService>();
            Assert.NotNull(WebService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
