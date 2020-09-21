/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CSSPWebAPIs.EmptyController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsEmptyControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsEmptyControllerTests()
        //{
        // See setup
        //}
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmptyController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ CSSPAzureUrl }Empty";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.StartsWith("Empty", responseContent);
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
