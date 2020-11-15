/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalResetPasswordDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalResetPasswordDBService LocalResetPasswordDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalResetPassword localResetPassword { get; set; }
        #endregion Properties

        #region Constructors
        public LocalResetPasswordDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalResetPasswordDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalResetPasswordDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localResetPassword = GetFilledRandomLocalResetPassword("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalResetPassword_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalResetPasswordList = await LocalResetPasswordDBService.GetLocalResetPasswordList();
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordList.Result).Value);
            List<LocalResetPassword> localResetPasswordList = (List<LocalResetPassword>)((OkObjectResult)actionLocalResetPasswordList.Result).Value;

            count = localResetPasswordList.Count();

            LocalResetPassword localResetPassword = GetFilledRandomLocalResetPassword("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localResetPassword.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localResetPassword.ResetPasswordID   (Int32)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.ResetPasswordID = 0;

            actionLocalResetPassword = await LocalResetPasswordDBService.Put(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.ResetPasswordID = 10000000;
            actionLocalResetPassword = await LocalResetPasswordDBService.Put(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [CSSPMaxLength(256)]
            // localResetPassword.Email   (String)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("Email");
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.Email = GetRandomString("", 257);
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);
            //Assert.AreEqual(count, localResetPasswordDBService.GetLocalResetPasswordList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localResetPassword.ExpireDate_Local   (DateTime)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.ExpireDate_Local = new DateTime();
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);
            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.ExpireDate_Local = new DateTime(1979, 1, 1);
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(8)]
            // localResetPassword.Code   (String)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("Code");
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.Code = GetRandomString("", 9);
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);
            //Assert.AreEqual(count, localResetPasswordDBService.GetLocalResetPasswordList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localResetPassword.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.LastUpdateDate_UTC = new DateTime();
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);
            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localResetPassword.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.LastUpdateContactTVItemID = 0;
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

            localResetPassword = null;
            localResetPassword = GetFilledRandomLocalResetPassword("");
            localResetPassword.LastUpdateContactTVItemID = 1;
            actionLocalResetPassword = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.IsType<BadRequestObjectResult>(actionLocalResetPassword.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalResetPassword
            var actionLocalResetPasswordAdded = await LocalResetPasswordDBService.Post(localResetPassword);
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordAdded.Result).Value);
            LocalResetPassword localResetPasswordAdded = (LocalResetPassword)((OkObjectResult)actionLocalResetPasswordAdded.Result).Value;
            Assert.NotNull(localResetPasswordAdded);

            // List<LocalResetPassword>
            var actionLocalResetPasswordList = await LocalResetPasswordDBService.GetLocalResetPasswordList();
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordList.Result).Value);
            List<LocalResetPassword> localResetPasswordList = (List<LocalResetPassword>)((OkObjectResult)actionLocalResetPasswordList.Result).Value;

            int count = ((List<LocalResetPassword>)((OkObjectResult)actionLocalResetPasswordList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalResetPassword> with skip and take
            var actionLocalResetPasswordListSkipAndTake = await LocalResetPasswordDBService.GetLocalResetPasswordList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordListSkipAndTake.Result).Value);
            List<LocalResetPassword> localResetPasswordListSkipAndTake = (List<LocalResetPassword>)((OkObjectResult)actionLocalResetPasswordListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalResetPassword>)((OkObjectResult)actionLocalResetPasswordListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localResetPasswordList[0].ResetPasswordID == localResetPasswordListSkipAndTake[0].ResetPasswordID);

            // Get LocalResetPassword With ResetPasswordID
            var actionLocalResetPasswordGet = await LocalResetPasswordDBService.GetLocalResetPasswordWithResetPasswordID(localResetPasswordList[0].ResetPasswordID);
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordGet.Result).Value);
            LocalResetPassword localResetPasswordGet = (LocalResetPassword)((OkObjectResult)actionLocalResetPasswordGet.Result).Value;
            Assert.NotNull(localResetPasswordGet);
            Assert.Equal(localResetPasswordGet.ResetPasswordID, localResetPasswordList[0].ResetPasswordID);

            // Put LocalResetPassword
            var actionLocalResetPasswordUpdated = await LocalResetPasswordDBService.Put(localResetPassword);
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordUpdated.Result).Value);
            LocalResetPassword localResetPasswordUpdated = (LocalResetPassword)((OkObjectResult)actionLocalResetPasswordUpdated.Result).Value;
            Assert.NotNull(localResetPasswordUpdated);

            // Delete LocalResetPassword
            var actionLocalResetPasswordDeleted = await LocalResetPasswordDBService.Delete(localResetPassword.ResetPasswordID);
            Assert.Equal(200, ((ObjectResult)actionLocalResetPasswordDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalResetPasswordDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalResetPasswordDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalResetPasswordDBService, LocalResetPasswordDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalResetPasswordDBService = Provider.GetService<ILocalResetPasswordDBService>();
            Assert.NotNull(LocalResetPasswordDBService);

            return await Task.FromResult(true);
        }
        private LocalResetPassword GetFilledRandomLocalResetPassword(string OmitPropName)
        {
            LocalResetPassword localResetPassword = new LocalResetPassword();

            if (OmitPropName != "LocalDBCommand") localResetPassword.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "Email") localResetPassword.Email = GetRandomEmail();
            if (OmitPropName != "ExpireDate_Local") localResetPassword.ExpireDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Code") localResetPassword.Code = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") localResetPassword.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localResetPassword.LastUpdateContactTVItemID = 2;



            return localResetPassword;
        }
        private void CheckLocalResetPasswordFields(List<LocalResetPassword> localResetPasswordList)
        {
            Assert.False(string.IsNullOrWhiteSpace(localResetPasswordList[0].Email));
            Assert.False(string.IsNullOrWhiteSpace(localResetPasswordList[0].Code));
        }

        #endregion Functions private
    }
}