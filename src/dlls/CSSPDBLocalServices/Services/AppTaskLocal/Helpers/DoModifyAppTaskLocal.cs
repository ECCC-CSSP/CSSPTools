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
        private async Task<bool> DoModifyAppTaskLocal(AppTaskLocalModel appTaskModel)
        {
            AppTask appTask = (from c in dbLocal.AppTasks
                               where c.AppTaskID == appTaskModel.AppTask.AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel.AppTask.AppTaskID.ToString()));
                return false;
            }

            FillAppTask(appTask, appTaskModel.AppTask);

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

                AppTaskLanguage appTaskLanguage = (from c in dbLocal.AppTaskLanguages
                                                   where c.AppTaskLanguageID == appTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID
                                                   select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID.ToString()));
                    return false;
                }

                FillAppTaskLanguage(appTaskLanguage, appTaskModel.AppTaskLanguageList[langID]);

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

