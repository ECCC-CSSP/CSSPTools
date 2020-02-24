using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour AspNetUser</para>
    /// </summary>
    public partial class AspNetUserService : BaseService
    {
        #region Variables
        public UserManager<ApplicationUser> _UserManager { get; private set; }
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AspNetUserService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        //{
        //    string retStr = "";
        //    Enums enums = new Enums(LanguageRequest);
        //    AspNetUser aspNetUser = validationContext.ObjectInstance as AspNetUser;
        //    aspNetUser.HasErrors = false;

        //    //if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
        //    //{
        //    //    if (aspNetUser.Id == "")
        //    //    {
        //    //        aspNetUser.HasErrors = true;
        //    //        yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserId), new[] { "Id" });
        //    //    }

        //    //    if (!(from c in db.AspNetUsers select c).Where(c => c.Id == aspNetUser.Id).Any())
        //    //    {
        //    //        aspNetUser.HasErrors = true;
        //    //        yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AspNetUser, CSSPModelsRes.AspNetUserId, (aspNetUser.Id == null ? "" : aspNetUser.Id.ToString())), new[] { "Id" });
        //    //    }
        //    //}

        //    //if (!string.IsNullOrWhiteSpace(aspNetUser.Email) && aspNetUser.Email.Length > 256)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserEmail, "256"), new[] { "Email" });
        //    //}

        //    //if (!string.IsNullOrWhiteSpace(aspNetUser.PasswordHash) && aspNetUser.PasswordHash.Length > 256)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPasswordHash, "256"), new[] { "PasswordHash" });
        //    //}

        //    //if (!string.IsNullOrWhiteSpace(aspNetUser.SecurityStamp) && aspNetUser.SecurityStamp.Length > 256)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserSecurityStamp, "256"), new[] { "SecurityStamp" });
        //    //}

        //    //if (!string.IsNullOrWhiteSpace(aspNetUser.PhoneNumber) && aspNetUser.PhoneNumber.Length > 256)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPhoneNumber, "256"), new[] { "PhoneNumber" });
        //    //}

        //    //if (aspNetUser.LockoutEndDateUtc != null && ((DateTime)aspNetUser.LockoutEndDateUtc).Year < 1980)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AspNetUserLockoutEndDateUtc, "1980"), new[] { CSSPModelsRes.AspNetUserLockoutEndDateUtc });
        //    //}

        //    //if (aspNetUser.AccessFailedCount < 0 || aspNetUser.AccessFailedCount > 10000)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AspNetUserAccessFailedCount, "0", "10000"), new[] { "AccessFailedCount" });
        //    //}

        //    //if (string.IsNullOrWhiteSpace(aspNetUser.UserName))
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserUserName), new[] { "UserName" });
        //    //}

        //    //if (!string.IsNullOrWhiteSpace(aspNetUser.UserName) && aspNetUser.UserName.Length > 256)
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserUserName, "256"), new[] { "UserName" });
        //    //}

        //    //retStr = ""; // added to stop compiling error
        //    //if (retStr != "") // will never be true
        //    //{
        //    //    aspNetUser.HasErrors = true;
        //    //    yield return new ValidationResult("AAA", new[] { "AAA" });
        //    //}

        //}
        #endregion Validation

        #region Functions public Generated Get
        public AspNetUser GetAspNetUserWithAspNetUserID(string Id)
        {
            return (from c in db.AspNetUsers
                    where c.Id == Id
                    select c).FirstOrDefault();
        }
        public IQueryable<AspNetUser> GetAspNetUserList()
        {
            IQueryable<AspNetUser> AspNetUserQuery = (from c in db.AspNetUsers select c);

            //AspNetUserQuery = EnhanceQueryStatements<AspNetUser>(AspNetUserQuery) as IQueryable<AspNetUser>;

            return AspNetUserQuery;
        }
        public AspNetUser Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            AspNetUser aspNetUser = (from c in db.AspNetUsers
                                     where c.UserName == username
                                     select c).FirstOrDefault();

            // check if username exists
            if (aspNetUser == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, aspNetUser.PasswordHash, aspNetUser.SecurityStamp))
                return null;

            // authentication successful
            return aspNetUser;
        }
        public AspNetUser Create(AspNetUser aspNetUser, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes._IsRequired, "Password"), new[] { "Password" }) }
                };
            }

            bool AspNetUserAlreadyExist = (from c in db.AspNetUsers
                                           where c.UserName == aspNetUser.UserName
                                           select c).Any();
            if (AspNetUserAlreadyExist)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes._AlreadyExists, "Email"), new[] { "Email" }) }
                };
            }

            string passwordHash;
            string securityStamp;
            CreatePasswordHash(password, out passwordHash, out securityStamp);

            aspNetUser.PasswordHash = passwordHash;
            aspNetUser.SecurityStamp = securityStamp;

            db.AspNetUsers.Add(aspNetUser);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes.CouldNot_Error_, CSSPServicesRes.Create, ex.Message), new[] { "Email" }) }
                };
            }

            return aspNetUser;
        }

        public AspNetUser Update(AspNetUser aspNetUser, string password = null)
        {
            AspNetUser aspNetUserToChange = (from c in db.AspNetUsers
                                             where c.Id == aspNetUser.Id
                                             select c).FirstOrDefault();

            if (aspNetUserToChange == null)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes._DoesNotExist, "AspNetUser"), new[] { "Id" }) }
                };
            }

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(aspNetUserToChange.UserName) && aspNetUserToChange.UserName != aspNetUserToChange.UserName)
            {
                bool AspNetUserAlreadyExist = (from c in db.AspNetUsers
                                               where c.UserName == aspNetUserToChange.UserName
                                               select c).Any();
                if (AspNetUserAlreadyExist)
                {
                    return new AspNetUser()
                    {
                        HasErrors = true,
                        ValidationResults = new List<ValidationResult>() {
                        new ValidationResult(String.Format(CSSPServicesRes._AlreadyExists, "Email"), new[] { "Email" }) }
                    };
                }
            }

            // should use the ContactService to change the FirstName, LastName, Initial, Tel, etc...

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                string passwordHash;
                string securityStamp;
                CreatePasswordHash(password, out passwordHash, out securityStamp);

                aspNetUserToChange.PasswordHash = passwordHash;
                aspNetUserToChange.SecurityStamp = securityStamp;
            }

            db.AspNetUsers.Update(aspNetUserToChange);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes.CouldNot_Error_, CSSPServicesRes.Update, ex.Message), new[] { "AspNetUser" }) }
                };
            }

            return aspNetUserToChange;
        }

        public AspNetUser Delete(string Id)
        {
            AspNetUser aspNetUserToDelete = (from c in db.AspNetUsers
                                             where c.Id == Id
                                             select c).FirstOrDefault();

            if (aspNetUserToDelete == null)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes._DoesNotExist, "AspNetUser"), new[] { "Id" }) }
                };
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new AspNetUser()
                {
                    HasErrors = true,
                    ValidationResults = new List<ValidationResult>() {
                    new ValidationResult(String.Format(CSSPServicesRes.CouldNot_Error_, CSSPServicesRes.Delete, ex.Message), new[] { "AspNetUser" }) }
                };
            }

            return new AspNetUser();
        }
        #endregion Functions public Generated Get

        #region Functions private Generated TryToSave


        // private helper methods

        private void CreatePasswordHash(string password, out string passwordHash, out string securityStamp)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA256())
            {
                securityStamp = Encoding.UTF8.GetString(hmac.Key);
                passwordHash = Encoding.UTF8.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash, string securityStamp)
        {

            AspNetUser aspNetUser = (from c in db.AspNetUsers
                                     where c.UserName == "Charles.LeBlanc2@Canada.ca"
                                     select c).FirstOrDefault();

            if (aspNetUser == null)
            {
                return false;
            }

            int passwordHashLength = aspNetUser.PasswordHash.Length;
            int securityStampLength = aspNetUser.SecurityStamp.Length;

            var a = System.Security.Cryptography.SHA1.Create(password);


            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (securityStamp.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(securityStamp)))
            {
                string computedHash = Encoding.UTF8.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private bool TryToSave(AspNetUser aspNetUser)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string password)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateAsync(this, password);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}