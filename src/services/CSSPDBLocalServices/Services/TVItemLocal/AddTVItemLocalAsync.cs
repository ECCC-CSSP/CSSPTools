namespace CSSPDBLocalServices;

public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
{
    public async Task<ActionResult<TVItemModel>> AddTVItemLocalAsync(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
    {
        string parameters = "";
        if (tvItemParent != null)
        {
            parameters += $" --  tvItemParent.TVItemID = { tvItemParent.TVItemID } " +
                $"tvItemParent.TVType = { tvItemParent.TVType }";
        }

        parameters += $"tvType = { tvType } " +
        $"TVTextEN = { TVTextEN } " +
        $"TVTextFR = { TVTextFR }";

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR) -- { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check Input
        if (tvItemParent == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (tvItemParent.TVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"));
        }

        if (tvItemParent.TVType == TVTypeEnum.Root)
        {
            if (tvItemParent.TVLevel != 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVLevel"));
            }
        }
        else
        {
            if (tvItemParent.TVLevel == 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVLevel"));
            }
        }

        if (string.IsNullOrWhiteSpace(tvItemParent.TVPath))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVPath"));
        }

        string retStr = Enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"));
        }

        HelperLocalService.CheckTVTypeParentAndTVType(tvItemParent.TVType, tvType);

        if (string.IsNullOrWhiteSpace(TVTextEN))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"));
        }

        if (string.IsNullOrWhiteSpace(TVTextFR))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await HelperLocalService.CheckIfSiblingsExistWithSameTVTextAsync(tvItemParent, tvType, TVTextEN, TVTextFR, 0);

        #endregion Check Input

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<TVItemModel> tvItemModelParentList = await HelperLocalService.GetTVItemModelParentListAsync(tvItemParent, tvType);

        await AddTVItemParentLocalAsync(tvItemModelParentList);

        #region TVItem
        int TVItemIDNew = (from c in DbLocal.TVItems
                           where c.TVItemID < 0
                           orderby c.TVItemID ascending
                           select c.TVItemID).FirstOrDefault() - 1;

        TVItem tvItemNew = new TVItem()
        {
            DBCommand = DBCommandEnum.Created,
            IsActive = true,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            LastUpdateDate_UTC = DateTime.UtcNow,
            ParentID = tvItemParent.TVItemID,
            TVItemID = TVItemIDNew,
            TVLevel = tvItemParent.TVLevel + 1,
            TVPath = $"{ tvItemParent.TVPath }p{ TVItemIDNew }",
            TVType = tvType
        };

        try
        {
            DbLocal.TVItems.Add(tvItemNew);
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
        }
        #endregion TVItem

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItemLanguage EN
        int TVItemLanguageIDNewEN = (from c in DbLocal.TVItemLanguages
                                     where c.TVItemLanguageID < 0
                                     orderby c.TVItemLanguageID ascending
                                     select c.TVItemLanguageID).FirstOrDefault() - 1;

        TVItemLanguage tvItemLanguageNewEN = new TVItemLanguage()
        {
            DBCommand = DBCommandEnum.Created,
            Language = LanguageEnum.en,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            LastUpdateDate_UTC = DateTime.UtcNow,
            TranslationStatus = TranslationStatusEnum.Translated,
            TVItemID = tvItemNew.TVItemID,
            TVItemLanguageID = TVItemLanguageIDNewEN,
            TVText = TVTextEN,
        };

        try
        {
            DbLocal.TVItemLanguages.Add(tvItemLanguageNewEN);
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguageEN", ex.Message));
        }
        #endregion TVItemLanguage EN

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItemLanguage FR
        int TVItemLanguageIDNewFR = (from c in DbLocal.TVItemLanguages
                                     where c.TVItemLanguageID < 0
                                     orderby c.TVItemLanguageID ascending
                                     select c.TVItemLanguageID).FirstOrDefault() - 1;

        TVItemLanguage tvItemLanguageNewFR = new TVItemLanguage()
        {
            DBCommand = DBCommandEnum.Created,
            Language = LanguageEnum.fr,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            LastUpdateDate_UTC = DateTime.UtcNow,
            TranslationStatus = TranslationStatusEnum.Translated,
            TVItemID = tvItemNew.TVItemID,
            TVItemLanguageID = TVItemLanguageIDNewFR,
            TVText = TVTextFR,
        };

        try
        {
            DbLocal.TVItemLanguages.Add(tvItemLanguageNewFR);
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
        }
        #endregion TVItemLanguage FR

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelRet = new TVItemModel()
        {
            TVItem = tvItemNew,
            TVItemLanguageList = new List<TVItemLanguage>()
                {
                    tvItemLanguageNewEN,
                    tvItemLanguageNewFR,
                }
        };

        //tvItemModelParentList.Add(tvItemModel);

        //await HelperLocalService.RecreateLocalGzFiles(tvItemModelParentList);

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(tvItemModelRet));
    }
}
