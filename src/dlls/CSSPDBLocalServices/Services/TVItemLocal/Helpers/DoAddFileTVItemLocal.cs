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
        private async Task<bool> DoAddFileTVItemLocal(TVItemLocalModel tvItemLocalModel)
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
                        //if (!(tvItemModel.TVItem.TVType == TVTypeEnum.MikeScenario
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.MWQMSite
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.PolSourceSite
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.Infrastructure
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.MikeSource
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                        //    || tvItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide))
                        //{
                        //    AppendToRecreate(tvItemModel.TVItem, tvItemLocalModel.TVItemParent.TVType);
                        //}
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

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = DBCommandEnum.Created,
                IsActive = true,
                ParentID = tvItemLocalModel.TVItem.ParentID,
                TVItemID = TVItemIDNew,
                TVLevel = gzObjectList.ParentTVItem.TVLevel + 1,
                TVPath = $"{ gzObjectList.ParentTVItem.TVPath }p{TVItemIDNew}",
                TVType = tvItemLocalModel.TVItem.TVType,
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
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
                else if (tvItemNew.TVType == TVTypeEnum.File)
                {
                    if (tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Area
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Country
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Municipality
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Province
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Root
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Sector
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Subsector)
                    {
                        AppendToRecreate(tvItemLocalModel.TVItem, tvItemLocalModel.TVItemParent.TVType);
                    }
                    else if (tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.Infrastructure
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.MikeScenario
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.MWQMSite
                        || tvItemLocalModel.TVItemParent.TVType == TVTypeEnum.PolSourceSite)
                    {
                        AppendToRecreate(tvItemLocalModel.TVItemParent, tvItemLocalModel.TVItemParent.TVType);
                    }
                }
                else
                {
                    AppendToRecreate(tvItemNew, tvItemLocalModel.TVItemParent.TVType);
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
                    TVText = lang == LanguageEnum.fr ? tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText : tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
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

