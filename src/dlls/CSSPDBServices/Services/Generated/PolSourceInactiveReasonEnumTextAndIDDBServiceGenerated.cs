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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public interface IPolSourceInactiveReasonEnumTextAndIDService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class PolSourceInactiveReasonEnumTextAndIDService : IPolSourceInactiveReasonEnumTextAndIDService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = validationContext.ObjectInstance as PolSourceInactiveReasonEnumTextAndID;

            if (string.IsNullOrWhiteSpace(polSourceInactiveReasonEnumTextAndID.Text))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Text"), new[] { nameof(polSourceInactiveReasonEnumTextAndID.Text) });
            }

            //Text has no StringLength Attribute

            if (polSourceInactiveReasonEnumTextAndID.ID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"), new[] { nameof(polSourceInactiveReasonEnumTextAndID.ID) });
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