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
    public interface ILabSheetAndA1SheetService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class LabSheetAndA1SheetService : ILabSheetAndA1SheetService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            LabSheetAndA1Sheet labSheetAndA1Sheet = validationContext.ObjectInstance as LabSheetAndA1Sheet;

                //CSSPError: Type not implemented [LabSheet] of type [LabSheet]

                //CSSPError: Type not implemented [LabSheet] of type [LabSheet]
                //CSSPError: Type not implemented [LabSheetA1Sheet] of type [LabSheetA1Sheet]

                //CSSPError: Type not implemented [LabSheetA1Sheet] of type [LabSheetA1Sheet]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
