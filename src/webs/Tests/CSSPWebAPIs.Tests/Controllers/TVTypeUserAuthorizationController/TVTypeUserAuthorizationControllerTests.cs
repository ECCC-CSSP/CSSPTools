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
using CSSPWebAPIs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace CSSPWebAPIs.TVTypeUserAuthorizationManualController.Tests
{
    public partial class CSSPWebAPIsTVTypeUserAuthorizationManualControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsTVTypeUserAuthorizationManualControllerTests()
        //{
        // see setup
        //}
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.True(contact.ContactTVItemID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_GetWithContactTVItemID_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                string url = $"{ CSSPAzureUrl }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{ contact.ContactTVItemID }";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(responseContent);
                Assert.NotNull(tvTypeUserAuthorizationList);
                Assert.True(tvTypeUserAuthorizationList.Count > 0);
            }
        }
        #endregion Functions private
    }
}
