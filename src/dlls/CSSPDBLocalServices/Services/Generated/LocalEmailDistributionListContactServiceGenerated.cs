/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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

namespace CSSPDBLocalServices
{
    public partial interface ILocalEmailDistributionListContactDBService
    {
        Task<ActionResult<bool>> Delete(int LocalEmailDistributionListContactID);
        Task<ActionResult<List<LocalEmailDistributionListContact>>> GetLocalEmailDistributionListContactList(int skip = 0, int take = 100);
        Task<ActionResult<LocalEmailDistributionListContact>> GetLocalEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID);
        Task<ActionResult<LocalEmailDistributionListContact>> Post(LocalEmailDistributionListContact localemaildistributionlistcontact);
        Task<ActionResult<LocalEmailDistributionListContact>> Put(LocalEmailDistributionListContact localemaildistributionlistcontact);
    }
    public partial class LocalEmailDistributionListContactDBService : ControllerBase, ILocalEmailDistributionListContactDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalEmailDistributionListContactDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalEmailDistributionListContact>> GetLocalEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalEmailDistributionListContact localEmailDistributionListContact = (from c in db.LocalEmailDistributionListContacts.AsNoTracking()
                    where c.EmailDistributionListContactID == EmailDistributionListContactID
                    select c).FirstOrDefault();

            if (localEmailDistributionListContact == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localEmailDistributionListContact));
        }
        public async Task<ActionResult<List<LocalEmailDistributionListContact>>> GetLocalEmailDistributionListContactList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalEmailDistributionListContact> localEmailDistributionListContactList = (from c in db.LocalEmailDistributionListContacts.AsNoTracking() orderby c.EmailDistributionListContactID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localEmailDistributionListContactList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalEmailDistributionListContactID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalEmailDistributionListContact localEmailDistributionListContact = (from c in db.LocalEmailDistributionListContacts
                    where c.EmailDistributionListContactID == LocalEmailDistributionListContactID
                    select c).FirstOrDefault();

            if (localEmailDistributionListContact == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalEmailDistributionListContact", "LocalEmailDistributionListContactID", LocalEmailDistributionListContactID.ToString())));
            }

            try
            {
                db.LocalEmailDistributionListContacts.Remove(localEmailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalEmailDistributionListContact>> Post(LocalEmailDistributionListContact localEmailDistributionListContact)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localEmailDistributionListContact), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalEmailDistributionListContacts.Add(localEmailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localEmailDistributionListContact));
        }
        public async Task<ActionResult<LocalEmailDistributionListContact>> Put(LocalEmailDistributionListContact localEmailDistributionListContact)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localEmailDistributionListContact), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalEmailDistributionListContacts.Update(localEmailDistributionListContact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localEmailDistributionListContact));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalEmailDistributionListContact localEmailDistributionListContact = validationContext.ObjectInstance as LocalEmailDistributionListContact;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localEmailDistributionListContact.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localEmailDistributionListContact.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localEmailDistributionListContact.EmailDistributionListContactID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListContactID"), new[] { nameof(localEmailDistributionListContact.EmailDistributionListContactID) });
                }

                if (!(from c in db.LocalEmailDistributionListContacts.AsNoTracking() select c).Where(c => c.EmailDistributionListContactID == localEmailDistributionListContact.EmailDistributionListContactID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", localEmailDistributionListContact.EmailDistributionListContactID.ToString()), new[] { nameof(localEmailDistributionListContact.EmailDistributionListContactID) });
                }
            }

            LocalEmailDistributionList localEmailDistributionListEmailDistributionListID = null;
            localEmailDistributionListEmailDistributionListID = (from c in db.LocalEmailDistributionLists.AsNoTracking() where c.EmailDistributionListID == localEmailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();

            if (localEmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalEmailDistributionList", "EmailDistributionListID", localEmailDistributionListContact.EmailDistributionListID.ToString()), new[] { nameof(localEmailDistributionListContact.EmailDistributionListID) });
            }

            if (string.IsNullOrWhiteSpace(localEmailDistributionListContact.Name))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { nameof(localEmailDistributionListContact.Name) });
            }

            if (!string.IsNullOrWhiteSpace(localEmailDistributionListContact.Name) && localEmailDistributionListContact.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Name", "100"), new[] { nameof(localEmailDistributionListContact.Name) });
            }

            if (string.IsNullOrWhiteSpace(localEmailDistributionListContact.Email))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Email"), new[] { nameof(localEmailDistributionListContact.Email) });
            }

            if (!string.IsNullOrWhiteSpace(localEmailDistributionListContact.Email) && localEmailDistributionListContact.Email.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Email", "200"), new[] { nameof(localEmailDistributionListContact.Email) });
            }

            if (!string.IsNullOrWhiteSpace(localEmailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(localEmailDistributionListContact.Email))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, "Email"), new[] { nameof(localEmailDistributionListContact.Email) });
                }
            }

            if (localEmailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localEmailDistributionListContact.LastUpdateDate_UTC) });
            }
            else
            {
                if (localEmailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localEmailDistributionListContact.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localEmailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localEmailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { nameof(localEmailDistributionListContact.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localEmailDistributionListContact.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}