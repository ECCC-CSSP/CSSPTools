using CSSPEnums;
using CSSPDBModels;
using CreateGzFileServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CSSPDBServices;
using LoggedInServices;
using CSSPHelperModels;
using CSSPScrambleServices;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemDBService TVItemDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspcreategzfileservicestests.json")
               .AddUserSecrets("724bc44d-9408-48dc-8513-1d2816ee63f9")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDBConnString));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactDBService = Provider.GetService<IContactDBService>();
            Assert.NotNull(ContactDBService);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            if (contact != null)
            {
                Assert.True(true);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                // trying to login
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    Assert.True(false, ((int)response.StatusCode).ToString());
                }

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInContactInfo(contact.LoginEmail);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            Assert.NotNull(CreateGzFileService);

            TVItemDBService = Provider.GetService<ITVItemDBService>();
            Assert.NotNull(TVItemDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
