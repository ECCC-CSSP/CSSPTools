/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        public async Task<ActionResult<TVItemModel>> ModifyTVTextLocal(TVItem tvItemParent, TVItemModel tvItemModel)
        {
            #region Check Input
            if (tvItemParent.TVItemID == 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"));
            }

            if (tvItemModel.TVItem.TVItemID == 0)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"));
            }

            CheckTVTypeParentAndTVType(tvItemParent.TVType, tvItemModel.TVItem.TVType);

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

            await CheckIfSiblingsExistWithSameTVText(tvItemParent, tvItemModel.TVItem.TVType, TVTextEN, TVTextFR, tvItemModel.TVItem.TVItemID);

            #endregion Check Input

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            List<TVItemModel> tvItemModelParentList = await GetTVItemModelParentList(tvItemParent, tvItemModel.TVItem.TVType);

            await AddTVItemParentLocal(tvItemModelParentList);

            #region TVItem
            TVItem tvItem = (from c in dbLocal.TVItems
                             where c.TVItemID == tvItemModel.TVItem.TVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                tvItem = tvItemModel.TVItem;

                try
                {
                    dbLocal.TVItems.Add(tvItem);
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                    return null;
                }
            }
            #endregion TVItem

            #region TVItemLanguage EN
            TVItemLanguage tvItemLanguageEN = (from c in dbLocal.TVItemLanguages
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
                    dbLocal.TVItemLanguages.Add(tvItemLanguageEN);
                    dbLocal.SaveChanges();
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
                        dbLocal.SaveChanges();
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
            TVItemLanguage tvItemLanguageFR = (from c in dbLocal.TVItemLanguages
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
                    dbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[1]);
                    dbLocal.SaveChanges();
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
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguage (fr)", ex.Message));
                        return null;
                    }
                }
            }
            #endregion TVItemLanguage FR

            TVItemModel tvItemModelChanged = new TVItemModel()
            {
                TVItem = tvItem,
                TVItemLanguageList = new List<TVItemLanguage>()
                {
                    tvItemLanguageEN,
                    tvItemLanguageFR,
                }
            };

            tvItemModelParentList.Add(tvItemModelChanged);

            await RecreateLocalGzFiles(tvItemModelParentList);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            return await Task.FromResult(Ok(tvItemModelChanged));
        }
    }
}