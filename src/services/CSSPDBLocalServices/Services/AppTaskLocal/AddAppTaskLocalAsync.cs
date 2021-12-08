namespace CSSPDBLocalServices;

public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
{
    public async Task<ActionResult<AppTaskModel>> AddAppTaskLocalAsync(AppTaskModel appTaskLocalModel)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel appTaskModel)";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check AppTaskModel.AppTask
        if (appTaskLocalModel.AppTask.AppTaskID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
        }

        if (appTaskLocalModel.AppTask.TVItemID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }

        if (appTaskLocalModel.AppTask.TVItemID2 == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
        }

        string retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTaskLocalModel.AppTask.AppTaskCommand);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
        }

        retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTaskLocalModel.AppTask.AppTaskStatus);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
        }

        if (appTaskLocalModel.AppTask.PercentCompleted < 0 || appTaskLocalModel.AppTask.PercentCompleted > 100)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"));
        }

        if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTask.Parameters))
        {
            if (appTaskLocalModel.AppTask.Parameters.Length > 100000)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Parameters", "100000"));
            }
        }

        retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTask.Language);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }

        if (appTaskLocalModel.AppTask.StartDateTime_UTC.Year < 1980)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
        }

        if (appTaskLocalModel.AppTask.EndDateTime_UTC != null)
        {
            if (((DateTime)appTaskLocalModel.AppTask.EndDateTime_UTC).Year < 1980)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
            }

            if (appTaskLocalModel.AppTask.StartDateTime_UTC > appTaskLocalModel.AppTask.EndDateTime_UTC)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "StartDateTime_UTC"));
            }
        }

        if (appTaskLocalModel.AppTaskLanguageList.Count != 2)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageList.Count", "2"));
        }
        #endregion Check AppTaskModel.AppTask

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Check AppTaskModel.AppTaskLanguage EN
        if (appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
        }

        if (appTaskLocalModel.AppTaskLanguageList[0].AppTaskID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
        }

        if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[0].StatusText))
        {
            if (appTaskLocalModel.AppTaskLanguageList[0].StatusText.Length > 250)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
            }
        }

        if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[0].ErrorText))
        {
            if (appTaskLocalModel.AppTaskLanguageList[0].ErrorText.Length > 250)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
            }
        }
        #endregion Check AppTaskModel.AppTaskLanguage EN

        #region Check AppTaskModel.AppTaskLanguage FR
        if (appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
        }

        if (appTaskLocalModel.AppTaskLanguageList[1].AppTaskID != 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
        }

        if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[1].StatusText))
        {
            if (appTaskLocalModel.AppTaskLanguageList[1].StatusText.Length > 250)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
            }
        }

        if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[1].ErrorText))
        {
            if (appTaskLocalModel.AppTaskLanguageList[1].ErrorText.Length > 250)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
            }
        }
        #endregion Check AppTaskModel.AppTaskLanguage FR

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Adding AppTask
        AppTask appTask = (from c in dbLocal.AppTasks
                           where c.TVItemID == appTaskLocalModel.AppTask.TVItemID
                           && c.TVItemID2 == appTaskLocalModel.AppTask.TVItemID2
                           && c.AppTaskCommand == appTaskLocalModel.AppTask.AppTaskCommand
                           select c).FirstOrDefault();

        if (appTask != null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        int AppTaskIDNew = (from c in dbLocal.AppTasks
                            where c.AppTaskID < 0
                            orderby c.AppTaskID ascending
                            select c.AppTaskID).FirstOrDefault() - 1;

        appTaskLocalModel.AppTask.AppTaskID = AppTaskIDNew;
        appTaskLocalModel.AppTask.DBCommand = DBCommandEnum.Created;
        appTaskLocalModel.AppTask.StartDateTime_UTC = DateTime.UtcNow;
        appTaskLocalModel.AppTask.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
        appTaskLocalModel.AppTask.LastUpdateDate_UTC = DateTime.UtcNow;

        try
        {
            dbLocal.AppTasks.Add(appTaskLocalModel.AppTask);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
        }
        #endregion Adding AppTask

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Adding AppTaskLanguage EN
        int AppTaskLanguageIDNewEN = (from c in dbLocal.AppTaskLanguages
                                      where c.AppTaskLanguageID < 0
                                      orderby c.AppTaskLanguageID ascending
                                      select c.AppTaskLanguageID).FirstOrDefault() - 1;

        appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID = AppTaskLanguageIDNewEN;
        appTaskLocalModel.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Created;
        appTaskLocalModel.AppTaskLanguageList[0].AppTaskID = appTaskLocalModel.AppTask.AppTaskID;
        appTaskLocalModel.AppTaskLanguageList[0].Language = LanguageEnum.en;
        appTaskLocalModel.AppTaskLanguageList[0].TranslationStatus = TranslationStatusEnum.Translated;
        appTaskLocalModel.AppTaskLanguageList[0].LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
        appTaskLocalModel.AppTaskLanguageList[0].LastUpdateDate_UTC = DateTime.UtcNow;

        try
        {
            dbLocal.AppTaskLanguages.Add(appTaskLocalModel.AppTaskLanguageList[0]);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
        }
        #endregion Adding AppTaskLanguage EN

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Adding AppTaskLanguage FR
        int AppTaskLanguageIDNewFR = (from c in dbLocal.AppTaskLanguages
                                      where c.AppTaskLanguageID < 0
                                      orderby c.AppTaskLanguageID ascending
                                      select c.AppTaskLanguageID).FirstOrDefault() - 1;

        appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID = AppTaskLanguageIDNewFR;
        appTaskLocalModel.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Created;
        appTaskLocalModel.AppTaskLanguageList[1].AppTaskID = appTaskLocalModel.AppTask.AppTaskID;
        appTaskLocalModel.AppTaskLanguageList[1].Language = LanguageEnum.fr;
        appTaskLocalModel.AppTaskLanguageList[1].TranslationStatus = TranslationStatusEnum.Translated;
        appTaskLocalModel.AppTaskLanguageList[1].LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
        appTaskLocalModel.AppTaskLanguageList[1].LastUpdateDate_UTC = DateTime.UtcNow;

        try
        {
            dbLocal.AppTaskLanguages.Add(appTaskLocalModel.AppTaskLanguageList[1]);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
        }
        #endregion Adding AppTaskLanguage FR

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(appTaskLocalModel));
    }
}
