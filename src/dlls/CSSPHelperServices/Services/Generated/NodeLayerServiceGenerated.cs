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
    public interface INodeLayerService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class NodeLayerService : INodeLayerService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            NodeLayer nodeLayer = validationContext.ObjectInstance as NodeLayer;

            if (nodeLayer.Layer < 1 || nodeLayer.Layer > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"), new[] { "Layer" }));
            }

            if (nodeLayer.Z < -10000 || nodeLayer.Z > 10000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-10000", "10000"), new[] { "Z" }));
            }

                //CSSPError: Type not implemented [Node] of type [Node]

                //CSSPError: Type not implemented [Node] of type [Node]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
