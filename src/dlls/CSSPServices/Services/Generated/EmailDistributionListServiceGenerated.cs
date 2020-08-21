/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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

namespace CSSPServices
{
   public partial interface IEmailDistributionListService
    {
       Task<ActionResult<bool>> Delete(int EmailDistributionListID);
       Task<ActionResult<List<EmailDistributionList>>> GetEmailDistributionListList(int skip = 0, int take = 100);
       Task<ActionResult<EmailDistributionList>> GetEmailDistributionListWithEmailDistributionListID(int EmailDistributionListID);
       Task<ActionResult<EmailDistributionList>> Post(EmailDistributionList emaildistributionlist);
       Task<ActionResult<EmailDistributionList>> Put(EmailDistributionList emaildistributionlist);
    }
    public partial class EmailDistributionListService : ControllerBase, IEmailDistributionListService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, 
           CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<EmailDistributionList>> GetEmailDistributionListWithEmailDistributionListID(int EmailDistributionListID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                EmailDistributionList emailDistributionList = (from c in dbIM.EmailDistributionLists.AsNoTracking()
                                   where c.EmailDistributionListID == EmailDistributionListID
                                   select c).FirstOrDefault();

                if (emailDistributionList == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                EmailDistributionList emailDistributionList = (from c in dbLocal.EmailDistributionLists.AsNoTracking()
                        where c.EmailDistributionListID == EmailDistributionListID
                        select c).FirstOrDefault();

                if (emailDistributionList == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
            else
            {
                EmailDistributionList emailDistributionList = (from c in db.EmailDistributionLists.AsNoTracking()
                        where c.EmailDistributionListID == EmailDistributionListID
                        select c).FirstOrDefault();

                if (emailDistributionList == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
        }
        public async Task<ActionResult<List<EmailDistributionList>>> GetEmailDistributionListList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<EmailDistributionList> emailDistributionListList = (from c in dbIM.EmailDistributionLists.AsNoTracking() orderby c.EmailDistributionListID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(emailDistributionListList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<EmailDistributionList> emailDistributionListList = (from c in dbLocal.EmailDistributionLists.AsNoTracking() orderby c.EmailDistributionListID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailDistributionListList));
            }
            else
            {
                List<EmailDistributionList> emailDistributionListList = (from c in db.EmailDistributionLists.AsNoTracking() orderby c.EmailDistributionListID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(emailDistributionListList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                EmailDistributionList emailDistributionList = (from c in dbIM.EmailDistributionLists
                                   where c.EmailDistributionListID == EmailDistributionListID
                                   select c).FirstOrDefault();
            
                if (emailDistributionList == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", EmailDistributionListID.ToString())));
                }
            
                try
                {
                    dbIM.EmailDistributionLists.Remove(emailDistributionList);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                EmailDistributionList emailDistributionList = (from c in dbLocal.EmailDistributionLists
                                   where c.EmailDistributionListID == EmailDistributionListID
                                   select c).FirstOrDefault();
                
                if (emailDistributionList == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", EmailDistributionListID.ToString())));
                }

                try
                {
                   dbLocal.EmailDistributionLists.Remove(emailDistributionList);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                EmailDistributionList emailDistributionList = (from c in db.EmailDistributionLists
                                   where c.EmailDistributionListID == EmailDistributionListID
                                   select c).FirstOrDefault();
                
                if (emailDistributionList == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", EmailDistributionListID.ToString())));
                }

                try
                {
                   db.EmailDistributionLists.Remove(emailDistributionList);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<EmailDistributionList>> Post(EmailDistributionList emailDistributionList)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.EmailDistributionLists.Add(emailDistributionList);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.EmailDistributionLists.Add(emailDistributionList);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
            else
            {
                try
                {
                   db.EmailDistributionLists.Add(emailDistributionList);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
        }
        public async Task<ActionResult<EmailDistributionList>> Put(EmailDistributionList emailDistributionList)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.EmailDistributionLists.Update(emailDistributionList);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(emailDistributionList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.EmailDistributionLists.Update(emailDistributionList);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionList));
            }
            else
            {
            try
            {
               db.EmailDistributionLists.Update(emailDistributionList);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(emailDistributionList));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            EmailDistributionList emailDistributionList = validationContext.ObjectInstance as EmailDistributionList;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionList.EmailDistributionListID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EmailDistributionListID"), new[] { nameof(emailDistributionList.EmailDistributionListID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), new[] { nameof(emailDistributionList.EmailDistributionListID) });
                    }
                }
                else
                {
                    if (!(from c in db.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), new[] { nameof(emailDistributionList.EmailDistributionListID) });
                    }
                }
            }

            TVItem TVItemParentTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemParentTVItemID = (from c in dbLocal.TVItems where c.TVItemID == emailDistributionList.ParentTVItemID select c).FirstOrDefault();
                if (TVItemParentTVItemID == null)
                {
                    TVItemParentTVItemID = (from c in dbIM.TVItems where c.TVItemID == emailDistributionList.ParentTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemParentTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.ParentTVItemID select c).FirstOrDefault();
            }

            if (TVItemParentTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentTVItemID", emailDistributionList.ParentTVItemID.ToString()), new[] { nameof(emailDistributionList.ParentTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemParentTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentTVItemID", "Country"), new[] { nameof(emailDistributionList.ParentTVItemID) });
                }
            }

            if (emailDistributionList.Ordinal < 0 || emailDistributionList.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(emailDistributionList.Ordinal) });
            }

            if (emailDistributionList.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(emailDistributionList.LastUpdateDate_UTC) });
            }
            else
            {
                if (emailDistributionList.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(emailDistributionList.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionList.LastUpdateContactTVItemID.ToString()), new[] { nameof(emailDistributionList.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(emailDistributionList.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
