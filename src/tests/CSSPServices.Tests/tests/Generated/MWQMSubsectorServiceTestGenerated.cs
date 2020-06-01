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
    public partial class MWQMSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IMWQMSubsectorService mwqmSubsectorService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsector_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector(""); 

            // List<MWQMSubsector>
            var actionMWQMSubsectorList = await mwqmSubsectorService.GetMWQMSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
            List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)(((OkObjectResult)actionMWQMSubsectorList.Result).Value);

            int count = ((List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value).Count();
            Assert.True(count > 0);

            // Add MWQMSubsector
            var actionMWQMSubsectorAdded = await mwqmSubsectorService.Add(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorAdded.Result).Value);
            MWQMSubsector mwqmSubsectorAdded = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorAdded.Result).Value);
            Assert.NotNull(mwqmSubsectorAdded);

            // Update MWQMSubsector
            var actionMWQMSubsectorUpdated = await mwqmSubsectorService.Update(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value);
            MWQMSubsector mwqmSubsectorUpdated = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value);
            Assert.NotNull(mwqmSubsectorUpdated);

            // Delete MWQMSubsector
            var actionMWQMSubsectorDeleted = await mwqmSubsectorService.Delete(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value);
            MWQMSubsector mwqmSubsectorDeleted = (MWQMSubsector)(((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value);
            Assert.NotNull(mwqmSubsectorDeleted);
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
            Services.AddSingleton<IMWQMSubsectorService, MWQMSubsectorService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            mwqmSubsectorService = Provider.GetService<IMWQMSubsectorService>();
            Assert.NotNull(mwqmSubsectorService);
        
            await mwqmSubsectorService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;

            return mwqmSubsector;
        }
        #endregion Functions private
    }
}