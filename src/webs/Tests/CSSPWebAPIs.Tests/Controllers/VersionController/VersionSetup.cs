/*
 * manually edited
 *
 */

using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPWebAPIs.VersionController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsVersionControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebAPIsVersionControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> VersionSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Assert.NotNull(Configuration["CSSPAzureUrl"]);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
