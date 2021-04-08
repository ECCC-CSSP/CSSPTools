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

namespace CSSPAzureAppTaskModelServices
{

    public partial class AzureAppTaskModelService : ControllerBase, IAzureAppTaskModelService
    {
        private bool DoDeleteAzureAppTaskModel(int AppTaskID)
        {
            ValidationResults = new List<ValidationResult>();

            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()), new[] { "" }));
                return false;
            }
            else
            {
                db.AppTasks.Remove(appTask);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message), new[] { "AppTask" }));
                    return false;
                }

            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}