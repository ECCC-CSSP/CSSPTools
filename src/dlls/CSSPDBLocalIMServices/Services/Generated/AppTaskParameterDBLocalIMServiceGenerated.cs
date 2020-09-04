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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalIMServices
{
    public interface IAppTaskParameterService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class AppTaskParameterService : IAppTaskParameterService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public AppTaskParameterService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            AppTaskParameter appTaskParameter = validationContext.ObjectInstance as AppTaskParameter;

            if (string.IsNullOrWhiteSpace(appTaskParameter.Name))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { nameof(appTaskParameter.Name) });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Name) && appTaskParameter.Name.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "255"), new[] { nameof(appTaskParameter.Name) });
            }

            if (string.IsNullOrWhiteSpace(appTaskParameter.Value))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Value"), new[] { nameof(appTaskParameter.Value) });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Value) && appTaskParameter.Value.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Value", "255"), new[] { nameof(appTaskParameter.Value) });
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
