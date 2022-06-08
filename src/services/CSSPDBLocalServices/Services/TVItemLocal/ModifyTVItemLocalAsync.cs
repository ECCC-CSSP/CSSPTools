namespace CSSPDBLocalServices;

public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
{
    public async Task<ActionResult<TVItemModel>> ModifyTVTextLocalAsync(TVItem tvItemParent, TVItemModel tvItemModel)
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


        if (tvItemModel.TVItemLanguageList.Count != 2)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "tvItemModel.TVItemLanguageList.Count", 2));
        }
        else
        {
            if (string.IsNullOrWhiteSpace(tvItemModel.TVItemLanguageList[0].TVText))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVText (en)"));
            }

            if (string.IsNullOrWhiteSpace(tvItemModel.TVItemLanguageList[1].TVText))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVText (fr)"));
            }
        }

        if (tvItemModel.TVItem.TVType == TVTypeEnum.Address)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Address"));
        }

        if (tvItemModel.TVItem.TVType == TVTypeEnum.Email)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Email"));
        }

        if (tvItemModel.TVItem.TVType == TVTypeEnum.Tel)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Tel"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        string TVTextEN = tvItemModel.TVItemLanguageList[0].TVText;
        string TVTextFR = tvItemModel.TVItemLanguageList[1].TVText;

        await HelperLocalService.CheckIfSiblingsExistWithSameTVTextAsync(tvItemParent, tvItemModel.TVItem.TVType, TVTextEN, TVTextFR, tvItemModel.TVItem.TVItemID);

        #endregion Check Input

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<TVItemModel> tvItemModelParentList = await HelperLocalService.GetTVItemModelParentListAsync(tvItemParent, tvItemModel.TVItem.TVType);

        await AddTVItemParentLocalAsync(tvItemModelParentList);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region TVItem
        TVItem tvItem = (from c in DbLocal.TVItems
                         where c.TVItemID == tvItemModel.TVItem.TVItemID
                         select c).FirstOrDefault();

        if (tvItem == null)
        {
            tvItem = tvItemModel.TVItem;

            try
            {
                tvItem.DBCommand = DBCommandEnum.Modified;
                tvItem.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItem.LastUpdateDate_UTC = DateTime.UtcNow;

                DbLocal.TVItems.Add(tvItem);
                DbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                return null;
            }
        }
        else
        {
            try
            {
                if (tvItem.DBCommand != DBCommandEnum.Created)
                {
                    tvItem.DBCommand = DBCommandEnum.Modified;
                }
                tvItem.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItem.LastUpdateDate_UTC = DateTime.UtcNow;

                DbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                return null;
            }

        }
        #endregion TVItem

        #region TVItemLanguage EN
        TVItemLanguage tvItemLanguageEN = (from c in DbLocal.TVItemLanguages
                                           where c.TVItemID == tvItemModel.TVItem.TVItemID
                                           && c.Language == LanguageEnum.en
                                           select c).FirstOrDefault();

        if (tvItemLanguageEN == null)
        {
            tvItemLanguageEN = tvItemModel.TVItemLanguageList[0];
            tvItemModel.TVItemLanguageList[0].DBCommand = DBCommandEnum.Modified;
            tvItemModel.TVItemLanguageList[0].LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemModel.TVItemLanguageList[0].LastUpdateDate_UTC = DateTime.UtcNow;

            try
            {
                DbLocal.TVItemLanguages.Add(tvItemLanguageEN);
                DbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage (en)", ex.Message));
                return null;
            }
        }
        else
        {
            if (tvItemLanguageEN.TVText != TVTextEN)
            {
                if (tvItemLanguageEN.DBCommand != DBCommandEnum.Created)
                {
                    tvItemLanguageEN.DBCommand = DBCommandEnum.Modified;
                }
                tvItemLanguageEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageEN.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
                tvItemLanguageEN.TVText = TVTextEN;

                try
                {
                    DbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguage (en)", ex.Message));
                    return null;
                }
            }
        }
        #endregion TVItemLanguage EN

        #region TVItemLanguage FR
        TVItemLanguage tvItemLanguageFR = (from c in DbLocal.TVItemLanguages
                                           where c.TVItemID == tvItemModel.TVItem.TVItemID
                                           && c.Language == LanguageEnum.fr
                                           select c).FirstOrDefault();

        if (tvItemLanguageFR == null)
        {
            tvItemLanguageFR = tvItemModel.TVItemLanguageList[1];
            tvItemLanguageFR.DBCommand = DBCommandEnum.Modified;
            tvItemLanguageFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            tvItemLanguageFR.LastUpdateDate_UTC = DateTime.UtcNow;

            try
            {
                DbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[1]);
                DbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage (fr)", ex.Message));
                return null;
            }
        }
        else
        {
            if (tvItemLanguageFR.TVText != TVTextFR)
            {
                if (tvItemLanguageFR.DBCommand != DBCommandEnum.Created)
                {
                    tvItemLanguageFR.DBCommand = DBCommandEnum.Modified;
                }
                tvItemLanguageFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageFR.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemLanguageFR.TranslationStatus = TranslationStatusEnum.Translated;
                tvItemLanguageFR.TVText = TVTextFR;

                try
                {
                    DbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguage (fr)", ex.Message));
                    return null;
                }
            }
        }
        #endregion TVItemLanguage FR

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        TVItemModel tvItemModelRet = new TVItemModel()
        {
            TVItem = tvItem,
            TVItemLanguageList = new List<TVItemLanguage>()
                {
                    tvItemLanguageEN,
                    tvItemLanguageFR,
                }
        };

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(tvItemModelRet));
    }
}
