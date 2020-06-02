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
    public partial class MWQMLookupMPNServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IMWQMLookupMPNService mwqmLookupMPNService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMLookupMPN_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN(""); 

               // List<MWQMLookupMPN>
               var actionMWQMLookupMPNList = await mwqmLookupMPNService.GetMWQMLookupMPNList();
               Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
               List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);

               int count = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value).Count();
                Assert.True(count > 0);

               // Add MWQMLookupMPN
               var actionMWQMLookupMPNAdded = await mwqmLookupMPNService.Add(mwqmLookupMPN);
               Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value);
               MWQMLookupMPN mwqmLookupMPNAdded = (MWQMLookupMPN)(((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value);
               Assert.NotNull(mwqmLookupMPNAdded);

               // Update MWQMLookupMPN
               var actionMWQMLookupMPNUpdated = await mwqmLookupMPNService.Update(mwqmLookupMPN);
               Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value);
               MWQMLookupMPN mwqmLookupMPNUpdated = (MWQMLookupMPN)(((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value);
               Assert.NotNull(mwqmLookupMPNUpdated);

               // Delete MWQMLookupMPN
               var actionMWQMLookupMPNDeleted = await mwqmLookupMPNService.Delete(mwqmLookupMPN);
               Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value);
               MWQMLookupMPN mwqmLookupMPNDeleted = (MWQMLookupMPN)(((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value);
               Assert.NotNull(mwqmLookupMPNDeleted);
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
            Services.AddSingleton<IMWQMLookupMPNService, MWQMLookupMPNService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            mwqmLookupMPNService = Provider.GetService<IMWQMLookupMPNService>();
            Assert.NotNull(mwqmLookupMPNService);
        
            await mwqmLookupMPNService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(2, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            return mwqmLookupMPN;
        }
        #endregion Functions private
    }
}
