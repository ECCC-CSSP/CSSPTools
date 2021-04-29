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

    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        private bool DoDeleteAppTaskLocal(int appTaskID)
        {
            ValidationResults = new List<ValidationResult>();

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
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTaskLanguageList", ex.Message), new[] { "" }));
                return false;
            }

            // Removing AppTask item
            AppTask appTaskToDelete = (from c in dbLocal.AppTasks
                                       where c.AppTaskID == appTaskID
                                       select c).FirstOrDefault();

            if (appTaskToDelete == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskID.ToString()), new[] { "" }));
                return false;
            }

            dbLocal.AppTasks.Remove(appTaskToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message), new[] { "" }));
                return false;
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}