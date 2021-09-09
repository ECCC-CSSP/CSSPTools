/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPHelperModels;
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
using CSSPHelperServices.Tests;

namespace CSSPHelperServices.Tests
{
    [Collection("Sequential")]
    public partial class TVLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ITVLocationService TVLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVLocationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructors
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskParameter_Constructor_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(enums);
        }
        #endregion Tests Generated Constructors

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVLocation_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            TVLocation tvLocation = GetFilledRandomTVLocation("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // tvLocation.TVItemID   (Int32)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.TVItemID = 0;
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(255)]
            // [CSSPMinLength(1)]
            // tvLocation.TVText   (String)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("TVText");
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"))).Any());


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.TVText = GetRandomString("", 256);
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "255"))).Any());

            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.TVText = GetRandomString("", 256);
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "255"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvLocation.TVType   (TVTypeEnum)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.TVType = (TVTypeEnum)1000000;
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"))).Any());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvLocation.SubTVType   (TVTypeEnum)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.SubTVType = (TVTypeEnum)1000000;
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "SubTVType"))).Any());


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // tvLocation.TVTypeText   (String)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.TVTypeText = GetRandomString("", 101);
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTypeText", "100"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // tvLocation.SubTVTypeText   (String)
            // -----------------------------------


            tvLocation = null;
            tvLocation = GetFilledRandomTVLocation("");
            tvLocation.SubTVTypeText = GetRandomString("", 101);
            TVLocationService.Validate(new ValidationContext(tvLocation));
            Assert.True(TVLocationService.ValidationResults.Count() > 0);
            Assert.True(TVLocationService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SubTVTypeText", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // tvLocation.MapObjList   (MapObj)
            // -----------------------------------

            //CSSPError: Type not implemented [MapObjList]

            //CSSPError: Type not implemented [MapObjList]

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_cssphelperservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVLocationService, TVLocationService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

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

        #endregion Functions private
    }
}
