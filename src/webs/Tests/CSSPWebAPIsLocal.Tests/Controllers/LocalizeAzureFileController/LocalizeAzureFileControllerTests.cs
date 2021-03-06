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
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace CSSPWebAPIsLocal.LocalizeAzureFileController.Tests
{
    public partial class CSSPWebAPIsLocalLocalizeAzureFileControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFileController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFileController_1_BarTopBottom_png_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/LocalizeAzureFile/1/BarTopBottom.png";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                bool retBool = JsonSerializer.Deserialize<bool>(responseContent);
                Assert.True(retBool);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
