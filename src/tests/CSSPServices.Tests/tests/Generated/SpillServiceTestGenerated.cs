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
    public partial class SpillServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ISpillService spillService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public SpillServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Spill_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            Spill spill = GetFilledRandomSpill(""); 

            // List<Spill>
            var actionSpillList = await spillService.GetSpillList();
            Assert.Equal(200, ((ObjectResult)actionSpillList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillList.Result).Value);
            List<Spill> spillList = (List<Spill>)(((OkObjectResult)actionSpillList.Result).Value);

            int count = ((List<Spill>)((OkObjectResult)actionSpillList.Result).Value).Count();
            Assert.True(count > 0);

            // Add Spill
            var actionSpillAdded = await spillService.Add(spill);
            Assert.Equal(200, ((ObjectResult)actionSpillAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillAdded.Result).Value);
            Spill spillAdded = (Spill)(((OkObjectResult)actionSpillAdded.Result).Value);
            Assert.NotNull(spillAdded);

            // Update Spill
            var actionSpillUpdated = await spillService.Update(spill);
            Assert.Equal(200, ((ObjectResult)actionSpillUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillUpdated.Result).Value);
            Spill spillUpdated = (Spill)(((OkObjectResult)actionSpillUpdated.Result).Value);
            Assert.NotNull(spillUpdated);

            // Delete Spill
            var actionSpillDeleted = await spillService.Delete(spill);
            Assert.Equal(200, ((ObjectResult)actionSpillDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillDeleted.Result).Value);
            Spill spillDeleted = (Spill)(((OkObjectResult)actionSpillDeleted.Result).Value);
            Assert.NotNull(spillDeleted);
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
            Services.AddSingleton<ISpillService, SpillService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            spillService = Provider.GetService<ISpillService>();
            Assert.NotNull(spillService);
        
            await spillService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            Spill spill = new Spill();

            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = 39;
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = 41;
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = 2;

            return spill;
        }
        #endregion Functions private
    }
}