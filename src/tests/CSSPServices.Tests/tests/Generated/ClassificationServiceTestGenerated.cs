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
    public partial class ClassificationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IClassificationService ClassificationService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private Classification classification { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task Classification_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            classification = GetFilledRandomClassification("");

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
            // Post Classification
            var actionClassificationAdded = await ClassificationService.Post(classification);
            Assert.Equal(200, ((ObjectResult)actionClassificationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClassificationAdded.Result).Value);
            Classification classificationAdded = (Classification)((OkObjectResult)actionClassificationAdded.Result).Value;
            Assert.NotNull(classificationAdded);

            // List<Classification>
            var actionClassificationList = await ClassificationService.GetClassificationList();
            Assert.Equal(200, ((ObjectResult)actionClassificationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClassificationList.Result).Value);
            List<Classification> classificationList = (List<Classification>)((OkObjectResult)actionClassificationList.Result).Value;

            int count = ((List<Classification>)((OkObjectResult)actionClassificationList.Result).Value).Count();
            Assert.True(count > 0);

            // Put Classification
            var actionClassificationUpdated = await ClassificationService.Put(classification);
            Assert.Equal(200, ((ObjectResult)actionClassificationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClassificationUpdated.Result).Value);
            Classification classificationUpdated = (Classification)((OkObjectResult)actionClassificationUpdated.Result).Value;
            Assert.NotNull(classificationUpdated);

            // Delete Classification
            var actionClassificationDeleted = await ClassificationService.Delete(classification.ClassificationID);
            Assert.Equal(200, ((ObjectResult)actionClassificationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClassificationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionClassificationDeleted.Result).Value;
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
            Services.AddSingleton<IClassificationService, ClassificationService>();

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

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            ClassificationService = Provider.GetService<IClassificationService>();
            Assert.NotNull(ClassificationService);

            return await Task.FromResult(true);
        }
        private Classification GetFilledRandomClassification(string OmitPropName)
        {
            List<Classification> classificationListToDelete = (from c in dbLocal.Classifications
                                                               select c).ToList(); 
            
            dbLocal.Classifications.RemoveRange(classificationListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            Classification classification = new Classification();

            if (OmitPropName != "ClassificationTVItemID") classification.ClassificationTVItemID = 13;
            if (OmitPropName != "ClassificationType") classification.ClassificationType = (ClassificationTypeEnum)GetRandomEnumType(typeof(ClassificationTypeEnum));
            if (OmitPropName != "Ordinal") classification.Ordinal = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") classification.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") classification.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "ClassificationID") classification.ClassificationID = 10000000;

                try
                {
                dbIM.TVItems.Add(new TVItem() { TVItemID = 13, TVLevel = 6, TVPath = "p1p5p6p9p10p12p13", TVType = (TVTypeEnum)79, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2018, 8, 23, 17, 33, 9), LastUpdateContactTVItemID = 2});
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

            return classification;
        }
        #endregion Functions private
    }
}
