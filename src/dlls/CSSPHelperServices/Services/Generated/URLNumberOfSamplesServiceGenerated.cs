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
    public interface IURLNumberOfSamplesService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class URLNumberOfSamplesService : IURLNumberOfSamplesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            URLNumberOfSamples uRLNumberOfSamples = validationContext.ObjectInstance as URLNumberOfSamples;

            if (string.IsNullOrWhiteSpace(uRLNumberOfSamples.url))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "url"), new[] { "url" }));
            }

            if (!string.IsNullOrWhiteSpace(uRLNumberOfSamples.url) && (uRLNumberOfSamples.url.Length < 1 || uRLNumberOfSamples.url.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "url", "1", "255"), new[] { "url" }));
            }

            //NumberOfSamples has no Range Attribute

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
