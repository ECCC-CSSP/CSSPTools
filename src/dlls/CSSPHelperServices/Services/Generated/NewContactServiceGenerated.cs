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
    public interface INewContactService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class NewContactService : INewContactService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public NewContactService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            string retStr = "";
            NewContact newContact = validationContext.ObjectInstance as NewContact;

            if (string.IsNullOrWhiteSpace(newContact.LoginEmail))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"), new[] { "LoginEmail" }));
            }

            if (!string.IsNullOrWhiteSpace(newContact.LoginEmail) && (newContact.LoginEmail.Length < 1 || newContact.LoginEmail.Length > 200))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "1", "200"), new[] { "LoginEmail" }));
            }

            if (string.IsNullOrWhiteSpace(newContact.FirstName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FirstName"), new[] { "FirstName" }));
            }

            if (!string.IsNullOrWhiteSpace(newContact.FirstName) && (newContact.FirstName.Length < 1 || newContact.FirstName.Length > 200))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "200"), new[] { "FirstName" }));
            }

            if (string.IsNullOrWhiteSpace(newContact.LastName))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastName"), new[] { "LastName" }));
            }

            if (!string.IsNullOrWhiteSpace(newContact.LastName) && (newContact.LastName.Length < 1 || newContact.LastName.Length > 200))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "200"), new[] { "LastName" }));
            }

            if (!string.IsNullOrWhiteSpace(newContact.Initial) && newContact.Initial.Length > 50)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Initial", "50"), new[] { "Initial" }));
            }

            if (newContact.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)newContact.ContactTitle);
                if (newContact.ContactTitle == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ContactTitle"), new[] { "ContactTitle" }));
                }
            }

            if (!string.IsNullOrWhiteSpace(newContact.ContactTitleText) && newContact.ContactTitleText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ContactTitleText", "100"), new[] { "ContactTitleText" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
