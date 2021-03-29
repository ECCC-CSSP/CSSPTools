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

namespace CSSPWebAPIsLocal.TVItemController.Tests
{
    public partial class TVItemControllerTests
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
        public async Task TVItemController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemController_AddOrModify_Add_Country_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = null,
                GrandParentID = 0,
                ParentID = 1,
                ParentTVType = TVTypeEnum.Root,
                TVItemID = 0,
                TVTextEN = "New Country",
                TVTextFR = "Nouveau Pays",
                TVType = TVTypeEnum.Country,
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(postTVItemModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ LocalUrl }api/{ culture }/PostTVItemModel/AddOrModify/", contentData).Result;
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.True(fiList.Count() > 0);
            Assert.True(fiList.Where(c => c.Name.Contains("-1.gz")).Any());

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       select c).ToList();

            Assert.True(tvItemList.Count() > 0);
            Assert.True(tvItemList.Where(c => c.TVItemID == -1).Any());

            List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                       select c).ToList();

            Assert.True(tvItemLanguageList.Count() > 0);
            Assert.True(tvItemLanguageList.Where(c => c.TVItemID == -1).Any());
            Assert.Equal(postTVItemModel.TVTextEN, tvItemLanguageList.Where(c => c.TVItemID == -1).First().TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemController_AddOrModify_Modify_Country_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = null,
                GrandParentID = 0,
                ParentID = 1,
                ParentTVType = TVTypeEnum.Root,
                TVItemID = 5,
                TVTextEN = "Kanada",
                TVTextFR = "Kanada",
                TVType = TVTypeEnum.Country,
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(postTVItemModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ LocalUrl }api/{ culture }/PostTVItemModel/AddOrModify/", contentData).Result;
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.True(fiList.Count() > 0);
            Assert.True(fiList.Where(c => c.Name.Contains("_5.gz")).Any());

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       select c).ToList();

            Assert.True(tvItemList.Count() > 0);
            Assert.True(tvItemList.Where(c => c.TVItemID == 5).Any());

            List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                       select c).ToList();

            Assert.True(tvItemLanguageList.Count() > 0);
            Assert.True(tvItemLanguageList.Where(c => c.TVItemID == 5).Any());
            Assert.Equal(postTVItemModel.TVTextEN, tvItemLanguageList.Where(c => c.TVItemID == 5).First().TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemController_AddOrModify_Add_Country_Missing_ParentID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = null,
                GrandParentID = 0,
                ParentID = 0,
                ParentTVType = TVTypeEnum.Root,
                TVItemID = 0,
                TVTextEN = "New Country",
                TVTextFR = "Nouveau Pays",
                TVType = TVTypeEnum.Country,
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(postTVItemModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{ LocalUrl }api/{ culture }/PostTVItemModel/AddOrModify/", contentData);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                var contents = await response.Content.ReadAsStringAsync();
                Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), contents);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
