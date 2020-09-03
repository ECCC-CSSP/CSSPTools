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
    public partial class TVLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ITVLocationService TVLocationService { get; set; }
        private TVLocation tvLocation { get; set; }
        #endregion Properties

        #region Constructors
        public TVLocationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVLocationService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvLocation = GetFilledRandomTVLocation("");

            List<ValidationResult> ValidationResultsList = TVLocationService.Validate(new ValidationContext(tvLocation)).ToList();
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
            Services.AddSingleton<ITVLocationService, TVLocationService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            TVLocationService = Provider.GetService<ITVLocationService>();
            Assert.NotNull(TVLocationService);

            return await Task.FromResult(true);
        }
        private TVLocation GetFilledRandomTVLocation(string OmitPropName)
        {
            TVLocation tvLocation = new TVLocation();

            if (OmitPropName != "TVItemID") tvLocation.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvLocation.TVText = GetRandomString("", 6);
            if (OmitPropName != "TVType") tvLocation.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "SubTVType") tvLocation.SubTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVTypeText") tvLocation.TVTypeText = GetRandomString("", 5);
            if (OmitPropName != "SubTVTypeText") tvLocation.SubTVTypeText = GetRandomString("", 5);
            //CSSPError: property [MapObjList] and type [TVLocation] is  not implemented

            return tvLocation;
        }
        private void CheckTVLocationFields(List<TVLocation> tvLocationList)
        {
            Assert.False(string.IsNullOrWhiteSpace(tvLocationList[0].TVText));
            if (!string.IsNullOrWhiteSpace(tvLocationList[0].TVTypeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(tvLocationList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvLocationList[0].SubTVTypeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(tvLocationList[0].SubTVTypeText));
            }
        }
        #endregion Functions private
    }
}
