/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPHelperServices.exe
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

namespace CSSPDBServices
{
    public interface ISearchResultService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class SearchResultService : ISearchResultService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public SearchResultService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            SearchResult searchResult = validationContext.ObjectInstance as SearchResult;

                //CSSPError: Type not implemented [TVItem] of type [TVItem]

                //CSSPError: Type not implemented [TVItem] of type [TVItem]
                //CSSPError: Type not implemented [TVItemLanguage] of type [TVItemLanguage]

                //CSSPError: Type not implemented [TVItemLanguage] of type [TVItemLanguage]
            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}