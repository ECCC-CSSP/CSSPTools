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
        private async Task<bool> DoModifyFileTVItemLocal(TVItemLocalModel tvItemLocalModel)
        {
            GzObjectList gzObjectList = FillPostLists(tvItemLocalModel);

            if (CSSPLogService.ErrRes.ErrList.Count() > 0)
            {
                return await Task.FromResult(false);
            }

            // already exist TVTextEN
            if ((from c in gzObjectList.tvItemFileSiblingList
                 where c.TVItem.TVItemID != tvItemLocalModel.TVItem.TVItemID
                 && c.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText == tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText
                 select c).Any())
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText));
                return await Task.FromResult(false);
            }

            // already exist TVTextFR
            if ((from c in gzObjectList.tvItemFileSiblingList
                 where c.TVItem.TVItemID != tvItemLocalModel.TVItem.TVItemID
                 && c.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText == tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText
                 select c).Any())
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText));
                return await Task.FromResult(false);
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
                        AppendToRecreate(tvItemModel.TVItem, tvItemLocalModel.TVItemParent.TVType);
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
                                dbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[(int)lang - 1]);
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


            TVItemModel tvItemModelToChange = new TVItemModel();
            if (tvItemLocalModel.TVItem.TVType == TVTypeEnum.File)
            {
                foreach (TVItemModel tvItemModel in gzObjectList.tvItemFileSiblingList)
                {
                    if (tvItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID)
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
                    if (tvItemModel.TVItem.TVItemID == tvItemLocalModel.TVItem.TVItemID)
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
                    AppendToRecreate(tvItemNew, tvItemLocalModel.TVItemParent.TVType);
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
                                                 where c.TVItemLanguageID == tvItemModelToChange.TVItemLanguageList[(int)lang - 1].TVItemLanguageID
                                                 select c).FirstOrDefault();

                string tvText = lang == LanguageEnum.fr ? tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText : tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText;
                if (tvItemLanguage == null)
                {
                    TVItemLanguage tvItemLanguageNew = tvItemModelToChange.TVItemLanguageList[(int)lang - 1];
                    if (tvItemModelToChange.TVItemLanguageList[(int)lang - 1].TVText == tvText)
                    {
                        tvItemLanguageNew.DBCommand = DBCommandEnum.Original;
                    }
                    else
                    {
                        tvItemLanguageNew.DBCommand = DBCommandEnum.Modified;
                        tvItemLanguageNew.TVText = tvText;
                        tvItemLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguageNew.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
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
                        AppendToRecreate(tvItem, tvItemLocalModel.TVItemParent.TVType);
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
                    tvItemLanguage.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                }

                try
                {
                    dbLocal.SaveChanges();
                    AppendToRecreate(tvItem, tvItemLocalModel.TVItemParent.TVType);
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
                    return await Task.FromResult(false);
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

