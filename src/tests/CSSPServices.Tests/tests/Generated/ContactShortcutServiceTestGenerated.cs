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
    [Collection("Sequential")]
    public partial class ContactShortcutServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IContactShortcutService ContactShortcutService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private ContactShortcut contactShortcut { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task ContactShortcut_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            contactShortcut = GetFilledRandomContactShortcut("");

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
            // Post ContactShortcut
            var actionContactShortcutAdded = await ContactShortcutService.Post(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutAdded.Result).Value);
            ContactShortcut contactShortcutAdded = (ContactShortcut)((OkObjectResult)actionContactShortcutAdded.Result).Value;
            Assert.NotNull(contactShortcutAdded);

            // List<ContactShortcut>
            var actionContactShortcutList = await ContactShortcutService.GetContactShortcutList();
            Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
            List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value;

            int count = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value).Count();
            Assert.True(count > 0);

            // Put ContactShortcut
            var actionContactShortcutUpdated = await ContactShortcutService.Put(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutUpdated.Result).Value);
            ContactShortcut contactShortcutUpdated = (ContactShortcut)((OkObjectResult)actionContactShortcutUpdated.Result).Value;
            Assert.NotNull(contactShortcutUpdated);

            // Delete ContactShortcut
            var actionContactShortcutDeleted = await ContactShortcutService.Delete(contactShortcut.ContactShortcutID);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactShortcutDeleted.Result).Value;
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
            Services.AddSingleton<IContactShortcutService, ContactShortcutService>();

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

            ContactShortcutService = Provider.GetService<IContactShortcutService>();
            Assert.NotNull(ContactShortcutService);

            return await Task.FromResult(true);
        }
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            List<ContactShortcut> contactShortcutListToDelete = (from c in dbLocal.ContactShortcuts
                                                               select c).ToList(); 
            
            dbLocal.ContactShortcuts.RemoveRange(contactShortcutListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "ContactShortcutID") contactShortcut.ContactShortcutID = 10000000;

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

            return contactShortcut;
        }
        #endregion Functions private
    }
}
