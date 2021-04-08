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
    public interface IElementLayerService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class ElementLayerService : IElementLayerService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ElementLayerService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ElementLayer elementLayer = validationContext.ObjectInstance as ElementLayer;

            if (elementLayer.Layer < 1 || elementLayer.Layer > 1000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "1000"), new[] { "Layer" }));
            }

            if (elementLayer.ZMin < -1 || elementLayer.ZMin > -1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMin", "-1", "-1"), new[] { "ZMin" }));
            }

            if (elementLayer.ZMax < -1 || elementLayer.ZMax > -1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ZMax", "-1", "-1"), new[] { "ZMax" }));
            }

                //CSSPError: Type not implemented [Element] of type [Element]

                //CSSPError: Type not implemented [Element] of type [Element]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
