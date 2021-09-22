/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private async Task<bool> DoAddOrModifyTVItem(PostTVItemModel postTVItemModel)
        {
            GzObjectList gzObjectList = FillPostLists(postTVItemModel);

            if (CSSPLogService.ErrRes.ErrList.Count() > 0)
            {
                return await Task.FromResult(false);
            }

            if (postTVItemModel.TVItem.TVType == TVTypeEnum.File)
            {
                // already exist TVTextEN
                if ((from c in gzObjectList.tvItemFileSiblingList
                     where c.TVItem.TVItemID != postTVItemModel.TVItem.TVItemID
                     && c.TVItemLanguageList[(int)LanguageEnum.en].TVText == postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText
                     select c).Any())
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText));
                    return await Task.FromResult(false);
                }

                // already exist TVTextFR
                if ((from c in gzObjectList.tvItemFileSiblingList
                     where c.TVItem.TVItemID != postTVItemModel.TVItem.TVItemID
                     && c.TVItemLanguageList[(int)LanguageEnum.fr].TVText == postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText
                     select c).Any())
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText));
                    return await Task.FromResult(false);
                }
            }
            else
            {
                // already exist TVTextEN
                if ((from c in gzObjectList.tvItemSiblingList
                     where c.TVItem.TVItemID != postTVItemModel.TVItem.TVItemID
                     && c.TVItemLanguageList[(int)LanguageEnum.en].TVText == postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText
                     select c).Any())
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText));
                    return await Task.FromResult(false);
                }

                // already exist TVTextFR
                if ((from c in gzObjectList.tvItemSiblingList
                     where c.TVItem.TVItemID != postTVItemModel.TVItem.TVItemID
                     && c.TVItemLanguageList[(int)LanguageEnum.fr].TVText == postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText
                     select c).Any())
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText));
                    return await Task.FromResult(false);
                }
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
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                        return await Task.FromResult(false);
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
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
                                return await Task.FromResult(false);
                            }
                        }
                    }
                }
            }

            int TVItemIDNew = (from c in dbLocal.TVItems
                               where c.TVItemID < 0
                               orderby c.TVItemID descending
                               select c.TVItemID).FirstOrDefault() - 1;

            if (postTVItemModel.TVItem.TVItemID == 0)
            {
                TVItem tvItemNew = new TVItem()
                {
                    DBCommand = DBCommandEnum.Created,
                    IsActive = true,
                    ParentID = postTVItemModel.TVItem.ParentID,
                    TVItemID = TVItemIDNew,
                    TVLevel = gzObjectList.ParentTVItem.TVLevel + 1,
                    TVPath = $"{ gzObjectList.ParentTVItem.TVPath }p{TVItemIDNew}",
                    TVType = postTVItemModel.TVItem.TVType,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                };

                try
                {
                    dbLocal.TVItems.Add(tvItemNew);
                    dbLocal.SaveChanges();
                    if (tvItemNew.TVType == TVTypeEnum.MWQMRun)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.MWQMRun);
                    }
                    else if (tvItemNew.TVType == TVTypeEnum.MWQMSite)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.MWQMSite);
                    }
                    else if (tvItemNew.TVType == TVTypeEnum.PolSourceSite)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.PolSourceSite);
                    }
                    else
                    {
                        AppendToRecreate(tvItemNew, postTVItemModel.TVItemParent.TVType);
                    }
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                    return await Task.FromResult(false);
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
                        TVText = lang == LanguageEnum.fr ? postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText : postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText,
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
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
                        return await Task.FromResult(false);
                    }
                }
            }
            else
            {
                TVItemModel tvItemModelToChange = new TVItemModel();
                if (postTVItemModel.TVItem.TVType == TVTypeEnum.File)
                {
                    foreach (TVItemModel tvItemModel in gzObjectList.tvItemFileSiblingList)
                    {
                        if (tvItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID)
                        {
                            tvItemModelToChange = tvItemModel;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (TVItemModel tvItemModel in gzObjectList.tvItemSiblingList)
                    {
                        if (tvItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID)
                        {
                            tvItemModelToChange = tvItemModel;
                            break;
                        }
                    }
                }

                TVItem tvItem = (from c in dbLocal.TVItems
                                 where c.TVItemID == tvItemModelToChange.TVItem.TVItemID
                                 select c).FirstOrDefault();

                if (tvItem == null)
                {
                    TVItem tvItemNew = tvItemModelToChange.TVItem;

                    dbLocal.TVItems.Add(tvItemNew);
                    tvItem = tvItemNew;
                    if (tvItemNew.TVType == TVTypeEnum.MWQMRun)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.MWQMRun);
                    }
                    else if (tvItemNew.TVType == TVTypeEnum.MWQMSite)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.MWQMSite);
                    }
                    else if (tvItemNew.TVType == TVTypeEnum.PolSourceSite)
                    {
                        AppendToRecreate(tvItemNew, TVTypeEnum.PolSourceSite);
                    }
                    else
                    {
                        AppendToRecreate(tvItemNew, postTVItemModel.TVItemParent.TVType);
                    }
                }
                else
                {
                    tvItem.IsActive = tvItemModelToChange.TVItem.IsActive;
                }

                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                    return await Task.FromResult(false);
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemLanguageID == tvItemModelToChange.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                     select c).FirstOrDefault();

                    string tvText = lang == LanguageEnum.fr ? postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText : postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText;
                    if (tvItemLanguage == null)
                    {
                        TVItemLanguage tvItemLanguageNew = tvItemModelToChange.TVItemLanguageList[(int)lang];
                        if (tvItemModelToChange.TVItemLanguageList[(int)lang].TVText == tvText)
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

                        if (tvItem.TVType == TVTypeEnum.MWQMRun)
                        {
                            AppendToRecreate(tvItem, TVTypeEnum.MWQMRun);
                        }
                        else if (tvItem.TVType == TVTypeEnum.MWQMSite)
                        {
                            AppendToRecreate(tvItem, TVTypeEnum.MWQMSite);
                        }
                        else if (tvItem.TVType == TVTypeEnum.PolSourceSite)
                        {
                            AppendToRecreate(tvItem, TVTypeEnum.PolSourceSite);
                        }
                        else
                        {
                            AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                        }
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
                        AppendToRecreate(tvItem, postTVItemModel.TVItemParent.TVType);
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
                        return await Task.FromResult(false);
                    }

                }
            }

            foreach (ToRecreate toRecreate in ToRecreateList)
            {
                var actionRes = await CreateGzFileService.CreateGzFile(toRecreate.WebType, toRecreate.TVItemID);
                if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                {
                    ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                    CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
                }
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}

