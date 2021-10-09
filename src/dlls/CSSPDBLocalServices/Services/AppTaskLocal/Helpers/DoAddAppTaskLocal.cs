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
        private async Task<bool> DoAddAppTaskLocal(AppTaskLocalModel appTaskModel)
        {
            AppTask appTask = (from c in dbLocal.AppTasks
                               where c.TVItemID == appTaskModel.AppTask.TVItemID
                               && c.TVItemID2 == appTaskModel.AppTask.TVItemID2
                               && c.AppTaskCommand == appTaskModel.AppTask.AppTaskCommand
                               select c).FirstOrDefault();

            if (appTask != null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
                return false;
            }

            int AppTaskIDNew = (from c in dbLocal.AppTasks
                                where c.AppTaskID < 0
                                orderby c.AppTaskID descending
                                select c.AppTaskID).FirstOrDefault() - 1;

            appTaskModel.AppTask.AppTaskID = AppTaskIDNew;

            dbLocal.AppTasks.Add(appTaskModel.AppTask);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
                return false;
            }

            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                int langID = (int)lang - 1;

                List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages
                                                             where c.AppTaskID == appTaskModel.AppTask.AppTaskID
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
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTaskLanguage", ex.Message));
                        return false;
                    }
                }

                int AppTaskLanguageIDNew = (from c in dbLocal.AppTaskLanguages
                                            where c.AppTaskLanguageID < 0
                                            orderby c.AppTaskLanguageID descending
                                            select c.AppTaskLanguageID).FirstOrDefault() - 1;

                appTaskModel.AppTaskLanguageList[langID].AppTaskID = appTaskModel.AppTask.AppTaskID;
                appTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID = AppTaskLanguageIDNew;

                dbLocal.AppTaskLanguages.Add(appTaskModel.AppTaskLanguageList[langID]);
                try
                {
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
                    return false;
                }
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}

