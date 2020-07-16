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
    public partial class MWQMAnalysisReportParameterServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMAnalysisReportParameterService MWQMAnalysisReportParameterService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMAnalysisReportParameter mwqmAnalysisReportParameter { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MWQMAnalysisReportParameter_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");

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
            // Post MWQMAnalysisReportParameter
            var actionMWQMAnalysisReportParameterAdded = await MWQMAnalysisReportParameterService.Post(mwqmAnalysisReportParameter);
            Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterAdded.Result).Value);
            MWQMAnalysisReportParameter mwqmAnalysisReportParameterAdded = (MWQMAnalysisReportParameter)((OkObjectResult)actionMWQMAnalysisReportParameterAdded.Result).Value;
            Assert.NotNull(mwqmAnalysisReportParameterAdded);

            // List<MWQMAnalysisReportParameter>
            var actionMWQMAnalysisReportParameterList = await MWQMAnalysisReportParameterService.GetMWQMAnalysisReportParameterList();
            Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value);
            List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = (List<MWQMAnalysisReportParameter>)((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value;

            int count = ((List<MWQMAnalysisReportParameter>)((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMAnalysisReportParameter
            var actionMWQMAnalysisReportParameterUpdated = await MWQMAnalysisReportParameterService.Put(mwqmAnalysisReportParameter);
            Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterUpdated.Result).Value);
            MWQMAnalysisReportParameter mwqmAnalysisReportParameterUpdated = (MWQMAnalysisReportParameter)((OkObjectResult)actionMWQMAnalysisReportParameterUpdated.Result).Value;
            Assert.NotNull(mwqmAnalysisReportParameterUpdated);

            // Delete MWQMAnalysisReportParameter
            var actionMWQMAnalysisReportParameterDeleted = await MWQMAnalysisReportParameterService.Delete(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
            Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMAnalysisReportParameterDeleted.Result).Value;
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMWQMAnalysisReportParameterService, MWQMAnalysisReportParameterService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            MWQMAnalysisReportParameterService = Provider.GetService<IMWQMAnalysisReportParameterService>();
            Assert.NotNull(MWQMAnalysisReportParameterService);

            return await Task.FromResult(true);
        }
        private MWQMAnalysisReportParameter GetFilledRandomMWQMAnalysisReportParameter(string OmitPropName)
        {
            List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterListToDelete = (from c in dbLocal.MWQMAnalysisReportParameters
                                                               select c).ToList(); 
            
            dbLocal.MWQMAnalysisReportParameters.RemoveRange(mwqmAnalysisReportParameterListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();

            if (OmitPropName != "SubsectorTVItemID") mwqmAnalysisReportParameter.SubsectorTVItemID = 11;
            if (OmitPropName != "AnalysisName") mwqmAnalysisReportParameter.AnalysisName = GetRandomString("", 10);
            if (OmitPropName != "AnalysisReportYear") mwqmAnalysisReportParameter.AnalysisReportYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "StartDate") mwqmAnalysisReportParameter.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmAnalysisReportParameter.EndDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "AnalysisCalculationType") mwqmAnalysisReportParameter.AnalysisCalculationType = (AnalysisCalculationTypeEnum)GetRandomEnumType(typeof(AnalysisCalculationTypeEnum));
            if (OmitPropName != "NumberOfRuns") mwqmAnalysisReportParameter.NumberOfRuns = GetRandomInt(1, 1000);
            if (OmitPropName != "FullYear") mwqmAnalysisReportParameter.FullYear = true;
            if (OmitPropName != "SalinityHighlightDeviationFromAverage") mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = GetRandomDouble(1.0D, 20.0D);
            if (OmitPropName != "ShortRangeNumberOfDays") mwqmAnalysisReportParameter.ShortRangeNumberOfDays = GetRandomInt(0, 5);
            if (OmitPropName != "MidRangeNumberOfDays") mwqmAnalysisReportParameter.MidRangeNumberOfDays = GetRandomInt(2, 7);
            if (OmitPropName != "DryLimit24h") mwqmAnalysisReportParameter.DryLimit24h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit48h") mwqmAnalysisReportParameter.DryLimit48h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit72h") mwqmAnalysisReportParameter.DryLimit72h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit96h") mwqmAnalysisReportParameter.DryLimit96h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit24h") mwqmAnalysisReportParameter.WetLimit24h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit48h") mwqmAnalysisReportParameter.WetLimit48h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit72h") mwqmAnalysisReportParameter.WetLimit72h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit96h") mwqmAnalysisReportParameter.WetLimit96h = GetRandomInt(1, 100);
            if (OmitPropName != "RunsToOmit") mwqmAnalysisReportParameter.RunsToOmit = GetRandomString("", 5);
            if (OmitPropName != "ShowDataTypes") mwqmAnalysisReportParameter.ShowDataTypes = GetRandomString("", 5);
            if (OmitPropName != "ExcelTVFileTVItemID") mwqmAnalysisReportParameter.ExcelTVFileTVItemID = 42;
            if (OmitPropName != "Command") mwqmAnalysisReportParameter.Command = (AnalysisReportExportCommandEnum)GetRandomEnumType(typeof(AnalysisReportExportCommandEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmAnalysisReportParameter.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmAnalysisReportParameter.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MWQMAnalysisReportParameterID") mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 42, TVLevel = 5, TVPath = "p1p5p6p39p41p42", TVType = (TVTypeEnum)8, ParentID = 41, IsActive = true, LastUpdateDate_UTC = new DateTime(2016, 5, 5, 17, 18, 26), LastUpdateContactTVItemID = 2});
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

            return mwqmAnalysisReportParameter;
        }
        #endregion Functions private
    }
}
