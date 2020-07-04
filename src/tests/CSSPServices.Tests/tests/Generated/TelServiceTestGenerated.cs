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
    public partial class TelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITelService TelService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private Tel tel { get; set; }
        #endregion Properties

        #region Constructors
        public TelServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task Tel_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            tel = GetFilledRandomTel("");

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
            Services.AddSingleton<ITelService, TelService>();

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

            TelService = Provider.GetService<ITelService>();
            Assert.NotNull(TelService);

            return await Task.FromResult(true);
        }
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            dbIM.Database.EnsureDeleted();

            Tel tel = new Tel();

            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 55;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "TelID") tel.TelID = 10000000;

                dbIM.TVItems.Add(new TVItem() { TVItemID = 55, TVLevel = 1, TVPath = "p1p55", TVType = (TVTypeEnum)21, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 10, 12, 59, 36), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
                dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                dbIM.SaveChanges();
            }

            return tel;
        }
        #endregion Functions private
    }
}
