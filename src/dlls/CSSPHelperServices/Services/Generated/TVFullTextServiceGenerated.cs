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
    public interface ITVFullTextService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class TVFullTextService : ITVFullTextService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            TVFullText tvFullText = validationContext.ObjectInstance as TVFullText;

            if (string.IsNullOrWhiteSpace(tvFullText.TVPath))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), new[] { "TVPath" }));
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.TVPath) && (tvFullText.TVPath.Length < 1 || tvFullText.TVPath.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"), new[] { "TVPath" }));
            }

            if (string.IsNullOrWhiteSpace(tvFullText.FullText))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FullText"), new[] { "FullText" }));
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.FullText) && (tvFullText.FullText.Length < 1 || tvFullText.FullText.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FullText", "1", "255"), new[] { "FullText" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
