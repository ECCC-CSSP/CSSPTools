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
using CSSPWebModels;
using System.Text;
using CSSPCultureServices.Resources;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CSSPWebAPIsLocal.Tests
{
    public partial class CountryLocalControllerTests
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
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CountryLocalControllerSetup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddCountryLocal_ParentTVItemID_1_Good_Test(string culture)
        {
            Assert.True(await CountryLocalControllerSetup(culture));

            int ParentTVItemID = 1;

            TVItemModel tvItemModel = new TVItemModel();

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(ParentTVItemID);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["LocalUrl"] }api/{ culture }/CountryLocal/", contentData).Result;
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                string responseContent = await response.Content.ReadAsStringAsync();
                tvItemModel = JsonSerializer.Deserialize<TVItemModel>(responseContent);
                Assert.NotNull(tvItemModel);

            }

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.True(fiList.Count() > 0);
            Assert.True(fiList.Where(c => c.Name.Contains("-1.gz")).Any());

            TVItem tvItem = (from c in dbLocal.TVItems
                             where c.TVItemID == -1
                             select c).FirstOrDefault();

            Assert.NotNull(tvItem);
            Assert.Equal(-1, tvItem.TVItemID);

            List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                       where c.TVItemID == -1
                                                       select c).ToList();

            Assert.True(tvItemLanguageList.Count() == 2);
            Assert.Equal(-1, tvItemLanguageList[0].TVItemID);
            Assert.Equal(-2, tvItemLanguageList[1].TVItemID);
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
