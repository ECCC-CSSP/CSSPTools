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
    public interface IPolSourceObsInfoEnumTextAndIDService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class PolSourceObsInfoEnumTextAndIDService : IPolSourceObsInfoEnumTextAndIDService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = validationContext.ObjectInstance as PolSourceObsInfoEnumTextAndID;

            if (string.IsNullOrWhiteSpace(polSourceObsInfoEnumTextAndID.Text))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { nameof(polSourceObsInfoEnumTextAndID.Text) });
            }

            //Text has no StringLength Attribute

            if (polSourceObsInfoEnumTextAndID.ID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"), new[] { nameof(polSourceObsInfoEnumTextAndID.ID) });
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
