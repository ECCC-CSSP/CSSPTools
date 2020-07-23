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
   public partial interface IPolSourceObservationIssueService
    {
       Task<ActionResult<bool>> Delete(int PolSourceObservationIssueID);
       Task<ActionResult<List<PolSourceObservationIssue>>> GetPolSourceObservationIssueList(int skip = 0, int take = 100);
       Task<ActionResult<PolSourceObservationIssue>> GetPolSourceObservationIssueWithPolSourceObservationIssueID(int PolSourceObservationIssueID);
       Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue polsourceobservationissue);
       Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue polsourceobservationissue);
    }
    public partial class PolSourceObservationIssueService : ControllerBase, IPolSourceObservationIssueService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<PolSourceObservationIssue>> GetPolSourceObservationIssueWithPolSourceObservationIssueID(int PolSourceObservationIssueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceObservationIssue polSourceObservationIssue = (from c in dbIM.PolSourceObservationIssues.AsNoTracking()
                                   where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                   select c).FirstOrDefault();

                if (polSourceObservationIssue == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceObservationIssue polSourceObservationIssue = (from c in dbLocal.PolSourceObservationIssues.AsNoTracking()
                        where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                        select c).FirstOrDefault();

                if (polSourceObservationIssue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else
            {
                PolSourceObservationIssue polSourceObservationIssue = (from c in db.PolSourceObservationIssues.AsNoTracking()
                        where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                        select c).FirstOrDefault();

                if (polSourceObservationIssue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
        }
        public async Task<ActionResult<List<PolSourceObservationIssue>>> GetPolSourceObservationIssueList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<PolSourceObservationIssue> polSourceObservationIssueList = (from c in dbIM.PolSourceObservationIssues.AsNoTracking() orderby c.PolSourceObservationIssueID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(polSourceObservationIssueList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<PolSourceObservationIssue> polSourceObservationIssueList = (from c in dbLocal.PolSourceObservationIssues.AsNoTracking() orderby c.PolSourceObservationIssueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceObservationIssueList));
            }
            else
            {
                List<PolSourceObservationIssue> polSourceObservationIssueList = (from c in db.PolSourceObservationIssues.AsNoTracking() orderby c.PolSourceObservationIssueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(polSourceObservationIssueList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationIssueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                PolSourceObservationIssue polSourceObservationIssue = (from c in dbIM.PolSourceObservationIssues
                                   where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                   select c).FirstOrDefault();
            
                if (polSourceObservationIssue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", PolSourceObservationIssueID.ToString())));
                }
            
                try
                {
                    dbIM.PolSourceObservationIssues.Remove(polSourceObservationIssue);
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
                PolSourceObservationIssue polSourceObservationIssue = (from c in dbLocal.PolSourceObservationIssues
                                   where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                   select c).FirstOrDefault();
                
                if (polSourceObservationIssue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", PolSourceObservationIssueID.ToString())));
                }

                try
                {
                   dbLocal.PolSourceObservationIssues.Remove(polSourceObservationIssue);
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
                PolSourceObservationIssue polSourceObservationIssue = (from c in db.PolSourceObservationIssues
                                   where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                   select c).FirstOrDefault();
                
                if (polSourceObservationIssue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", PolSourceObservationIssueID.ToString())));
                }

                try
                {
                   db.PolSourceObservationIssues.Remove(polSourceObservationIssue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue polSourceObservationIssue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceObservationIssues.Add(polSourceObservationIssue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.PolSourceObservationIssues.Add(polSourceObservationIssue);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else
            {
                try
                {
                   db.PolSourceObservationIssues.Add(polSourceObservationIssue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
        }
        public async Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue polSourceObservationIssue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.PolSourceObservationIssues.Update(polSourceObservationIssue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.PolSourceObservationIssues.Update(polSourceObservationIssue);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservationIssue));
            }
            else
            {
            try
            {
               db.PolSourceObservationIssues.Update(polSourceObservationIssue);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservationIssue));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            PolSourceObservationIssue polSourceObservationIssue = validationContext.ObjectInstance as PolSourceObservationIssue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservationIssue.PolSourceObservationIssueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObservationIssueID"), new[] { nameof(polSourceObservationIssue.PolSourceObservationIssueID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString()), new[] { nameof(polSourceObservationIssue.PolSourceObservationIssueID) });
                    }
                }
                else
                {
                    if (!(from c in db.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString()), new[] { nameof(polSourceObservationIssue.PolSourceObservationIssueID) });
                    }
                }
            }

            PolSourceObservation PolSourceObservationPolSourceObservationID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                PolSourceObservationPolSourceObservationID = (from c in dbLocal.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();
                if (PolSourceObservationPolSourceObservationID == null)
                {
                    PolSourceObservationPolSourceObservationID = (from c in dbIM.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();
                }
            }
            else
            {
                PolSourceObservationPolSourceObservationID = (from c in db.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();
            }

            if (PolSourceObservationPolSourceObservationID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservationIssue.PolSourceObservationID.ToString()), new[] { nameof(polSourceObservationIssue.PolSourceObservationID) });
            }

            if (string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ObservationInfo"), new[] { nameof(polSourceObservationIssue.ObservationInfo) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo) && polSourceObservationIssue.ObservationInfo.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ObservationInfo", "250"), new[] { nameof(polSourceObservationIssue.ObservationInfo) });
            }

            if (polSourceObservationIssue.Ordinal < 0 || polSourceObservationIssue.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(polSourceObservationIssue.Ordinal) });
            }

            //ExtraComment has no StringLength Attribute

            if (polSourceObservationIssue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceObservationIssue.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceObservationIssue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceObservationIssue.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceObservationIssue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceObservationIssue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}