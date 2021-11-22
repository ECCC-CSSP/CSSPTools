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
    public partial class AspNetUserServiceTest : TestHelper
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
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private AspNetUser aspNetUser { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task AspNetUser_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            aspNetUser = GetFilledRandomAspNetUser("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    // await DoCRUDTest();
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
        public async Task AspNetUser_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionAspNetUserList = await AspNetUserService.GetAspNetUserList();
            Assert.Equal(200, ((ObjectResult)actionAspNetUserList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserList.Result).Value);
            List<AspNetUser> aspNetUserList = (List<AspNetUser>)((OkObjectResult)actionAspNetUserList.Result).Value;

            count = aspNetUserList.Count();

            AspNetUser aspNetUser = GetFilledRandomAspNetUser("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // [CSSPMaxLength(450)]
            // aspNetUser.Id   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.Id = "";

            var actionAspNetUser = await AspNetUserService.Put(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.Id = "silefjilsefjsliejlsjflisjefl";
            actionAspNetUser = await AspNetUserService.Put(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(256)]
            // aspNetUser.Email   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.Email = GetRandomString("", 257);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // aspNetUser.EmailConfirmed   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // aspNetUser.PasswordHash   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // aspNetUser.SecurityStamp   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // aspNetUser.PhoneNumber   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // aspNetUser.PhoneNumberConfirmed   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // aspNetUser.TwoFactorEnabled   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // aspNetUser.LockoutEndDateUtc   (DateTime)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.LockoutEndDateUtc = new DateTime(1979, 1, 1);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);

            // -----------------------------------
            // Is NOT Nullable
            // aspNetUser.LockoutEnabled   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // aspNetUser.AccessFailedCount   (Int32)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.AccessFailedCount = -1;
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());
            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.AccessFailedCount = 10001;
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(256)]
            // aspNetUser.UserName   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("UserName");
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.UserName = GetRandomString("", 257);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(256)]
            // aspNetUser.NormalizedUserName   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.NormalizedUserName = GetRandomString("", 257);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(256)]
            // aspNetUser.NormalizedEmail   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.NormalizedEmail = GetRandomString("", 257);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(256)]
            // aspNetUser.ConcurrencyStamp   (String)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.ConcurrencyStamp = GetRandomString("", 257);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
            //Assert.AreEqual(count, aspNetUserService.GetAspNetUserList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // aspNetUser.LockoutEnd   (DateTime)
            // -----------------------------------

            aspNetUser = null;
            aspNetUser = GetFilledRandomAspNetUser("");
            aspNetUser.LockoutEnd = new DateTime(1979, 1, 1);
            actionAspNetUser = await AspNetUserService.Post(aspNetUser);
            Assert.IsType<BadRequestObjectResult>(actionAspNetUser.Result);
        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post AspNetUser
            var actionAspNetUserAdded = await AspNetUserService.Post(aspNetUser);
            Assert.Equal(200, ((ObjectResult)actionAspNetUserAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserAdded.Result).Value);
            AspNetUser aspNetUserAdded = (AspNetUser)((OkObjectResult)actionAspNetUserAdded.Result).Value;
            Assert.NotNull(aspNetUserAdded);

            // List<AspNetUser>
            var actionAspNetUserList = await AspNetUserService.GetAspNetUserList();
            Assert.Equal(200, ((ObjectResult)actionAspNetUserList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserList.Result).Value);
            List<AspNetUser> aspNetUserList = (List<AspNetUser>)((OkObjectResult)actionAspNetUserList.Result).Value;

            int count = ((List<AspNetUser>)((OkObjectResult)actionAspNetUserList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<AspNetUser> with skip and take
                var actionAspNetUserListSkipAndTake = await AspNetUserService.GetAspNetUserList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionAspNetUserListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAspNetUserListSkipAndTake.Result).Value);
                List<AspNetUser> aspNetUserListSkipAndTake = (List<AspNetUser>)((OkObjectResult)actionAspNetUserListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<AspNetUser>)((OkObjectResult)actionAspNetUserListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(aspNetUserList[0].Id == aspNetUserListSkipAndTake[0].Id);
            }

            // Get AspNetUser With Id
            var actionAspNetUserGet = await AspNetUserService.GetAspNetUserWithId(aspNetUserList[0].Id);
            Assert.Equal(200, ((ObjectResult)actionAspNetUserGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserGet.Result).Value);
            AspNetUser aspNetUserGet = (AspNetUser)((OkObjectResult)actionAspNetUserGet.Result).Value;
            Assert.NotNull(aspNetUserGet);
            Assert.Equal(aspNetUserGet.Id, aspNetUserList[0].Id);

            // Put AspNetUser
            var actionAspNetUserUpdated = await AspNetUserService.Put(aspNetUser);
            Assert.Equal(200, ((ObjectResult)actionAspNetUserUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserUpdated.Result).Value);
            AspNetUser aspNetUserUpdated = (AspNetUser)((OkObjectResult)actionAspNetUserUpdated.Result).Value;
            Assert.NotNull(aspNetUserUpdated);

            // Delete AspNetUser
            var actionAspNetUserDeleted = await AspNetUserService.Delete(aspNetUser.Id);
            Assert.Equal(200, ((ObjectResult)actionAspNetUserDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAspNetUserDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAspNetUserDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();

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

            AspNetUserService = Provider.GetService<IAspNetUserService>();
            Assert.NotNull(AspNetUserService);

            return await Task.FromResult(true);
        }
        private AspNetUser GetFilledRandomAspNetUser(string OmitPropName)
        {
            List<AspNetUser> aspNetUserListToDelete = (from c in dbLocal.AspNetUsers
                                                               select c).ToList(); 
            
            dbLocal.AspNetUsers.RemoveRange(aspNetUserListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            AspNetUser aspNetUser = new AspNetUser();

            if (OmitPropName != "Email") aspNetUser.Email = GetRandomString("", 5);
            if (OmitPropName != "EmailConfirmed") aspNetUser.EmailConfirmed = true;
            if (OmitPropName != "PasswordHash") aspNetUser.PasswordHash = GetRandomString("", 20);
            if (OmitPropName != "SecurityStamp") aspNetUser.SecurityStamp = GetRandomString("", 20);
            if (OmitPropName != "PhoneNumber") aspNetUser.PhoneNumber = GetRandomString("", 20);
            if (OmitPropName != "PhoneNumberConfirmed") aspNetUser.PhoneNumberConfirmed = true;
            if (OmitPropName != "TwoFactorEnabled") aspNetUser.TwoFactorEnabled = true;
            if (OmitPropName != "LockoutEndDateUtc") aspNetUser.LockoutEndDateUtc = new DateTime(2005, 3, 6);
            if (OmitPropName != "LockoutEnabled") aspNetUser.LockoutEnabled = true;
            if (OmitPropName != "AccessFailedCount") aspNetUser.AccessFailedCount = GetRandomInt(0, 10000);
            if (OmitPropName != "UserName") aspNetUser.UserName = GetRandomString("", 5);
            if (OmitPropName != "NormalizedUserName") aspNetUser.NormalizedUserName = GetRandomString("", 5);
            if (OmitPropName != "NormalizedEmail") aspNetUser.NormalizedEmail = GetRandomString("", 5);
            if (OmitPropName != "ConcurrencyStamp") aspNetUser.ConcurrencyStamp = GetRandomString("", 5);
            if (OmitPropName != "LockoutEnd") aspNetUser.LockoutEnd = new DateTime(2005, 3, 6);

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "AspNetUserID") aspNetUser.Id = "lsiejflisjflsjefilsjlijefljsf";

            }

            return aspNetUser;
        }
        private void CheckAspNetUserFields(List<AspNetUser> aspNetUserList)
        {
            Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].Id));
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].Email))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].Email));
            }
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].PasswordHash))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].PasswordHash));
            }
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].SecurityStamp))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].SecurityStamp));
            }
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].PhoneNumber))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].PhoneNumber));
            }
            if (aspNetUserList[0].LockoutEndDateUtc != null)
            {
                Assert.NotNull(aspNetUserList[0].LockoutEndDateUtc);
            }
            Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].UserName));
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].NormalizedUserName))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].NormalizedUserName));
            }
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].NormalizedEmail))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].NormalizedEmail));
            }
            if (!string.IsNullOrWhiteSpace(aspNetUserList[0].ConcurrencyStamp))
            {
                Assert.False(string.IsNullOrWhiteSpace(aspNetUserList[0].ConcurrencyStamp));
            }
            if (aspNetUserList[0].LockoutEnd != null)
            {
                Assert.NotNull(aspNetUserList[0].LockoutEnd);
            }
        }
        #endregion Functions private
    }
}