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
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        private async Task<bool> DoAddOrModifyAppTask(PostAppTaskModel postAppTaskModel)
        {
            if (postAppTaskModel.AppTask.AppTaskID == 0)
            {
                AppTask appTask = (from c in dbLocal.AppTasks
                                   where c.TVItemID == postAppTaskModel.AppTask.TVItemID
                                   && c.TVItemID2 == postAppTaskModel.AppTask.TVItemID2
                                   && c.AppTaskCommand == postAppTaskModel.AppTask.AppTaskCommand
                                   select c).FirstOrDefault();

                if (appTask != null)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
                    return false;
                }

                int AppTaskIDNew = (from c in dbLocal.AppTasks
                                    where c.AppTaskID < 0
                                    orderby c.AppTaskID descending
                                    select c.AppTaskID).FirstOrDefault() - 1;

                postAppTaskModel.AppTask.AppTaskID = AppTaskIDNew;

                dbLocal.AppTasks.Add(postAppTaskModel.AppTask);
                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
                    return false;
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int langID = (int)lang - 1;

                    List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages
                                                                 where c.AppTaskID == postAppTaskModel.AppTask.AppTaskID
                                                                 select c).ToList();

                    if (appTaskLanguageList.Count > 0)
                    {
                        dbLocal.AppTaskLanguages.RemoveRange(appTaskLanguageList);
                        try
                        {
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTaskLanguage", ex.Message));
                            return false;
                        }
                    }

                    int AppTaskLanguageIDNew = (from c in dbLocal.AppTaskLanguages
                                                where c.AppTaskLanguageID < 0
                                                orderby c.AppTaskLanguageID descending
                                                select c.AppTaskLanguageID).FirstOrDefault() - 1;

                    postAppTaskModel.AppTaskLanguageList[langID].AppTaskID = postAppTaskModel.AppTask.AppTaskID;
                    postAppTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID = AppTaskLanguageIDNew;

                    dbLocal.AppTaskLanguages.Add(postAppTaskModel.AppTaskLanguageList[langID]);
                    try
                    {
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
                        return false;
                    }
                }
            }
            else
            {
                AppTask appTask = (from c in dbLocal.AppTasks
                                   where c.AppTaskID == postAppTaskModel.AppTask.AppTaskID
                                   select c).FirstOrDefault();

                if (appTask == null)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", postAppTaskModel.AppTask.AppTaskID.ToString()));
                    return false;
                }

                FillAppTask(appTask, postAppTaskModel.AppTask);

                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
                    return false;
                }

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int langID = (int)lang - 1;

                    AppTaskLanguage appTaskLanguage = (from c in dbLocal.AppTaskLanguages
                                                       where c.AppTaskLanguageID == postAppTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID
                                                       select c).FirstOrDefault();

                    if (appTaskLanguage == null)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", postAppTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID.ToString()));
                        return false;
                    }

                    FillAppTaskLanguage(appTaskLanguage, postAppTaskModel.AppTaskLanguageList[langID]);

                    try
                    {
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
                        return false;
                    }

                }
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}

