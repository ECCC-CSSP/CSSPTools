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
    public partial class ElementLayerServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IElementLayerService ElementLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementLayerServiceTest() : base()
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
        public async Task ElementLayer_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ElementLayer elementLayer = GetFilledRandomElementLayer("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 1000)]
            // elementLayer.Layer   (Int32)
            // -----------------------------------


            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.Layer = 0;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "1000"))).Any());

            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.Layer = 1001;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "1000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // elementLayer.ZMin   (Double)
            // -----------------------------------


            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.ZMin = -2.0D;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMin", "-1", "-1"))).Any());

            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.ZMin = 0.0D;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMin", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // elementLayer.ZMax   (Double)
            // -----------------------------------


            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.ZMax = -2.0D;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMax", "-1", "-1"))).Any());

            elementLayer = null;
            elementLayer = GetFilledRandomElementLayer("");
            elementLayer.ZMax = 0.0D;
            ElementLayerService.Validate(new ValidationContext(elementLayer));
            Assert.True(ElementLayerService.errRes.ErrList.Count() > 0);
            Assert.True(ElementLayerService.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMax", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // elementLayer.Element   (Element)
            // -----------------------------------

            //CSSPError: Type not implemented [Element]

            //CSSPError: Type not implemented [Element]

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
            Services.AddSingleton<IElementLayerService, ElementLayerService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            ElementLayerService = Provider.GetService<IElementLayerService>();
            Assert.NotNull(ElementLayerService);

            return await Task.FromResult(true);
        }
        private ElementLayer GetFilledRandomElementLayer(string OmitPropName)
        {
            ElementLayer elementLayer = new ElementLayer();

            if (OmitPropName != "Layer") elementLayer.Layer = GetRandomInt(1, 1000);
            if (OmitPropName != "ZMin") elementLayer.ZMin = GetRandomDouble(-1.0D, -1.0D);
            if (OmitPropName != "ZMax") elementLayer.ZMax = GetRandomDouble(-1.0D, -1.0D);
            //CSSPError: property [Element] and type [ElementLayer] is  not implemented

            return elementLayer;
        }

        #endregion Functions private
    }
}
