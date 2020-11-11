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
    public interface IRTBStringPosService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class RTBStringPosService : IRTBStringPosService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public RTBStringPosService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            RTBStringPos rTBStringPos = validationContext.ObjectInstance as RTBStringPos;

            if (rTBStringPos.StartPos < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "StartPos", "0"), new[] { nameof(rTBStringPos.StartPos) });
            }

            if (rTBStringPos.EndPos < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "EndPos", "0"), new[] { nameof(rTBStringPos.EndPos) });
            }

            if (string.IsNullOrWhiteSpace(rTBStringPos.Text))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { nameof(rTBStringPos.Text) });
            }

            //Text has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(rTBStringPos.TagText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TagText"), new[] { nameof(rTBStringPos.TagText) });
            }

            //TagText has no StringLength Attribute

            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
