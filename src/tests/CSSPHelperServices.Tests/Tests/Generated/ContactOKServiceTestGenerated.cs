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
    public partial class ContactOKServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IContactOKService ContactOKService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKServiceTest() : base()
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
        public async Task ContactOK_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ContactOK contactOK = GetFilledRandomContactOK("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // contactOK.ContactID   (Int32)
            // -----------------------------------


            contactOK = null;
            contactOK = GetFilledRandomContactOK("");
            contactOK.ContactID = 0;
            ContactOKService.Validate(new ValidationContext(contactOK));
            Assert.True(ContactOKService.ValidationResults.Count() > 0);
            Assert.True(ContactOKService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "ContactID", "1"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // contactOK.ContactTVItemID   (Int32)
            // -----------------------------------


            contactOK = null;
            contactOK = GetFilledRandomContactOK("");
            contactOK.ContactTVItemID = 0;
            ContactOKService.Validate(new ValidationContext(contactOK));
            Assert.True(ContactOKService.ValidationResults.Count() > 0);
            Assert.True(ContactOKService.ValidationResults.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "ContactTVItemID", "1"))).Any());
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
            Services.AddSingleton<IContactOKService, ContactOKService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            ContactOKService = Provider.GetService<IContactOKService>();
            Assert.NotNull(ContactOKService);

            return await Task.FromResult(true);
        }
        private ContactOK GetFilledRandomContactOK(string OmitPropName)
        {
            ContactOK contactOK = new ContactOK();

            if (OmitPropName != "ContactID") contactOK.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ContactTVItemID") contactOK.ContactTVItemID = GetRandomInt(1, 11);

            return contactOK;
        }

        #endregion Functions private
    }
}
