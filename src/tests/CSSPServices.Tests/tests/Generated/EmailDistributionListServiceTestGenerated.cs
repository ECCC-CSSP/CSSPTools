/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
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

namespace CSSPServices.Tests
{
    public partial class EmailDistributionListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEmailDistributionListService EmailDistributionListService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task EmailDistributionList_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList(""); 

               // List<EmailDistributionList>
               var actionEmailDistributionListList = await EmailDistributionListService.GetEmailDistributionListList();
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListList.Result).Value);
               List<EmailDistributionList> emailDistributionListList = (List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value;

               int count = ((List<EmailDistributionList>)((OkObjectResult)actionEmailDistributionListList.Result).Value).Count();
                Assert.True(count > 0);

               // Post EmailDistributionList
               var actionEmailDistributionListAdded = await EmailDistributionListService.Post(emailDistributionList);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListAdded.Result).Value);
               EmailDistributionList emailDistributionListAdded = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListAdded.Result).Value;
               Assert.NotNull(emailDistributionListAdded);

               // Put EmailDistributionList
               var actionEmailDistributionListUpdated = await EmailDistributionListService.Put(emailDistributionList);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListUpdated.Result).Value);
               EmailDistributionList emailDistributionListUpdated = (EmailDistributionList)((OkObjectResult)actionEmailDistributionListUpdated.Result).Value;
               Assert.NotNull(emailDistributionListUpdated);

               // Delete EmailDistributionList
               var actionEmailDistributionListDeleted = await EmailDistributionListService.Delete(emailDistributionList.EmailDistributionListID);
               Assert.Equal(200, ((ObjectResult)actionEmailDistributionListDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionEmailDistributionListDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionEmailDistributionListDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListService, EmailDistributionListService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            EmailDistributionListService = Provider.GetService<IEmailDistributionListService>();
            Assert.NotNull(EmailDistributionListService);

            return await Task.FromResult(true);
        }
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "ParentTVItemID") emailDistributionList.ParentTVItemID = 5;
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        #endregion Functions private
    }
}
