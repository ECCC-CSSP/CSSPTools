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
    public partial class UseOfSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IUseOfSiteService useOfSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task UseOfSite_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               UseOfSite useOfSite = GetFilledRandomUseOfSite(""); 

               // List<UseOfSite>
               var actionUseOfSiteList = await useOfSiteService.GetUseOfSiteList();
               Assert.Equal(200, ((ObjectResult)actionUseOfSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionUseOfSiteList.Result).Value);
               List<UseOfSite> useOfSiteList = (List<UseOfSite>)(((OkObjectResult)actionUseOfSiteList.Result).Value);

               int count = ((List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // Add UseOfSite
               var actionUseOfSiteAdded = await useOfSiteService.Add(useOfSite);
               Assert.Equal(200, ((ObjectResult)actionUseOfSiteAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionUseOfSiteAdded.Result).Value);
               UseOfSite useOfSiteAdded = (UseOfSite)(((OkObjectResult)actionUseOfSiteAdded.Result).Value);
               Assert.NotNull(useOfSiteAdded);

               // Update UseOfSite
               var actionUseOfSiteUpdated = await useOfSiteService.Update(useOfSite);
               Assert.Equal(200, ((ObjectResult)actionUseOfSiteUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionUseOfSiteUpdated.Result).Value);
               UseOfSite useOfSiteUpdated = (UseOfSite)(((OkObjectResult)actionUseOfSiteUpdated.Result).Value);
               Assert.NotNull(useOfSiteUpdated);

               // Delete UseOfSite
               var actionUseOfSiteDeleted = await useOfSiteService.Delete(useOfSite);
               Assert.Equal(200, ((ObjectResult)actionUseOfSiteDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionUseOfSiteDeleted.Result).Value);
               UseOfSite useOfSiteDeleted = (UseOfSite)(((OkObjectResult)actionUseOfSiteDeleted.Result).Value);
               Assert.NotNull(useOfSiteDeleted);
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
            Services.AddSingleton<IUseOfSiteService, UseOfSiteService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            useOfSiteService = Provider.GetService<IUseOfSiteService>();
            Assert.NotNull(useOfSiteService);
        
            await useOfSiteService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = 7;
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = 11;
            if (OmitPropName != "TVType") useOfSite.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = 2;

            return useOfSite;
        }
        #endregion Functions private
    }
}
