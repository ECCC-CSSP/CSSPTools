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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CSSPWebAPIs.VersionController.Tests
{
    public partial class CSSPWebAPIsVersionControllerTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VersionController_Constructor_Good_Test(string culture)
        {
            Assert.True(await VersionSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ Configuration["CSSPAzureUrl"] }Version";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.StartsWith("Version", responseContent);
            }
        }
    }
}
