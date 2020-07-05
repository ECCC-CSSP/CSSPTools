/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
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
   public interface IMikeBoundaryConditionService
    {
       Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID);
       Task<ActionResult<List<MikeBoundaryCondition>>> GetMikeBoundaryConditionList();
       Task<ActionResult<MikeBoundaryCondition>> GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID);
       Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeboundarycondition);
       Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeboundarycondition);
    }
    public partial class MikeBoundaryConditionService : ControllerBase, IMikeBoundaryConditionService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MikeBoundaryCondition>> GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                MikeBoundaryCondition mikeboundarycondition = (from c in dbLocal.MikeBoundaryConditions.AsNoTracking()
                        where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                        select c).FirstOrDefault();

                if (mikeboundarycondition == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeboundarycondition));
            }
            else
            {
                MikeBoundaryCondition mikeboundarycondition = (from c in db.MikeBoundaryConditions.AsNoTracking()
                        where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                        select c).FirstOrDefault();

                if (mikeboundarycondition == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mikeboundarycondition));
            }
        }
        public async Task<ActionResult<List<MikeBoundaryCondition>>> GetMikeBoundaryConditionList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<MikeBoundaryCondition> mikeboundaryconditionList = (from c in dbLocal.MikeBoundaryConditions.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(mikeboundaryconditionList));
            }
            else
            {
                List<MikeBoundaryCondition> mikeboundaryconditionList = (from c in db.MikeBoundaryConditions.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(mikeboundaryconditionList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                MikeBoundaryCondition mikeBoundaryCondition = (from c in dbLocal.MikeBoundaryConditions
                                   where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                   select c).FirstOrDefault();
                
                if (mikeBoundaryCondition == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", MikeBoundaryConditionID.ToString())));
                }

                try
                {
                   dbLocal.MikeBoundaryConditions.Remove(mikeBoundaryCondition);
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
                MikeBoundaryCondition mikeBoundaryCondition = (from c in db.MikeBoundaryConditions
                                   where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                   select c).FirstOrDefault();
                
                if (mikeBoundaryCondition == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", MikeBoundaryConditionID.ToString())));
                }

                try
                {
                   db.MikeBoundaryConditions.Remove(mikeBoundaryCondition);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeBoundaryCondition)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.MikeBoundaryConditions.Add(mikeBoundaryCondition);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeBoundaryCondition));
            }
            else
            {
                try
                {
                   db.MikeBoundaryConditions.Add(mikeBoundaryCondition);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mikeBoundaryCondition));
            }
        }
        public async Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeBoundaryCondition)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.MikeBoundaryConditions.Update(mikeBoundaryCondition);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeBoundaryCondition));
            }
            else
            {
            try
            {
               db.MikeBoundaryConditions.Update(mikeBoundaryCondition);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeBoundaryCondition));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeBoundaryCondition mikeBoundaryCondition = validationContext.ObjectInstance as MikeBoundaryCondition;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeBoundaryCondition.MikeBoundaryConditionID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MikeBoundaryConditionID"), new[] { "MikeBoundaryConditionID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), new[] { "MikeBoundaryConditionID" });
                    }
                }
                else
                {
                    if (!(from c in db.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), new[] { "MikeBoundaryConditionID" });
                    }
                }
            }

            TVItem TVItemMikeBoundaryConditionTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemMikeBoundaryConditionTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();
                if (TVItemMikeBoundaryConditionTVItemID == null)
                {
                    TVItemMikeBoundaryConditionTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMikeBoundaryConditionTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();
            }

            if (TVItemMikeBoundaryConditionTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionTVItemID", mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), new[] { "MikeBoundaryConditionTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeBoundaryConditionTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "MikeBoundaryConditionTVItemID", "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), new[] { "MikeBoundaryConditionTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MikeBoundaryConditionCode"), new[] { "MikeBoundaryConditionCode" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionCode", "100"), new[] { "MikeBoundaryConditionCode" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MikeBoundaryConditionName"), new[] { "MikeBoundaryConditionName" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionName", "100"), new[] { "MikeBoundaryConditionName" });
            }

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionLength_m", "1", "100000"), new[] { "MikeBoundaryConditionLength_m" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MikeBoundaryConditionFormat"), new[] { "MikeBoundaryConditionFormat" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionFormat", "100"), new[] { "MikeBoundaryConditionFormat" });
            }

            retStr = enums.EnumTypeOK(typeof(MikeBoundaryConditionLevelOrVelocityEnum), (int?)mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MikeBoundaryConditionLevelOrVelocity"), new[] { "MikeBoundaryConditionLevelOrVelocity" });
            }

            retStr = enums.EnumTypeOK(typeof(WebTideDataSetEnum), (int?)mikeBoundaryCondition.WebTideDataSet);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "WebTideDataSet"), new[] { "WebTideDataSet" });
            }

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "NumberOfWebTideNodes", "0", "1000"), new[] { "NumberOfWebTideNodes" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "WebTideDataFromStartToEndDate"), new[] { "WebTideDataFromStartToEndDate" });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mikeBoundaryCondition.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
