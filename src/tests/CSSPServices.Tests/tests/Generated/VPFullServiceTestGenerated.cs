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
    public partial class VPFullServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IVPFullService VPFullService { get; set; }
        private VPFull vpFull { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPFullService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            vpFull = GetFilledRandomVPFull("");

            List<ValidationResult> ValidationResultsList = VPFullService.Validate(new ValidationContext(vpFull)).ToList();
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
            Services.AddSingleton<IVPFullService, VPFullService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            VPFullService = Provider.GetService<IVPFullService>();
            Assert.NotNull(VPFullService);

            return await Task.FromResult(true);
        }
        private VPFull GetFilledRandomVPFull(string OmitPropName)
        {
            VPFull vpFull = new VPFull();

            //CSSPError: property [VPScenario] and type [VPFull] is  not implemented
            //CSSPError: property [VPAmbientList] and type [VPFull] is  not implemented
            //CSSPError: property [VPResultList] and type [VPFull] is  not implemented

            return vpFull;
        }
        private void CheckVPFullFields(List<VPFull> vpFullList)
        {
        }
        #endregion Functions private
    }
}
