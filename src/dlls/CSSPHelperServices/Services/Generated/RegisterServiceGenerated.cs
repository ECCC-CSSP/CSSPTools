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
    public interface IRegisterService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class RegisterService : IRegisterService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            Register register = validationContext.ObjectInstance as Register;

            if (string.IsNullOrWhiteSpace(register.LoginEmail))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), new[] { "LoginEmail" }));
            }

            if (!string.IsNullOrWhiteSpace(register.LoginEmail) && (register.LoginEmail.Length < 6 || register.LoginEmail.Length > 255))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "6", "255"), new[] { "LoginEmail" }));
            }

            if (string.IsNullOrWhiteSpace(register.FirstName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"), new[] { "FirstName" }));
            }

            if (!string.IsNullOrWhiteSpace(register.FirstName) && (register.FirstName.Length < 1 || register.FirstName.Length > 100))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "100"), new[] { "FirstName" }));
            }

            if (!string.IsNullOrWhiteSpace(register.Initial) && register.Initial.Length > 50)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "50"), new[] { "Initial" }));
            }

            if (string.IsNullOrWhiteSpace(register.LastName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"), new[] { "LastName" }));
            }

            if (!string.IsNullOrWhiteSpace(register.LastName) && (register.LastName.Length < 1 || register.LastName.Length > 100))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "100"), new[] { "LastName" }));
            }

            if (string.IsNullOrWhiteSpace(register.WebName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "WebName"), new[] { "WebName" }));
            }

            if (!string.IsNullOrWhiteSpace(register.WebName) && (register.WebName.Length < 1 || register.WebName.Length > 100))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "WebName", "1", "100"), new[] { "WebName" }));
            }

            if (string.IsNullOrWhiteSpace(register.Password))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Password"), new[] { "Password" }));
            }

            if (!string.IsNullOrWhiteSpace(register.Password) && (register.Password.Length < 6 || register.Password.Length > 100))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "6", "100"), new[] { "Password" }));
            }

            if (string.IsNullOrWhiteSpace(register.ConfirmPassword))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ConfirmPassword"), new[] { "ConfirmPassword" }));
            }

            if (!string.IsNullOrWhiteSpace(register.ConfirmPassword) && (register.ConfirmPassword.Length < 6 || register.ConfirmPassword.Length > 100))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ConfirmPassword", "6", "100"), new[] { "ConfirmPassword" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
