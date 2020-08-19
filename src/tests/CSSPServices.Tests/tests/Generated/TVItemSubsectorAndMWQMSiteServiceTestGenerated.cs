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
    public partial class TVItemSubsectorAndMWQMSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ITVItemSubsectorAndMWQMSiteService TVItemSubsectorAndMWQMSiteService { get; set; }
        private TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemSubsectorAndMWQMSiteService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItemSubsectorAndMWQMSite = GetFilledRandomTVItemSubsectorAndMWQMSite("");

            List<ValidationResult> ValidationResultsList = TVItemSubsectorAndMWQMSiteService.Validate(new ValidationContext(tvItemSubsectorAndMWQMSite)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemSubsectorAndMWQMSiteService, TVItemSubsectorAndMWQMSiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            TVItemSubsectorAndMWQMSiteService = Provider.GetService<ITVItemSubsectorAndMWQMSiteService>();
            Assert.NotNull(TVItemSubsectorAndMWQMSiteService);

            return await Task.FromResult(true);
        }
        private TVItemSubsectorAndMWQMSite GetFilledRandomTVItemSubsectorAndMWQMSite(string OmitPropName)
        {
            TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = new TVItemSubsectorAndMWQMSite();

            //CSSPError: property [TVItemSubsector] and type [TVItemSubsectorAndMWQMSite] is  not implemented
            //CSSPError: property [TVItemMWQMSiteList] and type [TVItemSubsectorAndMWQMSite] is  not implemented
            //CSSPError: property [TVItemMWQMSiteDuplicate] and type [TVItemSubsectorAndMWQMSite] is  not implemented

            return tvItemSubsectorAndMWQMSite;
        }
        private void CheckTVItemSubsectorAndMWQMSiteFields(List<TVItemSubsectorAndMWQMSite> tvItemSubsectorAndMWQMSiteList)
        {
        }
        #endregion Functions private
    }
}
