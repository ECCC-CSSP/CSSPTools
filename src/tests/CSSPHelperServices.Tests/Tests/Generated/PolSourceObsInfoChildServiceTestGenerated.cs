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
    public partial class PolSourceObsInfoChildServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IPolSourceObsInfoChildService PolSourceObsInfoChildService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildServiceTest() : base()
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
        public async Task PolSourceObsInfoChild_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PolSourceObsInfoChild polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceObsInfoChild.PolSourceObsInfo   (PolSourceObsInfoEnum)
            // -----------------------------------


            polSourceObsInfoChild = null;
            polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");
            polSourceObsInfoChild.PolSourceObsInfo = (PolSourceObsInfoEnum)1000000;
            PolSourceObsInfoChildService.Validate(new ValidationContext(polSourceObsInfoChild));
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Count() > 0);
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObsInfo"))).Any());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceObsInfoChild.PolSourceObsInfoChildStart   (PolSourceObsInfoEnum)
            // -----------------------------------


            polSourceObsInfoChild = null;
            polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");
            polSourceObsInfoChild.PolSourceObsInfoChildStart = (PolSourceObsInfoEnum)1000000;
            PolSourceObsInfoChildService.Validate(new ValidationContext(polSourceObsInfoChild));
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Count() > 0);
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObsInfoChildStart"))).Any());


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // polSourceObsInfoChild.PolSourceObsInfoText   (String)
            // -----------------------------------


            polSourceObsInfoChild = null;
            polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");
            polSourceObsInfoChild.PolSourceObsInfoText = GetRandomString("", 101);
            PolSourceObsInfoChildService.Validate(new ValidationContext(polSourceObsInfoChild));
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Count() > 0);
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceObsInfoText", "100"))).Any());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // polSourceObsInfoChild.PolSourceObsInfoChildStartText   (String)
            // -----------------------------------


            polSourceObsInfoChild = null;
            polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");
            polSourceObsInfoChild.PolSourceObsInfoChildStartText = GetRandomString("", 101);
            PolSourceObsInfoChildService.Validate(new ValidationContext(polSourceObsInfoChild));
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Count() > 0);
            Assert.True(PolSourceObsInfoChildService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceObsInfoChildStartText", "100"))).Any());
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
            Services.AddSingleton<IPolSourceObsInfoChildService, PolSourceObsInfoChildService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

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

        #endregion Functions private
    }
}
