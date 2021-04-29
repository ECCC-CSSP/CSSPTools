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
        private bool DoDeleteTVItemLocal(PostTVItemModel postTVItemModel)
        {
            ValidationResults = new List<ValidationResult>();

            GzObjectList gzObjectList = FillDeleteLists(postTVItemModel);

            if (ValidationResults.Count() > 0)
            {
                return false;
            }

            // filling all parent TVItem in the DBLocal
            foreach (TVItemModel tvItemModel in gzObjectList.tvItemParentList.OrderBy(c => c.TVItem.TVLevel))
            {
                if (!(from c in dbLocal.TVItems
                      where c.TVItemID == tvItemModel.TVItem.TVItemID
                      select c).Any())
                {
                    try
                    {
                        dbLocal.TVItems.Add(tvItemModel.TVItem);
                        dbLocal.SaveChanges();
                        AppendToRecreate(tvItemModel.TVItem, postTVItemModel.TVItemParent.TVType);
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
                        return false;
                    }

                    foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        if (!(from c in dbLocal.TVItemLanguages
                              where c.TVItemID == tvItemModel.TVItem.TVItemID
                              && c.Language == lang
                              select c).Any())
                        {

                            try
                            {
                                dbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[(int)lang]);
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

            TVItem tvItemToMarkDeleted = (from c in dbLocal.TVItems
                                          where c.TVItemID == postTVItemModel.TVItem.TVItemID
                                          select c).FirstOrDefault();

            if (tvItemToMarkDeleted != null)
            {
                tvItemToMarkDeleted.DBCommand = DBCommandEnum.Deleted;
                tvItemToMarkDeleted.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToMarkDeleted.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                try
                {
                    dbLocal.SaveChanges();
                    AppendToRecreate(tvItemToMarkDeleted, postTVItemModel.TVItemParent.TVType);
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    List<TVItemLanguage> TVItemLanguageToDeleteList = (from c in dbLocal.TVItemLanguages
                                                                       where c.TVItemID == postTVItemModel.TVItem.TVItemID
                                                                       select c).ToList();

                    foreach (TVItemLanguage tvItemLanguage in TVItemLanguageToDeleteList)
                    {
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        try
                        {
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemLanguage", ex.Message), new[] { "TVItemLanguage" }));
                            return false;
                        }
                    }
                }
            }
            else
            {
                TVItemModel WebBaseToChange = new TVItemModel();
                foreach (TVItemModel tvItemModel in gzObjectList.tvItemList)
                {
                    if (tvItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID)
                    {
                        WebBaseToChange = tvItemModel;
                        break;
                    }
                }

                TVItem tvItem = (from c in dbLocal.TVItems
                                 where c.TVItemID == WebBaseToChange.TVItem.TVItemID
                                 select c).FirstOrDefault();

                if (tvItem == null)
                {
                    tvItem = WebBaseToChange.TVItem;
                    tvItem.DBCommand = DBCommandEnum.Deleted;

                    dbLocal.TVItems.Add(tvItem);
                    AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                }
                else
                {
                    tvItem.IsActive = WebBaseToChange.TVItem.IsActive;
                    tvItem.DBCommand = DBCommandEnum.Deleted;
                }

                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
                    return false;
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemLanguageID == WebBaseToChange.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                     select c).FirstOrDefault();

                    if (tvItemLanguage == null)
                    {
                        tvItemLanguage = WebBaseToChange.TVItemLanguageList[(int)lang];
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        dbLocal.TVItemLanguages.Add(tvItemLanguage);
                        AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                    }
                    else
                    {
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                        AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                    }

                    try
                    {
                        dbLocal.SaveChanges();
                        AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message), new[] { "" }));
                        return false;
                    }
                }
            }

            foreach (ToRecreate toRecreate in ToRecreateList)
            {
                CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID);
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}