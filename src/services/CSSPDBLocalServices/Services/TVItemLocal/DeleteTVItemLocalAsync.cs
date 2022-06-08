namespace CSSPDBLocalServices;

public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
{
    public async Task<ActionResult<TVItemModel>> DeleteTVItemLocalAsync(TVItem tvItemParent, TVItemModel tvItemModel)
    {
        string parameters = "";
        if (tvItemParent != null)
        {
            parameters += $" --  tvItemParent.TVItemID = { tvItemParent.TVItemID } " +
                $"tvItemParent.TVType = { tvItemParent.TVType }";
        }

        if (tvItemModel != null)
        {
            parameters += $" --  tvItemModel.TVItem.TVItemID = { tvItemModel.TVItem.TVItemID } " +
                $"tvItemModel.TVItem.TVType = { tvItemModel.TVItem.TVType }";
        }

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItem tvItemParent, TVItemModel tvItemModel) -- { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check Input
        if (tvItemParent == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"));
        }

        if (tvItemModel == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemModel"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (tvItemParent.TVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"));
        }

        string retStr = Enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemParent.TVType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType"));
        }

        if (tvItemModel.TVItem.TVItemID == 0)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"));
        }

        retStr = Enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemModel.TVItem.TVType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemModel.TVItem.TVType"));
        }

        HelperLocalService.CheckTVTypeParentAndTVType(tvItemParent.TVType, tvItemModel.TVItem.TVType);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await HelperLocalService.CheckIfChildExistAsync(tvItemParent, tvItemModel.TVItem);

        #endregion Check Input

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<TVItemModel> tvItemModelParentList = await HelperLocalService.GetTVItemModelParentListAsync(tvItemParent, tvItemModel.TVItem.TVType);

        await AddTVItemParentLocalAsync(tvItemModelParentList);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItem
        TVItem tvItemLocal = (from c in DbLocal.TVItems
                              where c.TVItemID == tvItemModel.TVItem.TVItemID
                              select c).FirstOrDefault();

        if (tvItemLocal == null)
        {
            tvItemLocal = tvItemModel.TVItem;
            tvItemLocal.DBCommand = DBCommandEnum.Deleted;
            tvItemLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLocal.LastUpdateDate_UTC = DateTime.UtcNow;

            DbLocal.TVItems.Add(tvItemLocal);
        }
        else
        {
            tvItemLocal.DBCommand = DBCommandEnum.Deleted;
            tvItemLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLocal.LastUpdateDate_UTC = DateTime.UtcNow;
        }

        try
        {
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            if (tvItemLocal == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
            }
            else
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItem", ex.Message));
            }
        }
        #endregion TVItem

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItemLanguage EN
        TVItemLanguage tvItemLanguageLocalEN = (from c in DbLocal.TVItemLanguages
                                                where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                && c.Language == LanguageEnum.en
                                                select c).FirstOrDefault();

        if (tvItemLanguageLocalEN == null)
        {
            tvItemLanguageLocalEN = tvItemModel.TVItemLanguageList[0];
            tvItemLanguageLocalEN.DBCommand = DBCommandEnum.Deleted;
            tvItemLanguageLocalEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLanguageLocalEN.LastUpdateDate_UTC = DateTime.UtcNow;

            DbLocal.TVItemLanguages.Add(tvItemLanguageLocalEN);
        }
        else
        {
            tvItemLanguageLocalEN.DBCommand = DBCommandEnum.Deleted;
            tvItemLanguageLocalEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLanguageLocalEN.LastUpdateDate_UTC = DateTime.UtcNow;
        }

        try
        {
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            if (tvItemLanguageLocalEN == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguageEN", ex.Message));
            }
            else
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguageEN", ex.Message));
            }
        }
        #endregion TVItemLanguage EN

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItemLanguage FR
        TVItemLanguage tvItemLanguageLocalFR = (from c in DbLocal.TVItemLanguages
                                                where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                && c.Language == LanguageEnum.fr
                                                select c).FirstOrDefault();

        if (tvItemLanguageLocalFR == null)
        {
            tvItemLanguageLocalFR = tvItemModel.TVItemLanguageList[1];
            tvItemLanguageLocalFR.DBCommand = DBCommandEnum.Deleted;
            tvItemLanguageLocalFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLanguageLocalFR.LastUpdateDate_UTC = DateTime.UtcNow;

            DbLocal.TVItemLanguages.Add(tvItemLanguageLocalFR);
        }
        else
        {
            tvItemLanguageLocalFR.DBCommand = DBCommandEnum.Deleted;
            tvItemLanguageLocalFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLanguageLocalFR.LastUpdateDate_UTC = DateTime.UtcNow;
        }

        try
        {
            DbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            if (tvItemLanguageLocalFR == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguageFR", ex.Message));
            }
            else
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguageFR", ex.Message));
            }
        }
        #endregion TVItemLanguage FR

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelRet = new TVItemModel()
        {
            TVItem = tvItemLocal,
            TVItemLanguageList = new List<TVItemLanguage>()
                {
                    tvItemLanguageLocalEN,
                    tvItemLanguageLocalFR,
                }
        };

        //tvItemModelParentList.Add(tvItemModel);

        //await HelperLocalService.RecreateLocalGzFiles(tvItemModelParentList);

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(tvItemModelRet));
    }
}
