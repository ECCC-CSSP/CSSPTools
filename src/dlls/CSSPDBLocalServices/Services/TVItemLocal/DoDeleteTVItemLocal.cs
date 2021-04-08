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
        private bool DoDeleteTVItemLocal(DeleteTVItemModel deleteTVItemModel)
        {
            ValidationResults = new List<ValidationResult>();

            GzObjectList gzObjectList = FillDeleteLists(deleteTVItemModel);

            if (ValidationResults.Count() > 0)
            {
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
                        AppendToRecreate(webBaseToAdd.TVItemModel.TVItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                    }
                    catch (Exception ex)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
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

            TVItem tvItemToMarkDeleted = (from c in dbLocal.TVItems
                                          where c.TVItemID == deleteTVItemModel.TVItemID
                                          select c).FirstOrDefault();

            if (tvItemToMarkDeleted != null)
            {
                tvItemToMarkDeleted.DBCommand = DBCommandEnum.Deleted;
                tvItemToMarkDeleted.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToMarkDeleted.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                try
                {
                    dbLocal.SaveChanges();
                    AppendToRecreate(tvItemToMarkDeleted, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    List<TVItemLanguage> TVItemLanguageToDeleteList = (from c in dbLocal.TVItemLanguages
                                                                       where c.TVItemID == deleteTVItemModel.TVItemID
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
                WebBase WebBaseToChange = new WebBase();
                foreach (WebBase webBase in gzObjectList.tvItemList)
                {
                    if (webBase.TVItemModel.TVItem.TVItemID == deleteTVItemModel.TVItemID)
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
                    tvItem = WebBaseToChange.TVItemModel.TVItem;
                    tvItem.DBCommand = DBCommandEnum.Deleted;

                    dbLocal.TVItems.Add(tvItem);
                    AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                }
                else
                {
                    tvItem.IsActive = WebBaseToChange.TVItemModel.TVItem.IsActive;
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
                                                     where c.TVItemLanguageID == WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                     select c).FirstOrDefault();

                    if (tvItemLanguage == null)
                    {
                        tvItemLanguage = WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang];
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        dbLocal.TVItemLanguages.Add(tvItemLanguage);
                        AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                    }
                    else
                    {
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                        AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
                    }

                    try
                    {
                        dbLocal.SaveChanges();
                        AppendToRecreate(tvItem, 1982, deleteTVItemModel.ParentTVType, (int)deleteTVItemModel.GrandParentID);
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
                CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}