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

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class ContactDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IContactDBLocalIMService ContactDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public ContactDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            contact = GetFilledRandomContact("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Contact_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionContactList = await ContactDBLocalIMService.GetContactList();
            Assert.Equal(200, ((ObjectResult)actionContactList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactList.Result).Value);
            List<Contact> contactList = (List<Contact>)((OkObjectResult)actionContactList.Result).Value;

            count = contactList.Count();

            Contact contact = GetFilledRandomContact("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // contact.ContactID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactID = 0;

            var actionContact = await ContactDBLocalIMService.Put(contact);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactID = 10000000;
            actionContact = await ContactDBLocalIMService.Put(contact);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id", AllowableTVtypeList = )]
            // [CSSPMaxLength(450)]
            // contact.Id   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("Id");
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Id = GetRandomString("", 451);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contact.ContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 0;
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 1;
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(6)]
            // contact.LoginEmail   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("LoginEmail");
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 5);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());
            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 256);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.FirstName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("FirstName");
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.FirstName = GetRandomString("", 101);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.LastName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("LastName");
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastName = GetRandomString("", 101);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // contact.Initial   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Initial = GetRandomString("", 51);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.WebName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("WebName");
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.WebName = GetRandomString("", 101);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // contact.ContactTitle   (ContactTitleEnum)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTitle = (ContactTitleEnum)1000000;
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsAdmin   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.EmailValidated   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.Disabled   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsNew   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // contact.SamplingPlanner_ProvincesTVItemID   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.SamplingPlanner_ProvincesTVItemID = GetRandomString("", 201);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(255)]
            // contact.Token   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Token = GetRandomString("", 256);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactDBLocalIMService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contact.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateDate_UTC = new DateTime();
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contact.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 0;
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 1;
            actionContact = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            contact.ContactID = 10000000;

            // Post Contact
            var actionContactAdded = await ContactDBLocalIMService.Post(contact, AddContactTypeEnum.Register);
            Assert.Equal(200, ((ObjectResult)actionContactAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactAdded.Result).Value);
            Contact contactAdded = (Contact)((OkObjectResult)actionContactAdded.Result).Value;
            Assert.NotNull(contactAdded);

            // List<Contact>
            var actionContactList = await ContactDBLocalIMService.GetContactList();
            Assert.Equal(200, ((ObjectResult)actionContactList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactList.Result).Value);
            List<Contact> contactList = (List<Contact>)((OkObjectResult)actionContactList.Result).Value;

            int count = ((List<Contact>)((OkObjectResult)actionContactList.Result).Value).Count();
            Assert.True(count > 0);

            // Get Contact With ContactID
            var actionContactGet = await ContactDBLocalIMService.GetContactWithContactID(contactList[0].ContactID);
            Assert.Equal(200, ((ObjectResult)actionContactGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactGet.Result).Value);
            Contact contactGet = (Contact)((OkObjectResult)actionContactGet.Result).Value;
            Assert.NotNull(contactGet);
            Assert.Equal(contactGet.ContactID, contactList[0].ContactID);

            // Put Contact
            var actionContactUpdated = await ContactDBLocalIMService.Put(contact);
            Assert.Equal(200, ((ObjectResult)actionContactUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactUpdated.Result).Value);
            Contact contactUpdated = (Contact)((OkObjectResult)actionContactUpdated.Result).Value;
            Assert.NotNull(contactUpdated);

            // Delete Contact
            var actionContactDeleted = await ContactDBLocalIMService.Delete(contact.ContactID);
            Assert.Equal(200, ((ObjectResult)actionContactDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBLocalIMService, ContactDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            ContactDBLocalIMService = Provider.GetService<IContactDBLocalIMService>();
            Assert.NotNull(ContactDBLocalIMService);

            return await Task.FromResult(true);
        }
        private Contact GetFilledRandomContact(string OmitPropName)
        {
            Contact contact = new Contact();

            if (OmitPropName != "Id") contact.Id = "023566a4-4a25-4484-88f5-584aa8e1da38";
            if (OmitPropName != "ContactTVItemID") contact.ContactTVItemID = 2;
            if (OmitPropName != "LoginEmail") contact.LoginEmail = GetRandomEmail();
            if (OmitPropName != "FirstName") contact.FirstName = GetRandomString("", 5);
            if (OmitPropName != "LastName") contact.LastName = GetRandomString("", 5);
            if (OmitPropName != "Initial") contact.Initial = GetRandomString("", 5);
            if (OmitPropName != "WebName") contact.WebName = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") contact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));
            if (OmitPropName != "IsAdmin") contact.IsAdmin = true;
            if (OmitPropName != "EmailValidated") contact.EmailValidated = true;
            if (OmitPropName != "Disabled") contact.Disabled = true;
            if (OmitPropName != "IsNew") contact.IsNew = true;
            if (OmitPropName != "SamplingPlanner_ProvincesTVItemID") contact.SamplingPlanner_ProvincesTVItemID = GetRandomString("", 5);
            if (OmitPropName != "Token") contact.Token = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contact.LastUpdateContactTVItemID = 2;



            return contact;
        }
        private void CheckContactFields(List<Contact> contactList)
        {
            Assert.False(string.IsNullOrWhiteSpace(contactList[0].Id));
            Assert.False(string.IsNullOrWhiteSpace(contactList[0].LoginEmail));
            Assert.False(string.IsNullOrWhiteSpace(contactList[0].FirstName));
            Assert.False(string.IsNullOrWhiteSpace(contactList[0].LastName));
            if (!string.IsNullOrWhiteSpace(contactList[0].Initial))
            {
                Assert.False(string.IsNullOrWhiteSpace(contactList[0].Initial));
            }
            Assert.False(string.IsNullOrWhiteSpace(contactList[0].WebName));
            if (contactList[0].ContactTitle != null)
            {
                Assert.NotNull(contactList[0].ContactTitle);
            }
            if (!string.IsNullOrWhiteSpace(contactList[0].SamplingPlanner_ProvincesTVItemID))
            {
                Assert.False(string.IsNullOrWhiteSpace(contactList[0].SamplingPlanner_ProvincesTVItemID));
            }
            if (!string.IsNullOrWhiteSpace(contactList[0].Token))
            {
                Assert.False(string.IsNullOrWhiteSpace(contactList[0].Token));
            }
        }

        #endregion Functions private
    }
}
