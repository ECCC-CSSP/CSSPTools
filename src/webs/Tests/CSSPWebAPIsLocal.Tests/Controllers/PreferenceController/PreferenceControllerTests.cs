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
using System.Text;
using CSSPHelperModels;
using CSSPDBPreferenceModels;

namespace CSSPWebAPIsLocal.PreferenceController.Tests
{
    public partial class CSSPWebAPIsLocalPreferenceControllerTests
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
        public async Task PreferenceController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceController_Get_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                VarNameAndValue varNameAndValue = new VarNameAndValue()
                {
                    VariableName = "TestVariableName5",
                    VariableValue = "TestVariableValue5",
                };

                string stringData = JsonSerializer.Serialize(varNameAndValue);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                string url = $"{ LocalUrl }api/{ culture }/Preference";
                var response = await httpClient.PostAsync(url, contentData);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Preference preferenceRet = JsonSerializer.Deserialize<Preference>(responseContent);
                Assert.NotNull(preferenceRet);
                Assert.Equal(varNameAndValue.VariableName, preferenceRet.VariableName);
                Assert.Equal(varNameAndValue.VariableValue, preferenceRet.VariableValue);

                url = $"{ LocalUrl }api/{ culture }/Preference";
                response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                List<Preference> preferenceListRet = JsonSerializer.Deserialize<List<Preference>>(responseContent);
                Assert.NotNull(preferenceListRet);
                Assert.True(preferenceListRet.Count > 0);

                url = $"{ LocalUrl }api/{ culture }/Preference/{ preferenceRet.PreferenceID }";
                response = await httpClient.DeleteAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                bool boolRet = JsonSerializer.Deserialize<bool>(responseContent);
                Assert.True(boolRet);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceController_AddOrChange_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            VarNameAndValue varNameAndValue = new VarNameAndValue()
            {
                VariableName = "TestVariableName",
                VariableValue = "TestVariableValue",
            };

            using (HttpClient httpClient = new HttpClient())
            {
                string stringData = JsonSerializer.Serialize(varNameAndValue);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                string url = $"{ LocalUrl }api/{ culture }/Preference";
                var response = await httpClient.PostAsync(url, contentData);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Preference preferenceRet = JsonSerializer.Deserialize<Preference>(responseContent);
                Assert.NotNull(preferenceRet);
                Assert.Equal(varNameAndValue.VariableName, preferenceRet.VariableName);
                Assert.Equal(varNameAndValue.VariableValue, preferenceRet.VariableValue);

                url = $"{ LocalUrl }api/{ culture }/Preference/{ preferenceRet.PreferenceID }";
                response = await httpClient.DeleteAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                bool boolRet = JsonSerializer.Deserialize<bool>(responseContent);
                Assert.True(boolRet);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
