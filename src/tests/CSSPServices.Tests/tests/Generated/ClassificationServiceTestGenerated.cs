/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
    public partial class ClassificationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IClassificationService classificationService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Classification_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               Classification classification = GetFilledRandomClassification(""); 

               // List<Classification>
               var actionClassificationList = await classificationService.GetClassificationList();
               Assert.Equal(200, ((ObjectResult)actionClassificationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClassificationList.Result).Value);
               List<Classification> classificationList = (List<Classification>)(((OkObjectResult)actionClassificationList.Result).Value);

               int count = ((List<Classification>)((OkObjectResult)actionClassificationList.Result).Value).Count();
                Assert.True(count > 0);

               // Add Classification
               var actionClassificationAdded = await classificationService.Add(classification);
               Assert.Equal(200, ((ObjectResult)actionClassificationAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClassificationAdded.Result).Value);
               Classification classificationAdded = (Classification)(((OkObjectResult)actionClassificationAdded.Result).Value);
               Assert.NotNull(classificationAdded);

               // Update Classification
               var actionClassificationUpdated = await classificationService.Update(classification);
               Assert.Equal(200, ((ObjectResult)actionClassificationUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClassificationUpdated.Result).Value);
               Classification classificationUpdated = (Classification)(((OkObjectResult)actionClassificationUpdated.Result).Value);
               Assert.NotNull(classificationUpdated);

               // Delete Classification
               var actionClassificationDeleted = await classificationService.Delete(classification);
               Assert.Equal(200, ((ObjectResult)actionClassificationDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionClassificationDeleted.Result).Value);
               Classification classificationDeleted = (Classification)(((OkObjectResult)actionClassificationDeleted.Result).Value);
               Assert.NotNull(classificationDeleted);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IClassificationService, ClassificationService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            classificationService = Provider.GetService<IClassificationService>();
            Assert.NotNull(classificationService);
        
            await classificationService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private Classification GetFilledRandomClassification(string OmitPropName)
        {
            Classification classification = new Classification();

            if (OmitPropName != "ClassificationTVItemID") classification.ClassificationTVItemID = 13;
            if (OmitPropName != "ClassificationType") classification.ClassificationType = (ClassificationTypeEnum)GetRandomEnumType(typeof(ClassificationTypeEnum));
            if (OmitPropName != "Ordinal") classification.Ordinal = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") classification.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") classification.LastUpdateContactTVItemID = 2;

            return classification;
        }
        #endregion Functions private
    }
}
