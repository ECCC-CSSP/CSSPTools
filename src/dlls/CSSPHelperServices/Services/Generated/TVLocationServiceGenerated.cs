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
    public interface ITVLocationService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class TVLocationService : ITVLocationService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVLocationService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            string retStr = "";
            TVLocation tvLocation = validationContext.ObjectInstance as TVLocation;

            if (tvLocation.TVItemID < 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"), new[] { "TVItemID" }));
            }

            if (string.IsNullOrWhiteSpace(tvLocation.TVText))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { "TVText" }));
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVText) && (tvLocation.TVText.Length < 1 || tvLocation.TVText.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "255"), new[] { "TVText" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvLocation.SubTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SubTVType"), new[] { "SubTVType" }));
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVTypeText) && tvLocation.TVTypeText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTypeText", "100"), new[] { "TVTypeText" }));
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.SubTVTypeText) && tvLocation.SubTVTypeText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SubTVTypeText", "100"), new[] { "SubTVTypeText" }));
            }

                //CSSPError: Type not implemented [MapObjList] of type [List`1]

                //CSSPError: Type not implemented [MapObjList] of type [MapObj]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
