/*
 * This document is manually edited.
 * 
 * All testing function are generated under documents
 * EnumsTestGenerated.cs and EnumsPolSourceObsInfoEnumTestGenerated.cs
 * 
 */
using Xunit;
using System.Globalization;
using System.Threading;
using CultureServices.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CSSPEnums.Tests
{
    public partial class EnumsTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnums enums { get; set; }
        private ICultureService CultureService { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsTest()
        {
        }
        #endregion Constructors

        // All the testing function are under the EnumsGeneratedTest.cs

        #region Testing Methods private
        #endregion Testing Methods private

        #region Functions private
        private async Task<bool> SetupTest(string culture)
        {
            Services = new ServiceCollection();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICultureService, CultureService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
