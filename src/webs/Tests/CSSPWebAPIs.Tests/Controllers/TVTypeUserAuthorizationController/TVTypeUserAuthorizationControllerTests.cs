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
using CSSPHelperModels;

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
            Assert.True(await TVTypeUserAuthorizationSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.True(contact.ContactTVItemID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_GetWithContactTVItemID_Good_Test(string culture)
        {
            Assert.True(await TVTypeUserAuthorizationSetup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                string url = $"{ CSSPAzureUrl }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{contact.ContactTVItemID}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<TVTypeUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
                Assert.NotNull(tvItemUserAuthorizationList);
                Assert.True(tvItemUserAuthorizationList.Count == 0);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_GetWithContactTVItemID_WithItemInDB_Good_Test(string culture)
        {
            Assert.True(await TVTypeUserAuthorizationSetup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization()
            {
                //TVTypeUserAuthorizationID = 1,
                ContactTVItemID = contact.ContactTVItemID,
                DBCommand = DBCommandEnum.Original,
                TVAuth = TVAuthEnum.Read,
                TVType = TVTypeEnum.Address,
                LastUpdateContactTVItemID = contact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
            };

            try
            {
                dbTempAzureTest.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);
                dbTempAzureTest.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                string url = $"{ CSSPAzureUrl }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{contact.ContactTVItemID}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
                Assert.NotNull(tvTypeUserAuthorizationList);
                Assert.True(tvTypeUserAuthorizationList.Count == 1);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_GetWithContactTVItemID_Unauthorize_Error_Test(string culture)
        {
            Assert.True(await TVTypeUserAuthorizationSetup(culture));
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "notworking");
                HttpResponseMessage response = await httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{contact.ContactTVItemID}");
                Assert.Equal(401, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
                Assert.NotNull(errRes);
                Assert.NotEmpty(errRes.ErrList);
            }
        }
        #endregion Functions private
    }
}
