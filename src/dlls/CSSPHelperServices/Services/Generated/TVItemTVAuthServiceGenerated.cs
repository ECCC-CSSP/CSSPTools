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
    public interface ITVItemTVAuthService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class TVItemTVAuthService : ITVItemTVAuthService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            TVItemTVAuth tvItemTVAuth = validationContext.ObjectInstance as TVItemTVAuth;

            if (tvItemTVAuth.TVItemUserAuthID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemUserAuthID", "1"), new[] { nameof(tvItemTVAuth.TVItemUserAuthID) });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { nameof(tvItemTVAuth.TVText) });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVText) && (tvItemTVAuth.TVText.Length < 1 || tvItemTVAuth.TVText.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "255"), new[] { nameof(tvItemTVAuth.TVText) });
            }

            if (tvItemTVAuth.TVItemID1 < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID1", "1"), new[] { nameof(tvItemTVAuth.TVItemID1) });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTypeStr"), new[] { nameof(tvItemTVAuth.TVTypeStr) });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr) && (tvItemTVAuth.TVTypeStr.Length < 1 || tvItemTVAuth.TVTypeStr.Length > 255))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVTypeStr", "1", "255"), new[] { nameof(tvItemTVAuth.TVTypeStr) });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemTVAuth.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVAuth"), new[] { nameof(tvItemTVAuth.TVAuth) });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVAuthText) && tvItemTVAuth.TVAuthText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVAuthText", "100"), new[] { nameof(tvItemTVAuth.TVAuthText) });
            }

            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
