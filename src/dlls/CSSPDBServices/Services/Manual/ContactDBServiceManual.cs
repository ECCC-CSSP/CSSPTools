/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using System.Transactions;
using System.Runtime.InteropServices;
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface IContactDBService
    {
        //Task<ActionResult<bool>> RemoveContact(string LoginEmail);
    }

    public partial class ContactDBService : ControllerBase, IContactDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        //public async Task<ActionResult<Contact>> Register(RegisterModel registerModel)
        //{
        //    ValidationResults = RegisterModelService.Validate(new ValidationContext(registerModel));
        //    if (ValidationResults.Count() > 0)
        //    {
        //        return await Task.FromResult(BadRequest(ValidationResults));
        //    }

        //    ValidationResults = ValidateContact(new ValidationContext(registerModel));
        //    if (ValidationResults.Count() > 0)
        //    {
        //        return await Task.FromResult(BadRequest(ValidationResults));
        //    }

        //    string passwordHash = await ScrambleService.Scramble(registerModel.Password);
        //    string password = await ScrambleService.Descramble(passwordHash);

        //    if (password != registerModel.Password)
        //    {
        //        return await Task.FromResult(BadRequest(CSSPCultureServicesRes.ErrorParsingPassword));
        //    }

        //    Contact contactNew = new Contact()
        //    {
        //        ContactTVItemID = 1, // will change later

        //        DBCommand = DBCommandEnum.Original,
        //        LoginEmail = registerModel.LoginEmail,
        //        FirstName = registerModel.FirstName,
        //        Initial = registerModel.Initial,
        //        LastName = registerModel.LastName,
        //        ContactTitle = registerModel.ContactTitle,
        //        WebName = "Will change later",
        //        IsAdmin = false,
        //        IsNew = true,
        //        SamplingPlanner_ProvincesTVItemID = "",
        //        EmailValidated = false,
        //        Disabled = false,
        //        PasswordHash = passwordHash,
        //        LastUpdateContactTVItemID = 1, // will change later
        //        LastUpdateDate_UTC = DateTime.UtcNow,
        //        Token = "",
        //    };

        //    try
        //    {
        //        await db.Contacts.AddAsync(contactNew);
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message)));
        //    }

        //    TVItem tvItemRoot = await (from c in db.TVItems.AsNoTracking()
        //                               where c.TVLevel == 0
        //                               select c).FirstOrDefaultAsync();

        //    if (tvItemRoot == null)
        //    {
        //        return await Task.FromResult(BadRequest(CSSPCultureServicesRes.CouldNotFindRoot));
        //    }

        //    TVItem tvItemContactNew = new TVItem()
        //    {
        //        IsActive = true,
        //        LastUpdateContactTVItemID = 0, // will be changed later to the ContactTVItemID
        //        LastUpdateDate_UTC = DateTime.UtcNow,
        //        ParentID = tvItemRoot.TVItemID,
        //        TVLevel = tvItemRoot.TVLevel + 1,
        //        TVPath = "Will be changed",
        //        TVType = TVTypeEnum.Contact,
        //    };

        //    try
        //    {
        //        await db.TVItems.AddAsync(tvItemContactNew);
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message)));
        //    }

        //    tvItemContactNew.LastUpdateContactTVItemID = tvItemContactNew.TVItemID;
        //    tvItemContactNew.TVPath = tvItemRoot.TVPath + "p" + tvItemContactNew.TVItemID;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message)));
        //    }

        //    string TVText = registerModel.LastName + ", " + registerModel.FirstName + (string.IsNullOrWhiteSpace(registerModel.Initial) ? "" : " " + registerModel.Initial + ".");

        //    foreach (LanguageEnum languageEnum in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
        //    {
        //        TVItemLanguage tvItemLanguage = new TVItemLanguage()
        //        {
        //            Language = languageEnum,
        //            LastUpdateContactTVItemID = 0,
        //            LastUpdateDate_UTC = DateTime.UtcNow,
        //            TranslationStatus = TranslationStatusEnum.Translated,
        //            TVItemID = tvItemContactNew.TVItemID,
        //            TVText = TVText,
        //        };

        //        try
        //        {
        //            await db.TVItemLanguages.AddAsync(tvItemLanguage);
        //            await db.SaveChangesAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message)));
        //        }
        //    }

        //    // Adding more info in Contacts table
        //    contactNew.ContactTVItemID = tvItemContactNew.TVItemID;
        //    contactNew.WebName = TVText;
        //    contactNew.LastUpdateContactTVItemID = tvItemContactNew.TVItemID;
        //    contactNew.LastUpdateDate_UTC = DateTime.UtcNow;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotUpdate_Error_, "Contact", ex.Message)));
        //    }

        //    TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization()
        //    {
        //        ContactTVItemID = tvItemContactNew.TVItemID,
        //        TVType = TVTypeEnum.Root,
        //        TVAuth = TVAuthEnum.NoAccess,
        //        LastUpdateDate_UTC = DateTime.UtcNow,
        //        LastUpdateContactTVItemID = contactNew.ContactTVItemID,
        //    };

        //    try
        //    {
        //        await db.TVTypeUserAuthorizations.AddAsync(tvTypeUserAuthorizationNew);
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message)));
        //    }

        //    var actionLoginRet = await Login(new LoginModel() { LoginEmail = registerModel.LoginEmail, Password = registerModel.Password });
        //    if (((ObjectResult)actionLoginRet.Result).StatusCode != 200)
        //    {
        //        return await Task.FromResult(BadRequest(CSSPCultureServicesRes.CouldNotLogin));
        //    }

        //    Contact contact = (Contact)((OkObjectResult)actionLoginRet.Result).Value;

        //    await LoggedInService.SetLoggedInContactInfo(contact.LoginEmail);

        //    return await Task.FromResult(Ok(contact));
        //}
        //public async Task<ActionResult<bool>> RemoveContact(string LoginEmail)
        //{
        //    if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    using (var beginTransaction = db.Database.BeginTransaction())
        //    {
        //        int TVItemID = 0;

        //        Contact contact = (from c in db.Contacts
        //                           where c.LoginEmail == LoginEmail
        //                           select c).FirstOrDefault();

        //        if (contact != null)
        //        {
        //            TVItemID = contact.ContactTVItemID;

        //            try
        //            {
        //                db.Contacts.Remove(contact);
        //                db.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Contacts", ex.Message)));
        //            }

        //        }

        //        TVItem tvItem = (from c in db.TVItems
        //                         where c.TVItemID == TVItemID
        //                         select c).FirstOrDefault();

        //        if (tvItem != null)
        //        {
        //            try
        //            {
        //                db.TVItems.Remove(tvItem);
        //                db.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItem", ex.Message)));
        //            }
        //        }

        //        await beginTransaction.CommitAsync();
        //    }

        //    return await Task.FromResult(Ok(true));
        //}
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
                 where c.LoginEmail == registerModel.LoginEmail.Trim()
                 select c).Any())
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._HasToBeUnique, "LoginEmail"), new[] { nameof(registerModel.LoginEmail) });
            }
        }
        #endregion Functions private

    }
}
