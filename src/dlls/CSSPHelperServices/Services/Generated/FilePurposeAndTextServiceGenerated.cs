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
    public interface IFilePurposeAndTextService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class FilePurposeAndTextService : IFilePurposeAndTextService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            string retStr = "";
            FilePurposeAndText filePurposeAndText = validationContext.ObjectInstance as FilePurposeAndText;

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)filePurposeAndText.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FilePurpose"), new[] { "FilePurpose" }));
            }

            if (!string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText) && filePurposeAndText.FilePurposeText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FilePurposeText", "100"), new[] { "FilePurposeText" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
