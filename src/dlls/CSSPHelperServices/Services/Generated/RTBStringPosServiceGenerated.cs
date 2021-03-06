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
    public interface IRTBStringPosService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class RTBStringPosService : IRTBStringPosService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RTBStringPosService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            RTBStringPos rTBStringPos = validationContext.ObjectInstance as RTBStringPos;

            if (rTBStringPos.StartPos < 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "StartPos", "0"), new[] { "StartPos" }));
            }

            if (rTBStringPos.EndPos < 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "EndPos", "0"), new[] { "EndPos" }));
            }

            if (string.IsNullOrWhiteSpace(rTBStringPos.Text))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { "Text" }));
            }

            if (!string.IsNullOrWhiteSpace(rTBStringPos.Text) && rTBStringPos.Text.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Text", "100"), new[] { "Text" }));
            }

            if (string.IsNullOrWhiteSpace(rTBStringPos.TagText))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TagText"), new[] { "TagText" }));
            }

            if (!string.IsNullOrWhiteSpace(rTBStringPos.TagText) && rTBStringPos.TagText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TagText", "100"), new[] { "TagText" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
