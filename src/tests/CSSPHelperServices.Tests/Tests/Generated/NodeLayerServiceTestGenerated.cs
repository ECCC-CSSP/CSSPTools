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
    public partial class NodeLayerServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private INodeLayerService NodeLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerServiceTest() : base()
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
        public async Task NodeLayer_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            NodeLayer nodeLayer = GetFilledRandomNodeLayer("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 100)]
            // nodeLayer.Layer   (Int32)
            // -----------------------------------


            nodeLayer = null;
            nodeLayer = GetFilledRandomNodeLayer("");
            nodeLayer.Layer = 0;
            NodeLayerService.Validate(new ValidationContext(nodeLayer));
            Assert.True(NodeLayerService.ValidationResults.Count() > 0);
            Assert.True(NodeLayerService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"))).Any());

            nodeLayer = null;
            nodeLayer = GetFilledRandomNodeLayer("");
            nodeLayer.Layer = 101;
            NodeLayerService.Validate(new ValidationContext(nodeLayer));
            Assert.True(NodeLayerService.ValidationResults.Count() > 0);
            Assert.True(NodeLayerService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10000, 10000)]
            // nodeLayer.Z   (Double)
            // -----------------------------------


            nodeLayer = null;
            nodeLayer = GetFilledRandomNodeLayer("");
            nodeLayer.Z = -10001.0D;
            NodeLayerService.Validate(new ValidationContext(nodeLayer));
            Assert.True(NodeLayerService.ValidationResults.Count() > 0);
            Assert.True(NodeLayerService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-10000", "10000"))).Any());

            nodeLayer = null;
            nodeLayer = GetFilledRandomNodeLayer("");
            nodeLayer.Z = 10001.0D;
            NodeLayerService.Validate(new ValidationContext(nodeLayer));
            Assert.True(NodeLayerService.ValidationResults.Count() > 0);
            Assert.True(NodeLayerService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-10000", "10000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // nodeLayer.Node   (Node)
            // -----------------------------------

            //CSSPError: Type not implemented [Node]

            //CSSPError: Type not implemented [Node]

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_CSSPDBServicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<INodeLayerService, NodeLayerService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            NodeLayerService = Provider.GetService<INodeLayerService>();
            Assert.NotNull(NodeLayerService);

            return await Task.FromResult(true);
        }
        private NodeLayer GetFilledRandomNodeLayer(string OmitPropName)
        {
            NodeLayer nodeLayer = new NodeLayer();

            if (OmitPropName != "Layer") nodeLayer.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Z") nodeLayer.Z = GetRandomDouble(-10000.0D, 10000.0D);
            //CSSPError: property [Node] and type [NodeLayer] is  not implemented

            return nodeLayer;
        }

        #endregion Functions private
    }
}
