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

namespace CSSPServices.Tests
{
    public partial class ContourPolygonServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IContourPolygonService ContourPolygonService { get; set; }
        private ContourPolygon contourPolygon { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContourPolygonService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            contourPolygon = GetFilledRandomContourPolygon("");

            List<ValidationResult> ValidationResultsList = ContourPolygonService.Validate(new ValidationContext(contourPolygon)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IContourPolygonService, ContourPolygonService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContourPolygonService = Provider.GetService<IContourPolygonService>();
            Assert.NotNull(ContourPolygonService);

            return await Task.FromResult(true);
        }
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth_m") contourPolygon.Depth_m = GetRandomDouble(1.0D, 10000.0D);
            //CSSPError: property [ContourNodeList] and type [ContourPolygon] is  not implemented

            return contourPolygon;
        }
        private void CheckContourPolygonFields(List<ContourPolygon> contourPolygonList)
        {
        }
        #endregion Functions private
    }
}
