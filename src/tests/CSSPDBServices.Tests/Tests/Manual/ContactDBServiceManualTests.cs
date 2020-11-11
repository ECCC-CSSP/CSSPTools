/* 
 * Manually edited
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LoggedInServices;
using CSSPHelperModels;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class ContactDBServiceManualTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private Contact contact { get; set; }
        private string Password { get; set; }
        #endregion Properties

        #region Constructors
        public ContactDBServiceManualTests()
        {

        }
        #endregion Constructors

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactServiceManual_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(ContactDBService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactServiceManual_Register_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                LoginEmail = "Allo@test.com",
                FirstName = "Testing",
                Initial = "T",
                LastName = "Rouge",
                Password = Password,
                ConfirmPassword = Password
            };

            var actionResContact = await ContactDBService.Register(registerModel);
            Assert.Equal(200, ((ObjectResult)actionResContact.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionResContact.Result).Value);
            Contact contactRes = (Contact)((OkObjectResult)actionResContact.Result).Value;
            Assert.NotNull(contactRes);

            var actionRe = await ContactDBService.RemoveAspNetUserAndContact(contactRes.Id);
            Assert.Equal(200, ((ObjectResult)actionRe.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRe.Result).Value);
            bool boolRes = (bool)((OkObjectResult)actionRe.Result).Value;
            Assert.True(boolRes);

        }
        #endregion Tests 

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
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
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            string Id = Configuration.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            ContactDBService = Provider.GetService<IContactDBService>();
            Assert.NotNull(ContactDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
