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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class ContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAspNetUserService AspNetUserService { get; set; }
        private IContactService ContactService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public ContactServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Contact_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            contact = GetFilledRandomContact("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Contact_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionContactList = await ContactService.GetContactList();
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

            var actionContact = await ContactService.Put(contact);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactID = 10000000;
            actionContact = await ContactService.Put(contact);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id", AllowableTVtypeList = )]
            // [CSSPMaxLength(450)]
            // contact.Id   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("Id");
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Id = GetRandomString("", 451);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contact.ContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 0;
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 1;
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
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
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 5);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());
            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 256);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.FirstName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("FirstName");
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.FirstName = GetRandomString("", 101);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.LastName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("LastName");
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastName = GetRandomString("", 101);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // contact.Initial   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Initial = GetRandomString("", 51);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // contact.WebName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("WebName");
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.WebName = GetRandomString("", 101);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // contact.ContactTitle   (ContactTitleEnum)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTitle = (ContactTitleEnum)1000000;
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
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
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(255)]
            // contact.Token   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Token = GetRandomString("", 256);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.First);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            //Assert.AreEqual(count, contactService.GetContactList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contact.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateDate_UTC = new DateTime();
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);
            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // contact.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 0;
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 1;
            actionContact = await ContactService.Post(contact, AddContactTypeEnum.LoggedIn);
            Assert.IsType<BadRequestObjectResult>(actionContact.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post Contact
            var actionContactAdded = await ContactService.Post(contact, AddContactTypeEnum.Register);
            Assert.Equal(200, ((ObjectResult)actionContactAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactAdded.Result).Value);
            Contact contactAdded = (Contact)((OkObjectResult)actionContactAdded.Result).Value;
            Assert.NotNull(contactAdded);

            // List<Contact>
            var actionContactList = await ContactService.GetContactList();
            Assert.Equal(200, ((ObjectResult)actionContactList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactList.Result).Value);
            List<Contact> contactList = (List<Contact>)((OkObjectResult)actionContactList.Result).Value;

            int count = ((List<Contact>)((OkObjectResult)actionContactList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<Contact> with skip and take
                var actionContactListSkipAndTake = await ContactService.GetContactList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionContactListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionContactListSkipAndTake.Result).Value);
                List<Contact> contactListSkipAndTake = (List<Contact>)((OkObjectResult)actionContactListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<Contact>)((OkObjectResult)actionContactListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(contactList[0].ContactID == contactListSkipAndTake[0].ContactID);
            }

            // Get Contact With ContactID
            var actionContactGet = await ContactService.GetContactWithContactID(contactList[0].ContactID);
            Assert.Equal(200, ((ObjectResult)actionContactGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactGet.Result).Value);
            Contact contactGet = (Contact)((OkObjectResult)actionContactGet.Result).Value;
            Assert.NotNull(contactGet);
            Assert.Equal(contactGet.ContactID, contactList[0].ContactID);

            // Put Contact
            var actionContactUpdated = await ContactService.Put(contact);
            Assert.Equal(200, ((ObjectResult)actionContactUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactUpdated.Result).Value);
            Contact contactUpdated = (Contact)((OkObjectResult)actionContactUpdated.Result).Value;
            Assert.NotNull(contactUpdated);

            // Delete Contact
            var actionContactDeleted = await ContactService.Delete(contact.ContactID);
            Assert.Equal(200, ((ObjectResult)actionContactDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionContactDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionContactDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactService, ContactService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            ContactService = Provider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            return await Task.FromResult(true);
        }
        private Contact GetFilledRandomContact(string OmitPropName)
        {
            List<Contact> contactListToDelete = (from c in dbLocal.Contacts
                                                               select c).ToList(); 
            
            dbLocal.Contacts.RemoveRange(contactListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "ContactID") contact.ContactID = 10000000;

                try
                {
                    dbIM.AspNetUsers.Add(new AspNetUser() { Id = "023566a4-4a25-4484-88f5-584aa8e1da38", Email = "Test.User1@Canada.ca", UserName = "Test.User1@Canada.ca", });
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
