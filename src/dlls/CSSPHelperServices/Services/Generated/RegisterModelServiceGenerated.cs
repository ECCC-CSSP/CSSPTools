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
    public interface IRegisterModelService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class RegisterModelService : IRegisterModelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public RegisterModelService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            RegisterModel registerModel = validationContext.ObjectInstance as RegisterModel;

            if (string.IsNullOrWhiteSpace(registerModel.FirstName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.FirstName) && (registerModel.FirstName.Length < 1 || registerModel.FirstName.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "100"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.Initial) && registerModel.Initial.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "100"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(registerModel.LastName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.LastName) && (registerModel.LastName.Length < 1 || registerModel.LastName.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "100"), new[] { "LastName" });
            }

            if (string.IsNullOrWhiteSpace(registerModel.LoginEmail))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.LoginEmail) && (registerModel.LoginEmail.Length < 5 || registerModel.LoginEmail.Length > 100))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "5", "100"), new[] { "LoginEmail" });
            }

            if (string.IsNullOrWhiteSpace(registerModel.Password))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Password"), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.Password) && (registerModel.Password.Length < 5 || registerModel.Password.Length > 50))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "5", "50"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(registerModel.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ConfirmPassword"), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(registerModel.ConfirmPassword) && (registerModel.ConfirmPassword.Length < 5 || registerModel.ConfirmPassword.Length > 50))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "ConfirmPassword", "5", "50"), new[] { "ConfirmPassword" });
            }

            if (registerModel.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)registerModel.ContactTitle);
                if (registerModel.ContactTitle == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactTitle"), new[] { "ContactTitle" });
                }
            }

        }
        #endregion Functions public
    }

}
