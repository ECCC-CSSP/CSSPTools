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
    public partial class TelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITelService TelService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private Tel tel { get; set; }
        #endregion Properties

        #region Constructors
        public TelServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Tel_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tel = GetFilledRandomTel("");

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
        public async Task Tel_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTelList = await TelService.GetTelList();
            Assert.Equal(200, ((ObjectResult)actionTelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelList.Result).Value);
            List<Tel> telList = (List<Tel>)((OkObjectResult)actionTelList.Result).Value;

            count = telList.Count();

            Tel tel = GetFilledRandomTel("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tel.TelID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelID = 0;

            var actionTel = await TelService.Put(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelID = 10000000;
            actionTel = await TelService.Put(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Tel)]
            // tel.TelTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 0;
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 1;
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // tel.TelNumber   (String)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("TelNumber");
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelNumber = GetRandomString("", 51);
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);
            //Assert.AreEqual(count, telService.GetTelList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tel.TelType   (TelTypeEnum)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelType = (TelTypeEnum)1000000;
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateDate_UTC = new DateTime();
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);
            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 0;
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 1;
            actionTel = await TelService.Post(tel);
            Assert.IsType<BadRequestObjectResult>(actionTel.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post Tel
            var actionTelAdded = await TelService.Post(tel);
            Assert.Equal(200, ((ObjectResult)actionTelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelAdded.Result).Value);
            Tel telAdded = (Tel)((OkObjectResult)actionTelAdded.Result).Value;
            Assert.NotNull(telAdded);

            // List<Tel>
            var actionTelList = await TelService.GetTelList();
            Assert.Equal(200, ((ObjectResult)actionTelList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelList.Result).Value);
            List<Tel> telList = (List<Tel>)((OkObjectResult)actionTelList.Result).Value;

            int count = ((List<Tel>)((OkObjectResult)actionTelList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<Tel> with skip and take
                var actionTelListSkipAndTake = await TelService.GetTelList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionTelListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTelListSkipAndTake.Result).Value);
                List<Tel> telListSkipAndTake = (List<Tel>)((OkObjectResult)actionTelListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<Tel>)((OkObjectResult)actionTelListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(telList[0].TelID == telListSkipAndTake[0].TelID);
            }

            // Get Tel With TelID
            var actionTelGet = await TelService.GetTelWithTelID(telList[0].TelID);
            Assert.Equal(200, ((ObjectResult)actionTelGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelGet.Result).Value);
            Tel telGet = (Tel)((OkObjectResult)actionTelGet.Result).Value;
            Assert.NotNull(telGet);
            Assert.Equal(telGet.TelID, telList[0].TelID);

            // Put Tel
            var actionTelUpdated = await TelService.Put(tel);
            Assert.Equal(200, ((ObjectResult)actionTelUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelUpdated.Result).Value);
            Tel telUpdated = (Tel)((OkObjectResult)actionTelUpdated.Result).Value;
            Assert.NotNull(telUpdated);

            // Delete Tel
            var actionTelDeleted = await TelService.Delete(tel.TelID);
            Assert.Equal(200, ((ObjectResult)actionTelDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTelDeleted.Result).Value;
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITelService, TelService>();

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

            TelService = Provider.GetService<ITelService>();
            Assert.NotNull(TelService);

            return await Task.FromResult(true);
        }
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            List<Tel> telListToDelete = (from c in dbLocal.Tels
                                                               select c).ToList(); 
            
            dbLocal.Tels.RemoveRange(telListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            Tel tel = new Tel();

            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 55;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "TelID") tel.TelID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 55, TVLevel = 1, TVPath = "p1p55", TVType = (TVTypeEnum)21, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 10, 12, 59, 36), LastUpdateContactTVItemID = 2});
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

            return tel;
        }
        private void CheckTelFields(List<Tel> telList)
        {
            Assert.False(string.IsNullOrWhiteSpace(telList[0].TelNumber));
        }
        #endregion Functions private
    }
}
