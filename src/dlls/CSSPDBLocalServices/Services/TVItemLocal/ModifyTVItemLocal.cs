///*
// * Manually edited
// *
// */

//using CSSPCreateGzFileServices;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using CSSPDBModels;
//using CSSPEnums;
//using CSSPLocalLoggedInServices;
//using CSSPLogServices;
//using CSSPWebModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using CSSPReadGzFileServices;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Threading.Tasks;
//using System.Linq;

//namespace CSSPDBLocalServices
//{

//    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
//    {
//        public async Task<TVItemModel> ModifyTVTextLocal(int tvItemID, string TVTextEN, string TVTextFR)
//        {
//            #region Check Input
//            if (TVItemID == 0)
//            {
//                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
//            }

//            if (tvItemParent.TVType == TVTypeEnum.Root)
//            {
//                if (tvItemParent.TVLevel != 0)
//                {
//                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
//                }
//            }
//            else
//            {
//                if (tvItemParent.TVLevel == 0)
//                {
//                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
//                }
//            }

//            if (string.IsNullOrWhiteSpace(tvItemParent.TVPath))
//            {
//                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"));
//            }

//            string retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvType);
//            if (!string.IsNullOrWhiteSpace(retStr))
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"));
//            }

//            CheckTVTypeParentAndTVType(tvItemParent.TVType, tvType);

//            if (string.IsNullOrWhiteSpace(TVTextEN))
//            {
//                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"));
//            }

//            if (string.IsNullOrWhiteSpace(TVTextFR))
//            {
//                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"));
//            }

//            #endregion Check Input

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return null;

//            #region TVItem
//            int TVItemIDNew = (from c in dbLocal.TVItems
//                               where c.TVItemID < 0
//                               orderby c.TVItemID descending
//                               select c.TVItemID).FirstOrDefault() - 1;

//            TVItem tvItemNew = new TVItem()
//            {
//                DBCommand = DBCommandEnum.Created,
//                IsActive = true,
//                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//                LastUpdateDate_UTC = DateTime.UtcNow,
//                ParentID = tvItemParent.TVItemID,
//                TVItemID = TVItemIDNew,
//                TVLevel = tvItemParent.TVLevel + 1,
//                TVPath = $"{ tvItemParent.TVPath }p{ TVItemIDNew }",
//                TVType = tvType
//            };

//            try
//            {
//                dbLocal.TVItems.Add(tvItemNew);
//                dbLocal.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
//                return null;
//            }
//            #endregion TVItem

//            #region TVItemLanguage EN
//            int TVItemLanguageIDNewEN = (from c in dbLocal.TVItemLanguages
//                                         where c.TVItemLanguageID < 0
//                                         orderby c.TVItemLanguageID descending
//                                         select c.TVItemLanguageID).FirstOrDefault() - 1;

//            TVItemLanguage tvItemLanguageNewEN = new TVItemLanguage()
//            {
//                DBCommand = DBCommandEnum.Created,
//                Language = LanguageEnum.en,
//                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//                LastUpdateDate_UTC = DateTime.UtcNow,
//                TranslationStatus = TranslationStatusEnum.Translated,
//                TVItemID = tvItemNew.TVItemID,
//                TVItemLanguageID = TVItemLanguageIDNewEN,
//                TVText = TVTextEN,
//            };

//            try
//            {
//                dbLocal.TVItemLanguages.Add(tvItemLanguageNewEN);
//                dbLocal.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguageEN", ex.Message));
//                return null;
//            }
//            #endregion TVItemLanguage EN

//            #region TVItemLanguage FR
//            int TVItemLanguageIDNewFR = (from c in dbLocal.TVItemLanguages
//                                         where c.TVItemLanguageID < 0
//                                         orderby c.TVItemLanguageID descending
//                                         select c.TVItemLanguageID).FirstOrDefault() - 1;

//            TVItemLanguage tvItemLanguageNewFR = new TVItemLanguage()
//            {
//                DBCommand = DBCommandEnum.Created,
//                Language = LanguageEnum.fr,
//                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//                LastUpdateDate_UTC = DateTime.UtcNow,
//                TranslationStatus = TranslationStatusEnum.Translated,
//                TVItemID = tvItemNew.TVItemID,
//                TVItemLanguageID = TVItemLanguageIDNewFR,
//                TVText = TVTextFR,
//            };

//            try
//            {
//                dbLocal.TVItemLanguages.Add(tvItemLanguageNewFR);
//                dbLocal.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
//                return null;
//            }
//            #endregion TVItemLanguage FR

//            TVItemModel tvItemModel = new TVItemModel()
//            {
//                TVItem = tvItemNew,
//                TVItemLanguageList = new List<TVItemLanguage>()
//                {
//                    tvItemLanguageNewEN,
//                    tvItemLanguageNewFR,
//                }
//            };

//            return await Task.FromResult(tvItemModel);
//        }
//    }
//}