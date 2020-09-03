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
    public partial class DataPathOfTideServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IDataPathOfTideService DataPathOfTideService { get; set; }
        private DataPathOfTide dataPathOfTide { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DataPathOfTideService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            dataPathOfTide = GetFilledRandomDataPathOfTide("");

            List<ValidationResult> ValidationResultsList = DataPathOfTideService.Validate(new ValidationContext(dataPathOfTide)).ToList();
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
            Services.AddSingleton<IDataPathOfTideService, DataPathOfTideService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            DataPathOfTideService = Provider.GetService<IDataPathOfTideService>();
            Assert.NotNull(DataPathOfTideService);

            return await Task.FromResult(true);
        }
        private DataPathOfTide GetFilledRandomDataPathOfTide(string OmitPropName)
        {
            DataPathOfTide dataPathOfTide = new DataPathOfTide();

            if (OmitPropName != "Text") dataPathOfTide.Text = GetRandomString("", 6);
            if (OmitPropName != "WebTideDataSet") dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "WebTideDataSetText") dataPathOfTide.WebTideDataSetText = GetRandomString("", 5);

            return dataPathOfTide;
        }
        private void CheckDataPathOfTideFields(List<DataPathOfTide> dataPathOfTideList)
        {
            Assert.False(string.IsNullOrWhiteSpace(dataPathOfTideList[0].Text));
            if (dataPathOfTideList[0].WebTideDataSet != null)
            {
                Assert.NotNull(dataPathOfTideList[0].WebTideDataSet);
            }
            if (!string.IsNullOrWhiteSpace(dataPathOfTideList[0].WebTideDataSetText))
            {
                Assert.False(string.IsNullOrWhiteSpace(dataPathOfTideList[0].WebTideDataSetText));
            }
        }
        #endregion Functions private
    }
}
