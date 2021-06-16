/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace CSSPWebAPIsLocal.LocalFileController.Tests
{
    public partial class CSSPWebAPIsLocalLocalFileControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private string LocalUrl { get; set; }
        private string CSSPFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebAPIsLocalLocalFileControllerTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapislocaltests.json")
               .AddUserSecrets("61f396b6-8b79-4328-a2b7-a07921135f96")
               .Build();

            LocalUrl = Configuration.GetValue<string>("LocalUrl");
            Assert.NotNull(LocalUrl);

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(CSSPFilesPath);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
