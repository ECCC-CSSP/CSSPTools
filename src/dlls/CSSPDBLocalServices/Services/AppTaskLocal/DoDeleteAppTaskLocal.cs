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
        private async Task<bool> DoDeleteAppTaskLocal(int appTaskID)
        {
            // Removing AppTaskLanguage items before removing AppTask item
            List<AppTaskLanguage> appTaskLanguageListToDelete = (from c in dbLocal.AppTaskLanguages
                                                             where c.AppTaskID == appTaskID
                                                             select c).ToList();

            dbLocal.AppTaskLanguages.RemoveRange(appTaskLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTaskLanguageList", ex.Message));
                return false;
            }

            // Removing AppTask item
            AppTask appTaskToDelete = (from c in dbLocal.AppTasks
                                       where c.AppTaskID == appTaskID
                                       select c).FirstOrDefault();

            if (appTaskToDelete == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskID.ToString()));
                return false;
            }

            dbLocal.AppTasks.Remove(appTaskToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message));
                return false;
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}