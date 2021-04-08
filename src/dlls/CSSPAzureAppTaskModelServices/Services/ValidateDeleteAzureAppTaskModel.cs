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
        private bool ValidateDeleteAzureAppTaskModel(int AppTaskID)
        {
            ValidationResults = new List<ValidationResult>();

            if (AppTaskID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), new[] { "AppTaskID" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}