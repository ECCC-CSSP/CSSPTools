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
    public interface IPolSourceObsInfoChildService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class PolSourceObsInfoChildService : IPolSourceObsInfoChildService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            PolSourceObsInfoChild polSourceObsInfoChild = validationContext.ObjectInstance as PolSourceObsInfoChild;

            retStr = enums.EnumTypeOK(typeof(PolSourceObsInfoEnum), (int?)polSourceObsInfoChild.PolSourceObsInfo);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObsInfo"), new[] { "PolSourceObsInfo" });
            }

            retStr = enums.EnumTypeOK(typeof(PolSourceObsInfoEnum), (int?)polSourceObsInfoChild.PolSourceObsInfoChildStart);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObsInfoChildStart"), new[] { "PolSourceObsInfoChildStart" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChild.PolSourceObsInfoText) && polSourceObsInfoChild.PolSourceObsInfoText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceObsInfoText", "100"), new[] { "PolSourceObsInfoText" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChild.PolSourceObsInfoChildStartText) && polSourceObsInfoChild.PolSourceObsInfoChildStartText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PolSourceObsInfoChildStartText", "100"), new[] { "PolSourceObsInfoChildStartText" });
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
