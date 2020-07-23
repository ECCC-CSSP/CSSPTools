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
    public interface IFilePurposeAndTextService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class FilePurposeAndTextService : IFilePurposeAndTextService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            FilePurposeAndText filePurposeAndText = validationContext.ObjectInstance as FilePurposeAndText;

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)filePurposeAndText.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FilePurpose"), new[] { nameof(filePurposeAndText.FilePurpose) });
            }

            if (!string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText) && filePurposeAndText.FilePurposeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FilePurposeText", "100"), new[] { nameof(filePurposeAndText.FilePurposeText) });
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
