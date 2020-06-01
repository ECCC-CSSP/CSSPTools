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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class PolSourceObservationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IPolSourceObservationService polSourceObservationService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservation_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation(""); 

            // List<PolSourceObservation>
            var actionPolSourceObservationList = await polSourceObservationService.GetPolSourceObservationList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationList.Result).Value);
            List<PolSourceObservation> polSourceObservationList = (List<PolSourceObservation>)(((OkObjectResult)actionPolSourceObservationList.Result).Value);

            int count = ((List<PolSourceObservation>)((OkObjectResult)actionPolSourceObservationList.Result).Value).Count();
            Assert.True(count > 0);

            // Add PolSourceObservation
            var actionPolSourceObservationAdded = await polSourceObservationService.Add(polSourceObservation);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationAdded.Result).Value);
            PolSourceObservation polSourceObservationAdded = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationAdded.Result).Value);
            Assert.NotNull(polSourceObservationAdded);

            // Update PolSourceObservation
            var actionPolSourceObservationUpdated = await polSourceObservationService.Update(polSourceObservation);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationUpdated.Result).Value);
            PolSourceObservation polSourceObservationUpdated = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationUpdated.Result).Value);
            Assert.NotNull(polSourceObservationUpdated);

            // Delete PolSourceObservation
            var actionPolSourceObservationDeleted = await polSourceObservationService.Delete(polSourceObservation);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationDeleted.Result).Value);
            PolSourceObservation polSourceObservationDeleted = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationDeleted.Result).Value);
            Assert.NotNull(polSourceObservationDeleted);
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
            Services.AddSingleton<IPolSourceObservationService, PolSourceObservationService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            polSourceObservationService = Provider.GetService<IPolSourceObservationService>();
            Assert.NotNull(polSourceObservationService);
        
            await polSourceObservationService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private PolSourceObservation GetFilledRandomPolSourceObservation(string OmitPropName)
        {
            PolSourceObservation polSourceObservation = new PolSourceObservation();

            if (OmitPropName != "PolSourceSiteID") polSourceObservation.PolSourceSiteID = 1;
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "DesktopReviewed") polSourceObservation.DesktopReviewed = true;
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservation.LastUpdateContactTVItemID = 2;

            return polSourceObservation;
        }
        #endregion Functions private
    }
}
