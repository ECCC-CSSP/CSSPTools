/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIs.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using LoggedInServices;
using CSSPWebAPIs.Models;

namespace CSSPWebAPIs.VersionController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsVersionControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private CSSPWebAPIsConfigModel config { get; set; }
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
            config = new CSSPWebAPIsConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();


            config.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(config.CSSPAzureUrl);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
