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
    public interface IPolSourceInactiveReasonEnumTextAndIDService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class PolSourceInactiveReasonEnumTextAndIDService : IPolSourceInactiveReasonEnumTextAndIDService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = validationContext.ObjectInstance as PolSourceInactiveReasonEnumTextAndID;

            if (string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndID.Text))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { "Text" }));
            }

            if (!string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndID.Text) && polSourceInactiveReasonEnumTextAndID.Text.Length > 1000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Text", "1000"), new[] { "Text" }));
            }

            if (polSourceInactiveReasonEnumTextAndID.ID < 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"), new[] { "ID" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
