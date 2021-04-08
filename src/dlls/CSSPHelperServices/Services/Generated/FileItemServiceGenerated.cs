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
    public interface IFileItemService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class FileItemService : IFileItemService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            FileItem fileItem = validationContext.ObjectInstance as FileItem;

            if (string.IsNullOrWhiteSpace(fileItem.Name))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { "Name" }));
            }

            if (!string.IsNullOrWhiteSpace(fileItem.Name) && (fileItem.Name.Length < 1 || fileItem.Name.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Name", "1", "255"), new[] { "Name" }));
            }

            if (fileItem.TVItemID < 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"), new[] { "TVItemID" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
