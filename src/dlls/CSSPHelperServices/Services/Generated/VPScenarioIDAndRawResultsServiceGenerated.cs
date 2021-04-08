/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPHelperModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPHelperServices
{
    public interface IVPScenarioIDAndRawResultsService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class VPScenarioIDAndRawResultsService : IVPScenarioIDAndRawResultsService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = validationContext.ObjectInstance as VPScenarioIDAndRawResults;

            if (vpScenarioIDAndRawResults.VPScenarioID < 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "VPScenarioID", "1"), new[] { "VPScenarioID" }));
            }

            if (string.IsNullOrWhiteSpace(vpScenarioIDAndRawResults.RawResults))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RawResults"), new[] { "RawResults" }));
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioIDAndRawResults.RawResults) && vpScenarioIDAndRawResults.RawResults.Length > 1000000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "RawResults", "1000000"), new[] { "RawResults" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
