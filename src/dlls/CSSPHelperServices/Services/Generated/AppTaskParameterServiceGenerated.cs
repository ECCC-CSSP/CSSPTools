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
    public interface IAppTaskParameterService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class AppTaskParameterService : IAppTaskParameterService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskParameterService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            AppTaskParameter appTaskParameter = validationContext.ObjectInstance as AppTaskParameter;

            if (string.IsNullOrWhiteSpace(appTaskParameter.Name))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { "Name" }));
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Name) && appTaskParameter.Name.Length > 255)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "255"), new[] { "Name" }));
            }

            if (string.IsNullOrWhiteSpace(appTaskParameter.Value))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Value"), new[] { "Value" }));
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Value) && appTaskParameter.Value.Length > 255)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Value", "255"), new[] { "Value" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
