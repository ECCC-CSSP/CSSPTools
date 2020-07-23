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
    public partial class PolSourceObsInfoChildServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IPolSourceObsInfoChildService PolSourceObsInfoChildService { get; set; }
        private PolSourceObsInfoChild polSourceObsInfoChild { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObsInfoChildService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");

            List<ValidationResult> ValidationResultsList = PolSourceObsInfoChildService.Validate(new ValidationContext(polSourceObsInfoChild)).ToList();
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
            Services.AddSingleton<IPolSourceObsInfoChildService, PolSourceObsInfoChildService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            PolSourceObsInfoChildService = Provider.GetService<IPolSourceObsInfoChildService>();
            Assert.NotNull(PolSourceObsInfoChildService);

            return await Task.FromResult(true);
        }
        private PolSourceObsInfoChild GetFilledRandomPolSourceObsInfoChild(string OmitPropName)
        {
            PolSourceObsInfoChild polSourceObsInfoChild = new PolSourceObsInfoChild();

            if (OmitPropName != "PolSourceObsInfo") polSourceObsInfoChild.PolSourceObsInfo = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoChildStart") polSourceObsInfoChild.PolSourceObsInfoChildStart = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoText") polSourceObsInfoChild.PolSourceObsInfoText = GetRandomString("", 5);
            if (OmitPropName != "PolSourceObsInfoChildStartText") polSourceObsInfoChild.PolSourceObsInfoChildStartText = GetRandomString("", 5);

            return polSourceObsInfoChild;
        }
        private void CheckPolSourceObsInfoChildFields(List<PolSourceObsInfoChild> polSourceObsInfoChildList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoText))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoText));
            }
            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoChildStartText))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoChildStartText));
            }
        }
        #endregion Functions private
    }
}
