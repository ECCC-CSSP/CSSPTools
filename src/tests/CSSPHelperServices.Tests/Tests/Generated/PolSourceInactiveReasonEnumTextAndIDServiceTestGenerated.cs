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
    public partial class PolSourceInactiveReasonEnumTextAndIDServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IPolSourceInactiveReasonEnumTextAndIDService PolSourceInactiveReasonEnumTextAndIDService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDServiceTest() : base()
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
        public async Task PolSourceInactiveReasonEnumTextAndID_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = GetFilledRandomPolSourceInactiveReasonEnumTextAndID("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(1000)]
            // polSourceInactiveReasonEnumTextAndID.Text   (String)
            // -----------------------------------


            polSourceInactiveReasonEnumTextAndID = null;
            polSourceInactiveReasonEnumTextAndID = GetFilledRandomPolSourceInactiveReasonEnumTextAndID("Text");
            PolSourceInactiveReasonEnumTextAndIDService.Validate(new ValidationContext(polSourceInactiveReasonEnumTextAndID));
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Count() > 0);
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Text"))).Any());


            polSourceInactiveReasonEnumTextAndID = null;
            polSourceInactiveReasonEnumTextAndID = GetFilledRandomPolSourceInactiveReasonEnumTextAndID("");
            polSourceInactiveReasonEnumTextAndID.Text = GetRandomString("", 1001);
            PolSourceInactiveReasonEnumTextAndIDService.Validate(new ValidationContext(polSourceInactiveReasonEnumTextAndID));
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Count() > 0);
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Text", "1000"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // polSourceInactiveReasonEnumTextAndID.ID   (Int32)
            // -----------------------------------


            polSourceInactiveReasonEnumTextAndID = null;
            polSourceInactiveReasonEnumTextAndID = GetFilledRandomPolSourceInactiveReasonEnumTextAndID("");
            polSourceInactiveReasonEnumTextAndID.ID = 0;
            PolSourceInactiveReasonEnumTextAndIDService.Validate(new ValidationContext(polSourceInactiveReasonEnumTextAndID));
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Count() > 0);
            Assert.True(PolSourceInactiveReasonEnumTextAndIDService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"))).Any());
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
            Services.AddSingleton<IPolSourceInactiveReasonEnumTextAndIDService, PolSourceInactiveReasonEnumTextAndIDService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            PolSourceInactiveReasonEnumTextAndIDService = Provider.GetService<IPolSourceInactiveReasonEnumTextAndIDService>();
            Assert.NotNull(PolSourceInactiveReasonEnumTextAndIDService);

            return await Task.FromResult(true);
        }
        private PolSourceInactiveReasonEnumTextAndID GetFilledRandomPolSourceInactiveReasonEnumTextAndID(string OmitPropName)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = new PolSourceInactiveReasonEnumTextAndID();

            if (OmitPropName != "Text") polSourceInactiveReasonEnumTextAndID.Text = GetRandomString("", 5);
            if (OmitPropName != "ID") polSourceInactiveReasonEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceInactiveReasonEnumTextAndID;
        }

        #endregion Functions private
    }
}
