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
    public partial class RunsToRemoveFromStatServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private IRunsToRemoveFromStatService RunsToRemoveFromStatService { get; set; }
        #endregion Properties

        #region Constructors
        public RunsToRemoveFromStatServiceTest() : base()
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
        public async Task RunsToRemoveFromStat_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RunsToRemoveFromStat runsToRemoveFromStat = GetFilledRandomRunsToRemoveFromStat("");


            // -----------------------------------
            // Is NOT Nullable
            // runsToRemoveFromStat.RemoveFromStat   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // runsToRemoveFromStat.MWQMRunTVItemID   (Int32)
            // -----------------------------------

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
            Services.AddSingleton<IRunsToRemoveFromStatService, RunsToRemoveFromStatService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            RunsToRemoveFromStatService = Provider.GetService<IRunsToRemoveFromStatService>();
            Assert.NotNull(RunsToRemoveFromStatService);

            return await Task.FromResult(true);
        }
        private RunsToRemoveFromStat GetFilledRandomRunsToRemoveFromStat(string OmitPropName)
        {
            RunsToRemoveFromStat runsToRemoveFromStat = new RunsToRemoveFromStat();

            if (OmitPropName != "RemoveFromStat") runsToRemoveFromStat.RemoveFromStat = true;
            // should implement a Range for the property MWQMRunTVItemID and type RunsToRemoveFromStat

            return runsToRemoveFromStat;
        }

        #endregion Functions private
    }
}
