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
    public interface IDBTableService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class DBTableService : IDBTableService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DBTableService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            DBTable dBTable = validationContext.ObjectInstance as DBTable;

            if (string.IsNullOrWhiteSpace(dBTable.TableName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TableName"), new[] { "TableName" }));
            }

            if (!string.IsNullOrWhiteSpace(dBTable.TableName) && (dBTable.TableName.Length < 1 || dBTable.TableName.Length > 200))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "TableName", "1", "200"), new[] { "TableName" }));
            }

            if (string.IsNullOrWhiteSpace(dBTable.Plurial))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Plurial"), new[] { "Plurial" }));
            }

            if (!string.IsNullOrWhiteSpace(dBTable.Plurial) && (dBTable.Plurial.Length < 1 || dBTable.Plurial.Length > 3))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Plurial", "1", "3"), new[] { "Plurial" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
