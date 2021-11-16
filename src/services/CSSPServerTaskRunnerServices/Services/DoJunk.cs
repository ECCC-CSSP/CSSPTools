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
using System.IO;
using System.Linq;

namespace CSSPServerTaskRunnerServices
{
    public partial class ServerTaskRunnerService : ControllerBase, IServerTaskRunnerService
    {
        private bool DoJunk()
        {
            ValidationResults = new List<ValidationResult>();

            FileInfo fi = new FileInfo(@"C:\junk.txt");

            if (!fi.Exists)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName), new[] { "" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}