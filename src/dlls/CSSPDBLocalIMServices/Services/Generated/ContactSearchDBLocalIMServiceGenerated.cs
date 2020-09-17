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
    public interface IContactSearchService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class ContactSearchService : IContactSearchService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public ContactSearchService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ContactSearch contactSearch = validationContext.ObjectInstance as ContactSearch;

            if (contactSearch.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ContactID", "1"), new[] { nameof(contactSearch.ContactID) });
            }

            if (contactSearch.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ContactTVItemID", "1"), new[] { nameof(contactSearch.ContactTVItemID) });
            }

            if (string.IsNullOrWhiteSpace(contactSearch.FullName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FullName"), new[] { nameof(contactSearch.FullName) });
            }

            if (!string.IsNullOrWhiteSpace(contactSearch.FullName) && contactSearch.FullName.Length > 255)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FullName", "255"), new[] { nameof(contactSearch.FullName) });
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