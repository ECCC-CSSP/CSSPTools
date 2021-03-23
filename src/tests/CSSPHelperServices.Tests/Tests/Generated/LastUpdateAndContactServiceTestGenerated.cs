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
    public partial class LastUpdateAndContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILastUpdateAndContactService LastUpdateAndContactService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactServiceTest() : base()
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
        public async Task LastUpdateAndContact_Properties_Test(string culture)
        {
            List<ValidationResult> ValidationResultList = new List<ValidationResult>();
            IEnumerable<ValidationResult> validationResults;
            Assert.True(await Setup(culture));



            LastUpdateAndContact lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // lastUpdateAndContact.LastUpdateAndContactDate_UTC   (DateTime)
            // -----------------------------------


            lastUpdateAndContact = null;
            lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");
            lastUpdateAndContact.LastUpdateAndContactDate_UTC = new DateTime();
            validationResults = LastUpdateAndContactService.Validate(new ValidationContext(lastUpdateAndContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateAndContactDate_UTC"))).Any());

            lastUpdateAndContact = null;
            lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");
            lastUpdateAndContact.LastUpdateAndContactDate_UTC = new DateTime(1979, 1, 1);
            validationResults = LastUpdateAndContactService.Validate(new ValidationContext(lastUpdateAndContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateAndContactDate_UTC", "1980"))).Any());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, -1)]
            // lastUpdateAndContact.LastUpdateAndContactTVItemID   (Int32)
            // -----------------------------------


            lastUpdateAndContact = null;
            lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");
            lastUpdateAndContact.LastUpdateAndContactTVItemID = 0;
            validationResults = LastUpdateAndContactService.Validate(new ValidationContext(lastUpdateAndContact));
            ValidationResultList = validationResults.ToList();
            Assert.True(ValidationResultList.Count() > 0);
            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, "LastUpdateAndContactTVItemID", "1"))).Any());
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
            Services.AddSingleton<ILastUpdateAndContactService, LastUpdateAndContactService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            LastUpdateAndContactService = Provider.GetService<ILastUpdateAndContactService>();
            Assert.NotNull(LastUpdateAndContactService);

            return await Task.FromResult(true);
        }
        private LastUpdateAndContact GetFilledRandomLastUpdateAndContact(string OmitPropName)
        {
            LastUpdateAndContact lastUpdateAndContact = new LastUpdateAndContact();

            if (OmitPropName != "LastUpdateAndContactDate_UTC") lastUpdateAndContact.LastUpdateAndContactDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateAndContactTVItemID") lastUpdateAndContact.LastUpdateAndContactTVItemID = GetRandomInt(1, 11);

            return lastUpdateAndContact;
        }

        #endregion Functions private
    }
}
