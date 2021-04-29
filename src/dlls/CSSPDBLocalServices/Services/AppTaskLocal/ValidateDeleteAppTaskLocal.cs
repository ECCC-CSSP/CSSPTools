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
        private bool ValidateDeleteAppTaskLocal(int appTaskID)
        {
            ValidationResults = new List<ValidationResult>();

            if (appTaskID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), new[] { "AppTaskID" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}