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
        public async Task<ActionResult<TVItemModel>> DeleteTVItemLocal(TVItem tvItemParent, TVItemModel tvItemModel)
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

            await CheckIfChildExist(tvItemParent, tvItemModel.TVItem);

            #endregion Check Input

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region TVItem
            TVItem tvItemLocal = (from c in dbLocal.TVItems
                                  where c.TVItemID == tvItemModel.TVItem.TVItemID
                                  select c).FirstOrDefault();

            if (tvItemLocal == null)
            {
                tvItemLocal = tvItemModel.TVItem;
                tvItemLocal.DBCommand = DBCommandEnum.Deleted;
                tvItemLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLocal.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.TVItems.Add(tvItemModel.TVItem);
            }
            else
            {
                tvItemLocal.DBCommand = DBCommandEnum.Deleted;
                tvItemLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLocal.LastUpdateDate_UTC = DateTime.UtcNow;
            }

            try
            {
                dbLocal.SaveChanges();
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
            TVItemLanguage tvItemLanguageLocalEN = (from c in dbLocal.TVItemLanguages
                                                    where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                    && c.Language == LanguageEnum.en
                                                    select c).FirstOrDefault();

            if (tvItemLanguageLocalEN == null)
            {
                tvItemLanguageLocalEN = tvItemModel.TVItemLanguageList[0];
                tvItemLanguageLocalEN.DBCommand = DBCommandEnum.Deleted;
                tvItemLanguageLocalEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageLocalEN.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.TVItemLanguages.Add(tvItemLanguageLocalEN);
            }
            else
            {
                tvItemLanguageLocalEN.DBCommand = DBCommandEnum.Deleted;
                tvItemLanguageLocalEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageLocalEN.LastUpdateDate_UTC = DateTime.UtcNow;
            }

            try
            {
                dbLocal.SaveChanges();
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
            TVItemLanguage tvItemLanguageLocalFR = (from c in dbLocal.TVItemLanguages
                                                    where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                    && c.Language == LanguageEnum.fr
                                                    select c).FirstOrDefault();

            if (tvItemLanguageLocalFR == null)
            {
                tvItemLanguageLocalFR = tvItemModel.TVItemLanguageList[1];
                tvItemLanguageLocalFR.DBCommand = DBCommandEnum.Deleted;
                tvItemLanguageLocalFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageLocalFR.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.TVItemLanguages.Add(tvItemLanguageLocalFR);
            }
            else
            {
                tvItemLanguageLocalFR.DBCommand = DBCommandEnum.Deleted;
                tvItemLanguageLocalFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                tvItemLanguageLocalFR.LastUpdateDate_UTC = DateTime.UtcNow;
            }

            try
            {
                dbLocal.SaveChanges();
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

            return await Task.FromResult(Ok(tvItemModelRet));
        }
    }
}