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
    public interface ITVTextLanguageService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class TVTextLanguageService : ITVTextLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageService(IEnums enums)
        {
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
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { "TVText" });
            }

            //TVText has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvTextLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(tvTextLanguage.LanguageText) && tvTextLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "LanguageText", "100"), new[] { "LanguageText" });
            }

        }
        #endregion Functions public
    }

}
