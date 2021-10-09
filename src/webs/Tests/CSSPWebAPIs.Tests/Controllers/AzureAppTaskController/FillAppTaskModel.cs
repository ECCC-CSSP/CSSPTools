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
    public partial class CSSPWebAPIsAppTaskControllerTests
    {
        private AppTaskLocalModel FillAppTaskModel()
        {
            AppTaskLocalModel appTaskModel = new AppTaskLocalModel();

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
    }
}
