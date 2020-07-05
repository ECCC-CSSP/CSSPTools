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
    public partial class ContactPreferenceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IContactPreferenceService ContactPreferenceService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private ContactPreference contactPreference { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task ContactPreference_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            contactPreference = GetFilledRandomContactPreference("");

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
            // Post ContactPreference
            var actionContactPreferenceAdded = await ContactPreferenceService.Post(contactPreference);
            Assert.Equal(200, ((ObjectResult)actionContactPreferenceAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactPreferenceAdded.Result).Value);
            ContactPreference contactPreferenceAdded = (ContactPreference)((OkObjectResult)actionContactPreferenceAdded.Result).Value;
            Assert.NotNull(contactPreferenceAdded);

            // List<ContactPreference>
            var actionContactPreferenceList = await ContactPreferenceService.GetContactPreferenceList();
            Assert.Equal(200, ((ObjectResult)actionContactPreferenceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactPreferenceList.Result).Value);
            List<ContactPreference> contactPreferenceList = (List<ContactPreference>)((OkObjectResult)actionContactPreferenceList.Result).Value;

            int count = ((List<ContactPreference>)((OkObjectResult)actionContactPreferenceList.Result).Value).Count();
            Assert.True(count > 0);

            // Put ContactPreference
            var actionContactPreferenceUpdated = await ContactPreferenceService.Put(contactPreference);
            Assert.Equal(200, ((ObjectResult)actionContactPreferenceUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactPreferenceUpdated.Result).Value);
            ContactPreference contactPreferenceUpdated = (ContactPreference)((OkObjectResult)actionContactPreferenceUpdated.Result).Value;
            Assert.NotNull(contactPreferenceUpdated);

            // Delete ContactPreference
            var actionContactPreferenceDeleted = await ContactPreferenceService.Delete(contactPreference.ContactPreferenceID);
            Assert.Equal(200, ((ObjectResult)actionContactPreferenceDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactPreferenceDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactPreferenceDeleted.Result).Value;
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
            Services.AddSingleton<IContactPreferenceService, ContactPreferenceService>();

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

            ContactPreferenceService = Provider.GetService<IContactPreferenceService>();
            Assert.NotNull(ContactPreferenceService);

            return await Task.FromResult(true);
        }
        private ContactPreference GetFilledRandomContactPreference(string OmitPropName)
        {
            List<ContactPreference> contactPreferenceListToDelete = (from c in dbLocal.ContactPreferences
                                                               select c).ToList(); 
            
            dbLocal.ContactPreferences.RemoveRange(contactPreferenceListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            ContactPreference contactPreference = new ContactPreference();

            if (OmitPropName != "ContactID") contactPreference.ContactID = 1;
            if (OmitPropName != "TVType") contactPreference.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "MarkerSize") contactPreference.MarkerSize = GetRandomInt(1, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") contactPreference.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactPreference.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "ContactPreferenceID") contactPreference.ContactPreferenceID = 10000000;

                try
                {
                    dbIM.Contacts.Add(new Contact() { ContactID = 1, Id = "f837a0d7-783e-498e-b821-de9c9bd981de" ?? "", ContactTVItemID = 2, LoginEmail = "Charles.LeBlanc2@Canada.ca", FirstName = "Charles", LastName = "LeBlanc", Initial = "G", WebName = "Charles", ContactTitle = (ContactTitleEnum)0, IsAdmin = true, EmailValidated = true, Disabled = false, IsNew = false, SamplingPlanner_ProvincesTVItemID = "7,8,9,10,11,12,", Token = "", LastUpdateDate_UTC = new DateTime(2015, 5, 25, 14, 51, 31), LastUpdateContactTVItemID = 2});
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

            return contactPreference;
        }
        #endregion Functions private
    }
}
