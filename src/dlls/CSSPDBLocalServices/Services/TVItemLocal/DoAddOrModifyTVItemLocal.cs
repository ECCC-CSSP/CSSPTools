/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private bool DoAddOrModifyTVItem(PostTVItemModel postTVItemModel)
        {
            ValidationResults = new List<ValidationResult>();

            GzObjectList gzObjectList = FillPostLists(postTVItemModel);

            if (ValidationResults.Count() > 0)
            {
                return false;
            }

            // already exist TVTextEN
            if ((from c in gzObjectList.tvItemSiblingList
                 where c.TVItemModel.TVItem.TVItemID != postTVItemModel.TVItemID
                 && c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText == postTVItemModel.TVTextEN
                 select c).Any())
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVTextEN), new[] { "TVTextEN" }));
                return false;
            }

            // already exist TVTextFR
            if ((from c in gzObjectList.tvItemSiblingList
                 where c.TVItemModel.TVItem.TVItemID != postTVItemModel.TVItemID
                 && c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText == postTVItemModel.TVTextFR
                 select c).Any())
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVTextFR), new[] { "TVTextFR" }));
                return false;
            }

            // filling all parent TVItem in the DBLocal
            foreach (WebBase webBaseToAdd in gzObjectList.tvItemParentList.OrderBy(c => c.TVItemModel.TVItem.TVLevel))
            {
                if (!(from c in dbLocal.TVItems
                      where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                      select c).Any())
                {
                    try
                    {
                        dbLocal.TVItems.Add(webBaseToAdd.TVItemModel.TVItem);
                        dbLocal.SaveChanges();
                        AppendToRecreate(webBaseToAdd.TVItemModel.TVItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "TVItem" }));
                        return false;
                    }

                    foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        if (!(from c in dbLocal.TVItemLanguages
                              where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                              && c.Language == lang
                              select c).Any())
                        {

                            try
                            {
                                dbLocal.TVItemLanguages.Add(webBaseToAdd.TVItemModel.TVItemLanguageList[(int)lang]);
                                dbLocal.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message), new[] { "TVItem" }));
                                return false;
                            }
                        }
                    }
                }
            }

            int TVItemIDNew = (from c in dbLocal.TVItems
                               where c.TVItemID < 0
                               orderby c.TVItemID descending
                               select c.TVItemID).FirstOrDefault() - 1;

            if (postTVItemModel.TVItemID == 0)
            {
                TVItem tvItemNew = new TVItem()
                {
                    DBCommand = DBCommandEnum.Created,
                    IsActive = true,
                    ParentID = postTVItemModel.ParentID,
                    TVItemID = TVItemIDNew,
                    TVLevel = gzObjectList.ParentTVItem.TVLevel + 1,
                    TVPath = $"{ gzObjectList.ParentTVItem.TVPath }p{TVItemIDNew}",
                    TVType = postTVItemModel.TVType,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                };

                try
                {
                    dbLocal.TVItems.Add(tvItemNew);
                    dbLocal.SaveChanges();
                    AppendToRecreate(tvItemNew, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "TVItem" }));
                    return false;
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int TVItemLanguageIDNew = (from c in dbLocal.TVItemLanguages
                                               where c.TVItemLanguageID < 0
                                               orderby c.TVItemLanguageID descending
                                               select c.TVItemLanguageID).FirstOrDefault() - 1;

                    TVItemLanguage tvItemLanguageNew = new TVItemLanguage()
                    {
                        TVItemLanguageID = TVItemLanguageIDNew,
                        DBCommand = DBCommandEnum.Created,
                        TVItemID = TVItemIDNew,
                        Language = lang,
                        TranslationStatus = TranslationStatusEnum.Translated,
                        TVText = lang == LanguageEnum.fr ? postTVItemModel.TVTextFR : postTVItemModel.TVTextEN,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                    };

                    try
                    {
                        dbLocal.TVItemLanguages.Add(tvItemLanguageNew);
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message), new[] { "TVItemLanguage" }));
                        return false;
                    }
                }
            }
            else
            {
                WebBase WebBaseToChange = new WebBase();
                foreach (WebBase webBase in gzObjectList.tvItemSiblingList)
                {
                    if (webBase.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItemID)
                    {
                        WebBaseToChange = webBase;
                        break;
                    }
                }

                TVItem tvItem = (from c in dbLocal.TVItems
                                 where c.TVItemID == WebBaseToChange.TVItemModel.TVItem.TVItemID
                                 select c).FirstOrDefault();

                if (tvItem == null)
                {
                    TVItem tvItemNew = WebBaseToChange.TVItemModel.TVItem;

                    dbLocal.TVItems.Add(tvItemNew);
                    AppendToRecreate(tvItemNew, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                    tvItem = tvItemNew;
                }
                else
                {
                    tvItem.IsActive = WebBaseToChange.TVItemModel.TVItem.IsActive;
                }

                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "TVItem" }));
                    return false;
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemLanguageID == WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                     select c).FirstOrDefault();

                    string tvText = lang == LanguageEnum.fr ? postTVItemModel.TVTextFR : postTVItemModel.TVTextEN;
                    if (tvItemLanguage == null)
                    {
                        TVItemLanguage tvItemLanguageNew = WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang];
                        if (WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVText == tvText)
                        {
                            tvItemLanguageNew.DBCommand = DBCommandEnum.Original;
                        }
                        else
                        {
                            tvItemLanguageNew.DBCommand = DBCommandEnum.Modified;
                            tvItemLanguageNew.TVText = tvText;
                            tvItemLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
                            tvItemLanguageNew.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                        }

                        dbLocal.TVItemLanguages.Add(tvItemLanguageNew);
                        AppendToRecreate(tvItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                    }
                    else
                    {
                        if (tvItemLanguage.DBCommand == DBCommandEnum.Original)
                        {
                            tvItemLanguage.DBCommand = DBCommandEnum.Modified;
                        }
                        tvItemLanguage.TVText = tvText;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                    }

                    try
                    {
                        dbLocal.SaveChanges();
                        AppendToRecreate(tvItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message), new[] { "TVItemLanguage" }));
                        return false;
                    }

                }
            }

            foreach (ToRecreate toRecreate in ToRecreateList)
            {
                CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}

