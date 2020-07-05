/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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
    [Collection("Sequential")]
    public partial class EmailDistributionListContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEmailDistributionListContactService EmailDistributionListContactService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private EmailDistributionListContact emailDistributionListContact { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task EmailDistributionListContact_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            if (LoggedInService.IsLocal)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post EmailDistributionListContact
            var actionEmailDistributionListContactAdded = await EmailDistributionListContactService.Post(emailDistributionListContact);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactAdded.Result).Value);
            EmailDistributionListContact emailDistributionListContactAdded = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactAdded.Result).Value;
            Assert.NotNull(emailDistributionListContactAdded);

            // List<EmailDistributionListContact>
            var actionEmailDistributionListContactList = await EmailDistributionListContactService.GetEmailDistributionListContactList();
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactList.Result).Value);
            List<EmailDistributionListContact> emailDistributionListContactList = (List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value;

            int count = ((List<EmailDistributionListContact>)((OkObjectResult)actionEmailDistributionListContactList.Result).Value).Count();
            Assert.True(count > 0);

            // Put EmailDistributionListContact
            var actionEmailDistributionListContactUpdated = await EmailDistributionListContactService.Put(emailDistributionListContact);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactUpdated.Result).Value);
            EmailDistributionListContact emailDistributionListContactUpdated = (EmailDistributionListContact)((OkObjectResult)actionEmailDistributionListContactUpdated.Result).Value;
            Assert.NotNull(emailDistributionListContactUpdated);

            // Delete EmailDistributionListContact
            var actionEmailDistributionListContactDeleted = await EmailDistributionListContactService.Delete(emailDistributionListContact.EmailDistributionListContactID);
            Assert.Equal(200, ((ObjectResult)actionEmailDistributionListContactDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailDistributionListContactDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionEmailDistributionListContactDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IEmailDistributionListContactService, EmailDistributionListContactService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            EmailDistributionListContactService = Provider.GetService<IEmailDistributionListContactService>();
            Assert.NotNull(EmailDistributionListContactService);

            return await Task.FromResult(true);
        }
        private EmailDistributionListContact GetFilledRandomEmailDistributionListContact(string OmitPropName)
        {
            List<EmailDistributionListContact> emailDistributionListContactListToDelete = (from c in dbLocal.EmailDistributionListContacts
                                                               select c).ToList(); 
            
            dbLocal.EmailDistributionListContacts.RemoveRange(emailDistributionListContactListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListContact.EmailDistributionListID = 1;
            if (OmitPropName != "IsCC") emailDistributionListContact.IsCC = true;
            if (OmitPropName != "Name") emailDistributionListContact.Name = GetRandomString("", 5);
            if (OmitPropName != "Email") emailDistributionListContact.Email = GetRandomEmail();
            if (OmitPropName != "CMPRainfallSeasonal") emailDistributionListContact.CMPRainfallSeasonal = true;
            if (OmitPropName != "CMPWastewater") emailDistributionListContact.CMPWastewater = true;
            if (OmitPropName != "EmergencyWeather") emailDistributionListContact.EmergencyWeather = true;
            if (OmitPropName != "EmergencyWastewater") emailDistributionListContact.EmergencyWastewater = true;
            if (OmitPropName != "ReopeningAllTypes") emailDistributionListContact.ReopeningAllTypes = true;
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContact.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "EmailDistributionListContactID") emailDistributionListContact.EmailDistributionListContactID = 10000000;

                try
                {
                    dbIM.EmailDistributionLists.Add(new EmailDistributionList() { EmailDistributionListID = 1, ParentTVItemID = 5, Ordinal = 1, LastUpdateDate_UTC = new DateTime(2017, 6, 14, 18, 7, 57), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return emailDistributionListContact;
        }
        #endregion Functions private
    }
}
