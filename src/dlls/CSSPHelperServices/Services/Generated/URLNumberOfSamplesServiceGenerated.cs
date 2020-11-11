/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPHelperServices.exe
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

namespace CSSPDBServices
{
    public interface IURLNumberOfSamplesService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class URLNumberOfSamplesService : IURLNumberOfSamplesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            URLNumberOfSamples uRLNumberOfSamples = validationContext.ObjectInstance as URLNumberOfSamples;

            if (string.IsNullOrWhiteSpace(uRLNumberOfSamples.url))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "url"), new[] { nameof(uRLNumberOfSamples.url) });
            }

            if (!string.IsNullOrWhiteSpace(uRLNumberOfSamples.url) && (uRLNumberOfSamples.url.Length < 1 || uRLNumberOfSamples.url.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "url", "1", "255"), new[] { nameof(uRLNumberOfSamples.url) });
            }

            //NumberOfSamples has no Range Attribute

            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
