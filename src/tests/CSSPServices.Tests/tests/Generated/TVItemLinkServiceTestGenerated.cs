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
    public partial class TVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemLinkService TVItemLinkService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private TVItemLink tvItemLink { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task TVItemLink_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tvItemLink = GetFilledRandomTVItemLink("");

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
        public async Task TVItemLink_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTVItemLinkList = await TVItemLinkService.GetTVItemLinkList();
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkList.Result).Value);
            List<TVItemLink> tvItemLinkList = (List<TVItemLink>)((OkObjectResult)actionTVItemLinkList.Result).Value;

            count = tvItemLinkList.Count();

            TVItemLink tvItemLink = GetFilledRandomTVItemLink("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemLink.TVItemLinkID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVItemLinkID = 0;

            var actionTVItemLink = await TVItemLinkService.Put(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVItemLinkID = 10000000;
            actionTVItemLink = await TVItemLinkService.Put(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemLink.FromTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.FromTVItemID = 0;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.FromTVItemID = 13;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemLink.ToTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ToTVItemID = 0;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ToTVItemID = 13;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLink.FromTVType   (TVTypeEnum)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.FromTVType = (TVTypeEnum)1000000;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLink.ToTVType   (TVTypeEnum)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ToTVType = (TVTypeEnum)1000000;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLink.StartDateTime_Local   (DateTime)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.StartDateTime_Local = new DateTime(1979, 1, 1);
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_Local)]
            // tvItemLink.EndDateTime_Local   (DateTime)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.EndDateTime_Local = new DateTime(1979, 1, 1);
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // tvItemLink.Ordinal   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.Ordinal = -1;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            //Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.Ordinal = 101;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            //Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // tvItemLink.TVLevel   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVLevel = -1;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            //Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVLevel = 101;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            //Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // tvItemLink.TVPath   (String)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("TVPath");
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVPath = GetRandomString("", 251);
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            //Assert.AreEqual(count, tvItemLinkService.GetTVItemLinkList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID", AllowableTVtypeList = )]
            // tvItemLink.ParentTVItemLinkID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ParentTVItemLinkID = 0;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLink.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateDate_UTC = new DateTime();
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemLink.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateContactTVItemID = 0;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateContactTVItemID = 1;
            actionTVItemLink = await TVItemLinkService.Post(tvItemLink);
            Assert.IsType<BadRequestObjectResult>(actionTVItemLink.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post TVItemLink
            var actionTVItemLinkAdded = await TVItemLinkService.Post(tvItemLink);
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkAdded.Result).Value);
            TVItemLink tvItemLinkAdded = (TVItemLink)((OkObjectResult)actionTVItemLinkAdded.Result).Value;
            Assert.NotNull(tvItemLinkAdded);

            // List<TVItemLink>
            var actionTVItemLinkList = await TVItemLinkService.GetTVItemLinkList();
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkList.Result).Value);
            List<TVItemLink> tvItemLinkList = (List<TVItemLink>)((OkObjectResult)actionTVItemLinkList.Result).Value;

            int count = ((List<TVItemLink>)((OkObjectResult)actionTVItemLinkList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<TVItemLink> with skip and take
                var actionTVItemLinkListSkipAndTake = await TVItemLinkService.GetTVItemLinkList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionTVItemLinkListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVItemLinkListSkipAndTake.Result).Value);
                List<TVItemLink> tvItemLinkListSkipAndTake = (List<TVItemLink>)((OkObjectResult)actionTVItemLinkListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<TVItemLink>)((OkObjectResult)actionTVItemLinkListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(tvItemLinkList[0].TVItemLinkID == tvItemLinkListSkipAndTake[0].TVItemLinkID);
            }

            // Get TVItemLink With TVItemLinkID
            var actionTVItemLinkGet = await TVItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLinkList[0].TVItemLinkID);
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkGet.Result).Value);
            TVItemLink tvItemLinkGet = (TVItemLink)((OkObjectResult)actionTVItemLinkGet.Result).Value;
            Assert.NotNull(tvItemLinkGet);
            Assert.Equal(tvItemLinkGet.TVItemLinkID, tvItemLinkList[0].TVItemLinkID);

            // Put TVItemLink
            var actionTVItemLinkUpdated = await TVItemLinkService.Put(tvItemLink);
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkUpdated.Result).Value);
            TVItemLink tvItemLinkUpdated = (TVItemLink)((OkObjectResult)actionTVItemLinkUpdated.Result).Value;
            Assert.NotNull(tvItemLinkUpdated);

            // Delete TVItemLink
            var actionTVItemLinkDeleted = await TVItemLinkService.Delete(tvItemLink.TVItemLinkID);
            Assert.Equal(200, ((ObjectResult)actionTVItemLinkDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemLinkDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemLinkDeleted.Result).Value;
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemLinkService, TVItemLinkService>();

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

            TVItemLinkService = Provider.GetService<ITVItemLinkService>();
            Assert.NotNull(TVItemLinkService);

            return await Task.FromResult(true);
        }
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            List<TVItemLink> tvItemLinkListToDelete = (from c in dbLocal.TVItemLinks
                                                               select c).ToList(); 
            
            dbLocal.TVItemLinks.RemoveRange(tvItemLinkListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = 1;
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = 1;
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            // Need to implement [TVItemLink ParentTVItemLinkID TVItemLink TVItemLinkID]
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "TVItemLinkID") tvItemLink.TVItemLinkID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
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

            return tvItemLink;
        }
        private void CheckTVItemLinkFields(List<TVItemLink> tvItemLinkList)
        {
            if (tvItemLinkList[0].StartDateTime_Local != null)
            {
                Assert.NotNull(tvItemLinkList[0].StartDateTime_Local);
            }
            if (tvItemLinkList[0].EndDateTime_Local != null)
            {
                Assert.NotNull(tvItemLinkList[0].EndDateTime_Local);
            }
            Assert.False(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVPath));
            if (tvItemLinkList[0].ParentTVItemLinkID != null)
            {
                Assert.NotNull(tvItemLinkList[0].ParentTVItemLinkID);
            }
        }
        #endregion Functions private
    }
}
