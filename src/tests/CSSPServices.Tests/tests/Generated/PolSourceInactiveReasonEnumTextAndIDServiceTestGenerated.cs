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
    public partial class PolSourceInactiveReasonEnumTextAndIDServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IPolSourceInactiveReasonEnumTextAndIDService PolSourceInactiveReasonEnumTextAndIDService { get; set; }
        private PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceInactiveReasonEnumTextAndIDService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceInactiveReasonEnumTextAndID = GetFilledRandomPolSourceInactiveReasonEnumTextAndID("");

            List<ValidationResult> ValidationResultsList = PolSourceInactiveReasonEnumTextAndIDService.Validate(new ValidationContext(polSourceInactiveReasonEnumTextAndID)).ToList();
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
            Services.AddSingleton<IPolSourceInactiveReasonEnumTextAndIDService, PolSourceInactiveReasonEnumTextAndIDService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            PolSourceInactiveReasonEnumTextAndIDService = Provider.GetService<IPolSourceInactiveReasonEnumTextAndIDService>();
            Assert.NotNull(PolSourceInactiveReasonEnumTextAndIDService);

            return await Task.FromResult(true);
        }
        private PolSourceInactiveReasonEnumTextAndID GetFilledRandomPolSourceInactiveReasonEnumTextAndID(string OmitPropName)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = new PolSourceInactiveReasonEnumTextAndID();

            if (OmitPropName != "Text") polSourceInactiveReasonEnumTextAndID.Text = GetRandomString("", 20);
            if (OmitPropName != "ID") polSourceInactiveReasonEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceInactiveReasonEnumTextAndID;
        }
        private void CheckPolSourceInactiveReasonEnumTextAndIDFields(List<PolSourceInactiveReasonEnumTextAndID> polSourceInactiveReasonEnumTextAndIDList)
        {
            Assert.False(string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndIDList[0].Text));
        }
        #endregion Functions private
    }
}
