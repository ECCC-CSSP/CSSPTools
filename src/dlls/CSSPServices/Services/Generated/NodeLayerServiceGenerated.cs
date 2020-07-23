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
    public interface INodeLayerService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class NodeLayerService : INodeLayerService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public NodeLayerService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            NodeLayer nodeLayer = validationContext.ObjectInstance as NodeLayer;

            if (nodeLayer.Layer < 1 || nodeLayer.Layer > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Layer", "1", "100"), new[] { nameof(nodeLayer.Layer) });
            }

            //Z has no Range Attribute

                //CSSPError: Type not implemented [Node] of type [Node]

                //CSSPError: Type not implemented [Node] of type [Node]
            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions public

    }
}
