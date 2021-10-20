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
        private async Task<bool> DoDeleteTVItemLocal(TVItemLocalModel tvItemLocalModel)
        {
            GzObjectList gzObjectList = FillDeleteLists(tvItemLocalModel);

            if (CSSPLogService.ErrRes.ErrList.Count() > 0)
            {
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

            TVItem tvItemToMarkDeleted = (from c in dbLocal.TVItems
                                          where c.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                          select c).FirstOrDefault();

            if (tvItemToMarkDeleted != null)
            {
                tvItemToMarkDeleted.DBCommand = DBCommandEnum.Deleted;
                tvItemToMarkDeleted.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToMarkDeleted.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                try
                {
                    dbLocal.SaveChanges();
                    if (tvItemToMarkDeleted.TVType == TVTypeEnum.MWQMRun)
                    {
                        AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.MWQMRun);
                    }
                    else if (tvItemToMarkDeleted.TVType == TVTypeEnum.MWQMSite)
                    {
                        AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.MWQMSite);
                    }
                    else if (tvItemToMarkDeleted.TVType == TVTypeEnum.PolSourceSite)
                    {
                        AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.PolSourceSite);
                    }
                    else if (tvItemToMarkDeleted.TVType == TVTypeEnum.MikeBoundaryConditionMesh || tvItemToMarkDeleted.TVType == TVTypeEnum.MikeBoundaryConditionWebTide || tvItemToMarkDeleted.TVType == TVTypeEnum.MikeSource)
                    {
                        AppendToRecreate(tvItemLocalModel.TVItemParent, TVTypeEnum.MikeScenario);
                    }
                    else
                    {
                        AppendToRecreate(tvItemToMarkDeleted, tvItemLocalModel.TVItemParent.TVType);
                    }
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    TVItemLanguage tvItemLanguageToDelete = (from c in dbLocal.TVItemLanguages
                                                             where c.TVItemID == tvItemLocalModel.TVItem.TVItemID
                                                             && c.Language == lang
                                                             select c).FirstOrDefault();

                    tvItemLanguageToDelete.DBCommand = DBCommandEnum.Deleted;
                    tvItemLanguageToDelete.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemLanguageToDelete.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                    try
                    {
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemLanguage", ex.Message));
                        return await Task.FromResult(false);
                    }
                }
            }
            else
            {
                tvItemToMarkDeleted = tvItemLocalModel.TVItem;
                tvItemToMarkDeleted.DBCommand = DBCommandEnum.Deleted;
                tvItemToMarkDeleted.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemToMarkDeleted.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                dbLocal.TVItems.Add(tvItemToMarkDeleted);
                if (tvItemToMarkDeleted.TVType == TVTypeEnum.MWQMRun)
                {
                    AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.MWQMRun);
                }
                else if (tvItemToMarkDeleted.TVType == TVTypeEnum.MWQMSite)
                {
                    AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.MWQMSite);
                }
                else if (tvItemToMarkDeleted.TVType == TVTypeEnum.PolSourceSite)
                {
                    AppendToRecreate(tvItemToMarkDeleted, TVTypeEnum.PolSourceSite);
                }
                else if (tvItemToMarkDeleted.TVType == TVTypeEnum.MikeBoundaryConditionMesh || tvItemToMarkDeleted.TVType == TVTypeEnum.MikeBoundaryConditionWebTide || tvItemToMarkDeleted.TVType == TVTypeEnum.MikeSource)
                {
                    AppendToRecreate(tvItemLocalModel.TVItemParent, TVTypeEnum.MikeScenario);
                }
                else
                {
                    AppendToRecreate(tvItemToMarkDeleted, tvItemLocalModel.TVItemParent.TVType);
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
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
                        tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                        tvItemLanguage.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                        dbLocal.TVItemLanguages.Add(tvItemLanguage);
                    }
                    else
                    {
                        tvItemLanguage.DBCommand = DBCommandEnum.Deleted;
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