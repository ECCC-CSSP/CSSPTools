namespace CSSPWebAPIs.AzureAppTaskController.Tests;

public partial class AzureAppTaskControllerTests
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

