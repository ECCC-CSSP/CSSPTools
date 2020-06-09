/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class SamplingPlanEmailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ISamplingPlanEmailService samplingPlanEmailService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SamplingPlanEmail_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               SamplingPlanEmail samplingPlanEmail = GetFilledRandomSamplingPlanEmail(""); 

               // List<SamplingPlanEmail>
               var actionSamplingPlanEmailList = await samplingPlanEmailService.GetSamplingPlanEmailList();
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);
               List<SamplingPlanEmail> samplingPlanEmailList = (List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value;

               int count = ((List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value).Count();
                Assert.True(count > 0);

               // Add SamplingPlanEmail
               var actionSamplingPlanEmailAdded = await samplingPlanEmailService.Add(samplingPlanEmail);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value);
               SamplingPlanEmail samplingPlanEmailAdded = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value;
               Assert.NotNull(samplingPlanEmailAdded);

               // Update SamplingPlanEmail
               var actionSamplingPlanEmailUpdated = await samplingPlanEmailService.Update(samplingPlanEmail);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value);
               SamplingPlanEmail samplingPlanEmailUpdated = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value;
               Assert.NotNull(samplingPlanEmailUpdated);

               // Delete SamplingPlanEmail
               var actionSamplingPlanEmailDeleted = await samplingPlanEmailService.Delete(samplingPlanEmail.SamplingPlanEmailID);
               Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISamplingPlanEmailService, SamplingPlanEmailService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            samplingPlanEmailService = Provider.GetService<ISamplingPlanEmailService>();
            Assert.NotNull(samplingPlanEmailService);

            return await Task.FromResult(true);
        }
        private SamplingPlanEmail GetFilledRandomSamplingPlanEmail(string OmitPropName)
        {
            SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();

            if (OmitPropName != "SamplingPlanID") samplingPlanEmail.SamplingPlanID = 1;
            if (OmitPropName != "Email") samplingPlanEmail.Email = GetRandomEmail();
            if (OmitPropName != "IsContractor") samplingPlanEmail.IsContractor = true;
            if (OmitPropName != "LabSheetHasValueOver500") samplingPlanEmail.LabSheetHasValueOver500 = true;
            if (OmitPropName != "LabSheetReceived") samplingPlanEmail.LabSheetReceived = true;
            if (OmitPropName != "LabSheetAccepted") samplingPlanEmail.LabSheetAccepted = true;
            if (OmitPropName != "LabSheetRejected") samplingPlanEmail.LabSheetRejected = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanEmail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanEmail.LastUpdateContactTVItemID = 2;

            return samplingPlanEmail;
        }
        #endregion Functions private
    }
}
