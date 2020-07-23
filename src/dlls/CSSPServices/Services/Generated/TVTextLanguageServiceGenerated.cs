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
    public interface ITVTextLanguageService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class TVTextLanguageService : ITVTextLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            TVTextLanguage tvTextLanguage = validationContext.ObjectInstance as TVTextLanguage;

            if (string.IsNullOrWhiteSpace(tvTextLanguage.TVText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { nameof(tvTextLanguage.TVText) });
            }

            //TVText has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvTextLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(tvTextLanguage.Language) });
            }

            if (!string.IsNullOrWhiteSpace(tvTextLanguage.LanguageText) && tvTextLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "LanguageText", "100"), new[] { nameof(tvTextLanguage.LanguageText) });
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
