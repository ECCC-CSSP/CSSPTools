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
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace CSSPWebAPIs.TVItemUserAuthorizationManualController.Tests
{
    public partial class CSSPWebAPIsTVItemUserAuthorizationManualControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsTVItemUserAuthorizationManualControllerTests()
        //{
        // see setup
        //}
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.True(contact.ContactTVItemID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationController_GetWithContactTVItemID_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                string url = $"{ CSSPAzureUrl }api/{ culture }/TVItemUserAuthorization/GetWithContactTVItemID/{contact.ContactTVItemID}";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(responseContent);
                Assert.NotNull(tvItemUserAuthorizationList);
                Assert.True(tvItemUserAuthorizationList.Count > 0);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationController_GetWithContactTVItemID_Unauthorize_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "notworking");
                var response = await httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/TVItemUserAuthorization/GetWithContactTVItemID/{contact.ContactTVItemID}");
                Assert.True((int)response.StatusCode == 401);
            }
        }
        #endregion Functions private
    }
}
