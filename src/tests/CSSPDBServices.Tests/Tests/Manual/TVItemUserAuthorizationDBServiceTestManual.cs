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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemUserAuthorizationDBServiceManualTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private TVItemUserAuthorization tvItemUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationDBServiceManualTests()
        {

        }
        #endregion Constructors

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationServiceManual_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(TVItemUserAuthorizationDBService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationServiceManual_GetTVItemUserAuthorizationWithContactTVItemID_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionTVItemUserAuthorization = await TVItemUserAuthorizationDBService.GetTVItemUserAuthorizationWithContactTVItemID(2);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorization.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorization.Result).Value);
            List<TVItemUserAuthorization> TVItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorization.Result).Value;
            Assert.NotNull(TVItemUserAuthorizationList);
            Assert.True(TVItemUserAuthorizationList.Count > 0);
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemUserAuthorizationDBService, TVItemUserAuthorizationDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            TVItemUserAuthorizationDBService = Provider.GetService<ITVItemUserAuthorizationDBService>();
            Assert.NotNull(TVItemUserAuthorizationDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
