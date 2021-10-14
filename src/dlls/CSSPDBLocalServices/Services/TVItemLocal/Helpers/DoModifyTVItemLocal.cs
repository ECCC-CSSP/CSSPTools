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
        private async Task<bool> DoModifyTVItemLocal(TVItemLocalModel tvItemLocalModel)
        {
            GzObjectList gzObjectList = FillPostLists(tvItemLocalModel);

            if (CSSPLogService.ErrRes.ErrList.Count() > 0)
            {
                return await Task.FromResult(false);
            }

            // already exist TVTextEN
            if ((from c in gzObjectList.tvItemSiblingList
                 where c.TVItem.TVItemID != tvItemLocalModel.TVItem.TVItemID
                 && c.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText == tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText
                 select c).Any())
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, tvItemLocalModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText));
                return await Task.FromResult(false);
            }

            // already exist TVTextFR
            if ((from c in gzObjectList.tvItemSiblingList
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

            TVItem tvItemToModify = (from c in dbLocal.TVItems
                                     where c.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                     select c).FirstOrDefault();

            if (tvItemToModify != null)
            {
                tvItemToModify.DBCommand = DBCommandEnum.Modified;
                tvItemToModify.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToModify.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                try
                {
                    dbLocal.SaveChanges();
                    if (tvItemToModify.TVType == TVTypeEnum.MWQMRun)
                    {
                        AppendToRecreate(tvItemToModify, TVTypeEnum.MWQMRun);
                    }
                    else if (tvItemToModify.TVType == TVTypeEnum.MWQMSite)
                    {
                        AppendToRecreate(tvItemToModify, TVTypeEnum.MWQMSite);
                    }
                    else if (tvItemToModify.TVType == TVTypeEnum.PolSourceSite)
                    {
                        AppendToRecreate(tvItemToModify, TVTypeEnum.PolSourceSite);
                    }
                    else if (tvItemToModify.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                        || tvItemToModify.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                        || tvItemToModify.TVType == TVTypeEnum.MikeSource)
                    {
                        AppendToRecreate(tvItemLocalModel.TVItemParent, TVTypeEnum.MikeScenario);
                    }
                    else
                    {
                        AppendToRecreate(tvItemToModify, tvItemLocalModel.TVItemParent.TVType);
                    }
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    List<TVItemLanguage> TVItemLanguageToModifyList = (from c in dbLocal.TVItemLanguages
                                                                       where c.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                                       orderby c.Language
                                                                       select c).ToList();

                    foreach (TVItemLanguage tvItemLanguage in TVItemLanguageToModifyList)
                    {
                        tvItemLanguage.TVText = tvItemLocalModel.TVItemLanguageList[(int)tvItemLanguage.Language - 1].TVText;
                        tvItemLanguage.DBCommand = DBCommandEnum.Modified;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        try
                        {
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "TVItemLanguage", ex.Message));
                            return await Task.FromResult(false);
                        }
                    }
                }
            }
            else
            {
                tvItemToModify = tvItemLocalModel.TVItem;
                tvItemToModify.DBCommand = DBCommandEnum.Modified;
                tvItemToModify.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToModify.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                dbLocal.TVItems.Add(tvItemToModify);
                if (tvItemToModify.TVType == TVTypeEnum.MWQMRun)
                {
                    AppendToRecreate(tvItemToModify, TVTypeEnum.MWQMRun);
                }
                else if (tvItemToModify.TVType == TVTypeEnum.MWQMSite)
                {
                    AppendToRecreate(tvItemToModify, TVTypeEnum.MWQMSite);
                }
                else if (tvItemToModify.TVType == TVTypeEnum.PolSourceSite)
                {
                    AppendToRecreate(tvItemToModify, TVTypeEnum.PolSourceSite);
                }
                else if (tvItemToModify.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                    || tvItemToModify.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                    || tvItemToModify.TVType == TVTypeEnum.MikeSource)
                {
                    AppendToRecreate(tvItemLocalModel.TVItemParent, TVTypeEnum.MikeScenario);
                }
                else
                {
                    AppendToRecreate(tvItemToModify, tvItemLocalModel.TVItemParent.TVType);
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
                                                     where c.TVItemLanguageID == tvItemLocalModel.TVItemLanguageList[(int)lang - 1].TVItemLanguageID
                                                     select c).FirstOrDefault();

                    if (tvItemLanguage == null)
                    {
                        tvItemLanguage = tvItemLocalModel.TVItemLanguageList[(int)lang - 1];
                        tvItemLanguage.DBCommand = DBCommandEnum.Modified;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        dbLocal.TVItemLanguages.Add(tvItemLanguage);
                    }
                    else
                    {
                        tvItemLanguage.TVText = tvItemLocalModel.TVItemLanguageList[(int)tvItemLanguage.Language - 1].TVText;
                        tvItemLanguage.DBCommand = DBCommandEnum.Modified;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                    }

                    try
                    {
                        dbLocal.SaveChanges();
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

