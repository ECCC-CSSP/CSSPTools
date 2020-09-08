/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
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
    public partial class ContactShortcutDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IContactShortcutDBService ContactShortcutDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private ContactShortcut contactShortcut { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactShortcutDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            contactShortcut = GetFilledRandomContactShortcut("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactShortcut_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionContactShortcutList = await ContactShortcutDBService.GetContactShortcutList();
            Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
            List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value;

            count = contactShortcutList.Count();

            ContactShortcut contactShortcut = GetFilledRandomContactShortcut("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // contactShortcut.ContactShortcutID   (Int32)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactShortcutID = 0;

            var actionContactShortcut = await ContactShortcutDBService.Put(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactShortcutID = 10000000;
            actionContactShortcut = await ContactShortcutDBService.Put(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
            // contactShortcut.ContactID   (Int32)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactID = 0;
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contactShortcut.ShortCutText   (String)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ShortCutText = GetRandomString("", 101);
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            //Assert.AreEqual(count, contactShortcutDBService.GetContactShortcutList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // contactShortcut.ShortCutAddress   (String)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ShortCutAddress = GetRandomString("", 201);
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            //Assert.AreEqual(count, contactShortcutDBService.GetContactShortcutList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contactShortcut.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateDate_UTC = new DateTime();
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contactShortcut.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateContactTVItemID = 0;
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateContactTVItemID = 1;
            actionContactShortcut = await ContactShortcutDBService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post ContactShortcut
            var actionContactShortcutAdded = await ContactShortcutDBService.Post(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutAdded.Result).Value);
            ContactShortcut contactShortcutAdded = (ContactShortcut)((OkObjectResult)actionContactShortcutAdded.Result).Value;
            Assert.NotNull(contactShortcutAdded);

            // List<ContactShortcut>
            var actionContactShortcutList = await ContactShortcutDBService.GetContactShortcutList();
            Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
            List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value;

            int count = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value).Count();
            Assert.True(count > 0);

            // List<ContactShortcut> with skip and take
            var actionContactShortcutListSkipAndTake = await ContactShortcutDBService.GetContactShortcutList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value);
            List<ContactShortcut> contactShortcutListSkipAndTake = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(contactShortcutList[0].ContactShortcutID == contactShortcutListSkipAndTake[0].ContactShortcutID);

            // Get ContactShortcut With ContactShortcutID
            var actionContactShortcutGet = await ContactShortcutDBService.GetContactShortcutWithContactShortcutID(contactShortcutList[0].ContactShortcutID);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutGet.Result).Value);
            ContactShortcut contactShortcutGet = (ContactShortcut)((OkObjectResult)actionContactShortcutGet.Result).Value;
            Assert.NotNull(contactShortcutGet);
            Assert.Equal(contactShortcutGet.ContactShortcutID, contactShortcutList[0].ContactShortcutID);

            // Put ContactShortcut
            var actionContactShortcutUpdated = await ContactShortcutDBService.Put(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutUpdated.Result).Value);
            ContactShortcut contactShortcutUpdated = (ContactShortcut)((OkObjectResult)actionContactShortcutUpdated.Result).Value;
            Assert.NotNull(contactShortcutUpdated);

            // Delete ContactShortcut
            var actionContactShortcutDeleted = await ContactShortcutDBService.Delete(contactShortcut.ContactShortcutID);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactShortcutDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
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
            Services.AddSingleton<IContactShortcutDBService, ContactShortcutDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            ContactShortcutDBService = Provider.GetService<IContactShortcutDBService>();
            Assert.NotNull(ContactShortcutDBService);

            return await Task.FromResult(true);
        }
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;



            return contactShortcut;
        }
        private void CheckContactShortcutFields(List<ContactShortcut> contactShortcutList)
        {
            Assert.False(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutText));
            Assert.False(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutAddress));
        }

        #endregion Functions private
    }
}
