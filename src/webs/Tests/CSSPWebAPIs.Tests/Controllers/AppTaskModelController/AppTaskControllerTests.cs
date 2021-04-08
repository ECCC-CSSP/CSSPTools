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
using CSSPHelperModels;
using CSSPWebModels;

namespace CSSPWebAPIs.AppTaskModelController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsAppTaskControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsAuthControllerTests()
        //{
        // See setup
        //}
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/apptaskmodel").Result;
                Assert.Equal(200, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<AppTaskModel> appTaskModelList = JsonSerializer.Deserialize<List<AppTaskModel>>(jsonStr);

                int AppTaskModelCount = appTaskModelList.Count;

                AppTaskModel appTaskModel = FillAppTaskModel();

                string stringData = JsonSerializer.Serialize(appTaskModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/apptaskmodel", contentData).Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                AppTaskModel appTaskModelRet = JsonSerializer.Deserialize<AppTaskModel>(jsonStr);
                Assert.NotNull(appTaskModelRet);

                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/apptaskmodel").Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                appTaskModelList = JsonSerializer.Deserialize<List<AppTaskModel>>(jsonStr);
                Assert.NotNull(appTaskModelList);
                Assert.Equal(AppTaskModelCount + 1, appTaskModelList.Count);

                response = httpClient.DeleteAsync($"{ CSSPAzureUrl }api/en-CA/apptaskmodel/{ appTaskModelRet.AppTask.AppTaskID }").Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                bool boolRet = JsonSerializer.Deserialize<bool>(jsonStr);
                Assert.True(boolRet);
            }
        }
        #endregion Functions public

        #region Functions private
        private AppTaskModel FillAppTaskModel()
        {
            AppTaskModel appTaskModel = new AppTaskModel();

            AppTask appTask = new AppTask()
            {
                AppTaskID = 0,
                DBCommand = DBCommandEnum.Created,
                TVItemID = 1,
                TVItemID2 = 1,
                AppTaskCommand = AppTaskCommandEnum.SyncDBs,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 10,
                Parameters = "parameters",
                Language = LanguageEnum.en,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = contact.ContactTVItemID,
            };

            appTaskModel.AppTask = appTask;

            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                AppTaskLanguage appTaskLanguage = new AppTaskLanguage()
                {
                    AppTaskLanguageID = 0,
                    DBCommand = DBCommandEnum.Created,
                    AppTaskID = 0,
                    ErrorText = "",
                    Language = lang,
                    StatusText = "This is the status text",
                    TranslationStatus = TranslationStatusEnum.Translated,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = contact.ContactTVItemID,
                };

                appTaskModel.AppTaskLanguageList.Add(appTaskLanguage);
            }

            return appTaskModel;
        }
        #endregion Functions private

    }
}
