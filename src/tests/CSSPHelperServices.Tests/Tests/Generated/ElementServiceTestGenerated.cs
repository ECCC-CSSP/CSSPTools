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
    public partial class ElementServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IElementService ElementService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementServiceTest() : base()
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
        public async Task Element_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Element element = GetFilledRandomElement("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // element.ID   (Int32)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.ID = 0;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // element.Type   (Int32)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.Type = 0;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "Type", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // element.NumbOfNodes   (Int32)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.NumbOfNodes = 0;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "NumbOfNodes", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // element.Value   (Double)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.Value = -2.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Value", "-1", "-1"))).Any());

            element = null;
            element = GetFilledRandomElement("");
            element.Value = 0.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Value", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // element.XNode0   (Double)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.XNode0 = -2.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "XNode0", "-1", "-1"))).Any());

            element = null;
            element = GetFilledRandomElement("");
            element.XNode0 = 0.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "XNode0", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // element.YNode0   (Double)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.YNode0 = -2.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "YNode0", "-1", "-1"))).Any());

            element = null;
            element = GetFilledRandomElement("");
            element.YNode0 = 0.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "YNode0", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-1, -1)]
            // element.ZNode0   (Double)
            // -----------------------------------


            element = null;
            element = GetFilledRandomElement("");
            element.ZNode0 = -2.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZNode0", "-1", "-1"))).Any());

            element = null;
            element = GetFilledRandomElement("");
            element.ZNode0 = 0.0D;
            ElementService.Validate(new ValidationContext(element));
            Assert.True(ElementService.ValidationResults.Count() > 0);
            Assert.True(ElementService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZNode0", "-1", "-1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // element.NodeList   (Node)
            // -----------------------------------

            //CSSPError: Type not implemented [NodeList]

            //CSSPError: Type not implemented [NodeList]

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
            Services.AddSingleton<IElementService, ElementService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            ElementService = Provider.GetService<IElementService>();
            Assert.NotNull(ElementService);

            return await Task.FromResult(true);
        }
        private Element GetFilledRandomElement(string OmitPropName)
        {
            Element element = new Element();

            if (OmitPropName != "ID") element.ID = GetRandomInt(1, 11);
            if (OmitPropName != "Type") element.Type = GetRandomInt(1, 11);
            if (OmitPropName != "NumbOfNodes") element.NumbOfNodes = GetRandomInt(1, 11);
            if (OmitPropName != "Value") element.Value = GetRandomDouble(-1.0D, -1.0D);
            if (OmitPropName != "XNode0") element.XNode0 = GetRandomDouble(-1.0D, -1.0D);
            if (OmitPropName != "YNode0") element.YNode0 = GetRandomDouble(-1.0D, -1.0D);
            if (OmitPropName != "ZNode0") element.ZNode0 = GetRandomDouble(-1.0D, -1.0D);
            //CSSPError: property [NodeList] and type [Element] is  not implemented

            return element;
        }

        #endregion Functions private
    }
}
