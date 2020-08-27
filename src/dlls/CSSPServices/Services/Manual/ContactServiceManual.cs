/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial interface IContactService
    {
    }

    public partial class ContactService : ControllerBase, IContactService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        {
            if (LoggedInService.RunningOn != RunningOnEnum.Azure)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnAzure, "Register")));
            }

            ValidationResults = RegisterModelService.Validate(new ValidationContext(registerModel));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            ValidationResults = ValidateContact(new ValidationContext(registerModel));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            var user = new ApplicationUser { UserName = registerModel.LoginEmail, Email = registerModel.LoginEmail };
            var result = await UserManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded == false)
            {
                return BadRequest(result.Errors);
            }

            // Adding more info in Contacts table
            Contact contactNew = new Contact()
            {
                Id = user.Id,
                LoginEmail = registerModel.LoginEmail,
                FirstName = registerModel.FirstName,
                Initial = registerModel.Initial,
                LastName = registerModel.LastName,
                //etc...

            };

            // everything when ok, i.e. new user was properly registered
            // now we should add the information to the CSSPDBLogin database
            // AspNetUsers, Contacts, TVItemUserAuthorization, TVTypeUserAuthorization


            return await Task.FromResult(Ok(true));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> ValidateContact(ValidationContext validationContext)
        {
            RegisterModel registerModel = validationContext.ObjectInstance as RegisterModel;

            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                yield return new ValidationResult(CSSPCultureServicesRes.PasswordAndConfirmPasswordNotIdentical, new[] { nameof(registerModel.Password), nameof(registerModel.ConfirmPassword) });
            }

            if (string.IsNullOrWhiteSpace(registerModel.Initial))
            {
                if ((from c in db.Contacts.AsNoTracking()
                     where c.FirstName == registerModel.FirstName.Trim()
                     && c.LastName == registerModel.LastName.Trim()
                     select c).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.FullName_IsAlreadyTaken, $"{registerModel.FirstName} {registerModel.LastName}"), new[] { nameof(registerModel.FirstName), nameof(registerModel.Initial), nameof(registerModel.LastName) });
                }
            }
            else
            {
                if ((from c in db.Contacts.AsNoTracking()
                     where c.FirstName == registerModel.FirstName.Trim()
                     && c.Initial == registerModel.Initial.Trim()
                     && c.LastName == registerModel.LastName.Trim()
                     select c).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.FullName_IsAlreadyTaken, $"{registerModel.FirstName} {registerModel.Initial}, {registerModel.LastName}"), new[] { nameof(registerModel.FirstName), nameof(registerModel.Initial), nameof(registerModel.LastName) });
                }
            }

            if ((from c in db.Contacts
                 from a in db.AspNetUsers
                 where c.Id == a.Id
                 && a.Email == registerModel.LoginEmail.Trim()
                 select c).Any())
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._HasToBeUnique, "LoginEmail"), new[] { nameof(registerModel.LoginEmail) });
            }
        }
        #endregion Functions private

    }
}
