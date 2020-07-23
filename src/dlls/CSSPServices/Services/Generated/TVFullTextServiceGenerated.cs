/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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

namespace CSSPServices
{
    public interface ITVFullTextService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class TVFullTextService : ITVFullTextService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVFullTextService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            TVFullText tvFullText = validationContext.ObjectInstance as TVFullText;

            if (string.IsNullOrWhiteSpace(tvFullText.TVPath))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), new[] { nameof(tvFullText.TVPath) });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.TVPath) && (tvFullText.TVPath.Length < 1 || tvFullText.TVPath.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVPath", "1", "255"), new[] { nameof(tvFullText.TVPath) });
            }

            if (string.IsNullOrWhiteSpace(tvFullText.FullText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FullText"), new[] { nameof(tvFullText.FullText) });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.FullText) && (tvFullText.FullText.Length < 1 || tvFullText.FullText.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FullText", "1", "255"), new[] { nameof(tvFullText.FullText) });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions public

    }
}
