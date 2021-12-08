namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private AppTaskModel FillAppTaskModel()
    {
        AppTaskModel postAppTaskModel = new AppTaskModel();

        AppTask appTask = new AppTask()
        {
            AppTaskID = 0,
            DBCommand = DBCommandEnum.Created,
            TVItemID = 1,
            TVItemID2 = 1,
            AppTaskCommand = AppTaskCommandEnum.SyncDBs,
            AppTaskStatus = AppTaskStatusEnum.Completed,
            PercentCompleted = 10,
            Parameters = "parameters",
            Language = LanguageEnum.en,
            StartDateTime_UTC = DateTime.UtcNow,
            EndDateTime_UTC = null,
            EstimatedLength_second = null,
            RemainingTime_second = null,
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };

        postAppTaskModel.AppTask = appTask;

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
                LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            postAppTaskModel.AppTaskLanguageList.Add(appTaskLanguage);
        }

        return postAppTaskModel;
    }
}

