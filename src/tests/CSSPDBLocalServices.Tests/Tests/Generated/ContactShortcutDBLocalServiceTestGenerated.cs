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
using LocalServices;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class ContactShortcutDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IContactShortcutDBLocalService ContactShortcutDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private ContactShortcut contactShortcut { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocal]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactShortcutDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            contactShortcut = GetFilledRandomContactShortcut("");

            await DoCRUDDBLocalTest();
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

            var actionContactShortcutList = await ContactShortcutDBLocalService.GetContactShortcutList();
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

            var actionContactShortcut = await ContactShortcutDBLocalService.Put(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactShortcutID = 10000000;
            actionContactShortcut = await ContactShortcutDBLocalService.Put(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
            // contactShortcut.ContactID   (Int32)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactID = 0;
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contactShortcut.ShortCutText   (String)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ShortCutText = GetRandomString("", 101);
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            //Assert.AreEqual(count, contactShortcutDBLocalService.GetContactShortcutList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // contactShortcut.ShortCutAddress   (String)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ShortCutAddress = GetRandomString("", 201);
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            //Assert.AreEqual(count, contactShortcutDBLocalService.GetContactShortcutList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contactShortcut.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateDate_UTC = new DateTime();
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);
            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contactShortcut.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateContactTVItemID = 0;
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.LastUpdateContactTVItemID = 1;
            actionContactShortcut = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.IsType<BadRequestObjectResult>(actionContactShortcut.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post ContactShortcut
            var actionContactShortcutAdded = await ContactShortcutDBLocalService.Post(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutAdded.Result).Value);
            ContactShortcut contactShortcutAdded = (ContactShortcut)((OkObjectResult)actionContactShortcutAdded.Result).Value;
            Assert.NotNull(contactShortcutAdded);

            // List<ContactShortcut>
            var actionContactShortcutList = await ContactShortcutDBLocalService.GetContactShortcutList();
            Assert.Equal(200, ((ObjectResult)actionContactShortcutList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutList.Result).Value);
            List<ContactShortcut> contactShortcutList = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value;

            int count = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutList.Result).Value).Count();
            Assert.True(count > 0);

            // List<ContactShortcut> with skip and take
            var actionContactShortcutListSkipAndTake = await ContactShortcutDBLocalService.GetContactShortcutList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value);
            List<ContactShortcut> contactShortcutListSkipAndTake = (List<ContactShortcut>)((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<ContactShortcut>)((OkObjectResult)actionContactShortcutListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(contactShortcutList[0].ContactShortcutID == contactShortcutListSkipAndTake[0].ContactShortcutID);

            // Get ContactShortcut With ContactShortcutID
            var actionContactShortcutGet = await ContactShortcutDBLocalService.GetContactShortcutWithContactShortcutID(contactShortcutList[0].ContactShortcutID);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutGet.Result).Value);
            ContactShortcut contactShortcutGet = (ContactShortcut)((OkObjectResult)actionContactShortcutGet.Result).Value;
            Assert.NotNull(contactShortcutGet);
            Assert.Equal(contactShortcutGet.ContactShortcutID, contactShortcutList[0].ContactShortcutID);

            // Put ContactShortcut
            var actionContactShortcutUpdated = await ContactShortcutDBLocalService.Put(contactShortcut);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutUpdated.Result).Value);
            ContactShortcut contactShortcutUpdated = (ContactShortcut)((OkObjectResult)actionContactShortcutUpdated.Result).Value;
            Assert.NotNull(contactShortcutUpdated);

            // Delete ContactShortcut
            var actionContactShortcutDeleted = await ContactShortcutDBLocalService.Delete(contactShortcut.ContactShortcutID);
            Assert.Equal(200, ((ObjectResult)actionContactShortcutDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactShortcutDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactShortcutDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IContactShortcutDBLocalService, ContactShortcutDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            ContactShortcutDBLocalService = Provider.GetService<IContactShortcutDBLocalService>();
            Assert.NotNull(ContactShortcutDBLocalService);

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

            try
            {
                dbLocal.Contacts.Add(new Contact() { ContactID = 1, Id = "f837a0d7-783e-498e-b821-de9c9bd981de" ?? "", ContactTVItemID = 2, LoginEmail = "Charles.LeBlanc2@Canada.ca", FirstName = "Charles", LastName = "LeBlanc", Initial = "G", WebName = "Charles", ContactTitle = (ContactTitleEnum)0, IsAdmin = true, EmailValidated = true, Disabled = false, IsNew = false, SamplingPlanner_ProvincesTVItemID = "7,8,9,10,11,12,", Token = "", LastUpdateDate_UTC = new DateTime(2015, 5, 25, 14, 51, 31), LastUpdateContactTVItemID = 2});
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


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
