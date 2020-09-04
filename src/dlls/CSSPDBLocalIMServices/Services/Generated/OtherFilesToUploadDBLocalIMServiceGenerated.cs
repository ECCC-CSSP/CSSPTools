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
    public interface IOtherFilesToUploadService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class OtherFilesToUploadService : IOtherFilesToUploadService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            OtherFilesToUpload otherFilesToUpload = validationContext.ObjectInstance as OtherFilesToUpload;

            if (otherFilesToUpload.MikeScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "MikeScenarioID", "1"), new[] { nameof(otherFilesToUpload.MikeScenarioID) });
            }

                //CSSPError: Type not implemented [TVFileList] of type [List`1]

                //CSSPError: Type not implemented [TVFileList] of type [TVFile]
            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
