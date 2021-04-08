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
    public interface IVarNameAndValueService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class VarNameAndValueService : IVarNameAndValueService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public VarNameAndValueService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            VarNameAndValue varNameAndValue = validationContext.ObjectInstance as VarNameAndValue;

            if (string.IsNullOrWhiteSpace(varNameAndValue.VariableName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableName"), new[] { "VariableName" }));
            }

            if (!string.IsNullOrWhiteSpace(varNameAndValue.VariableName) && varNameAndValue.VariableName.Length > 200)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableName", "200"), new[] { "VariableName" }));
            }

            if (string.IsNullOrWhiteSpace(varNameAndValue.VariableValue))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VariableValue"), new[] { "VariableValue" }));
            }

            if (!string.IsNullOrWhiteSpace(varNameAndValue.VariableValue) && varNameAndValue.VariableValue.Length > 300)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableValue", "300"), new[] { "VariableValue" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
