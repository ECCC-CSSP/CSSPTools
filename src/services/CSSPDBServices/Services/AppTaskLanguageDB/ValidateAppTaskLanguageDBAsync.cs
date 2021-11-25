namespace CSSPDBServices;

public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
{
    private async Task<bool> ValidateAppTaskLanguageDBAsync(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
    {
        string retStr = "";
        AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

        if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
        {
            if (appTaskLanguage.AppTaskLanguageID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
            }

            if (!(from c in db.AppTaskLanguages.AsNoTracking() select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()));
            }
        }

        retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLanguage.DBCommand);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }

        AppTask AppTaskAppTaskID = null;
        AppTaskAppTaskID = (from c in db.AppTasks.AsNoTracking() where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

        if (AppTaskAppTaskID == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLanguage.AppTaskID.ToString()));
        }

        retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }

        if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", "250"));
        }

        if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", "250"));
        }

        retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }

        if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"));
        }
        else
        {
            if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"));
            }
        }

        TVItem TVItemLastUpdateContactTVItemID = null;
        TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

        if (TVItemLastUpdateContactTVItemID == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()));
        }
        else
        {
            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
            if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"));
            }
        }

        return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
    }
}


