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
   public partial interface ILabSheetTubeMPNDetailService
    {
       Task<ActionResult<bool>> Delete(int LabSheetTubeMPNDetailID);
       Task<ActionResult<List<LabSheetTubeMPNDetail>>> GetLabSheetTubeMPNDetailList(int skip = 0, int take = 100);
       Task<ActionResult<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID);
       Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail labsheettubempndetail);
       Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail labsheettubempndetail);
    }
    public partial class LabSheetTubeMPNDetailService : ControllerBase, ILabSheetTubeMPNDetailService
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
        public LabSheetTubeMPNDetailService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, 
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
        public async Task<ActionResult<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbIM.LabSheetTubeMPNDetails.AsNoTracking()
                                   where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                   select c).FirstOrDefault();

                if (labSheetTubeMPNDetail == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbLocal.LabSheetTubeMPNDetails.AsNoTracking()
                        where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                        select c).FirstOrDefault();

                if (labSheetTubeMPNDetail == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else
            {
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails.AsNoTracking()
                        where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                        select c).FirstOrDefault();

                if (labSheetTubeMPNDetail == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
        }
        public async Task<ActionResult<List<LabSheetTubeMPNDetail>>> GetLabSheetTubeMPNDetailList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (from c in dbIM.LabSheetTubeMPNDetails.AsNoTracking() orderby c.LabSheetTubeMPNDetailID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(labSheetTubeMPNDetailList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (from c in dbLocal.LabSheetTubeMPNDetails.AsNoTracking() orderby c.LabSheetTubeMPNDetailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(labSheetTubeMPNDetailList));
            }
            else
            {
                List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = (from c in db.LabSheetTubeMPNDetails.AsNoTracking() orderby c.LabSheetTubeMPNDetailID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(labSheetTubeMPNDetailList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int LabSheetTubeMPNDetailID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbIM.LabSheetTubeMPNDetails
                                   where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                   select c).FirstOrDefault();
            
                if (labSheetTubeMPNDetail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", LabSheetTubeMPNDetailID.ToString())));
                }
            
                try
                {
                    dbIM.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);
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
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbLocal.LabSheetTubeMPNDetails
                                   where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                   select c).FirstOrDefault();
                
                if (labSheetTubeMPNDetail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", LabSheetTubeMPNDetailID.ToString())));
                }

                try
                {
                   dbLocal.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);
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
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails
                                   where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                   select c).FirstOrDefault();
                
                if (labSheetTubeMPNDetail == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", LabSheetTubeMPNDetailID.ToString())));
                }

                try
                {
                   db.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else
            {
                try
                {
                   db.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
        }
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.LabSheetTubeMPNDetails.Update(labSheetTubeMPNDetail);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.LabSheetTubeMPNDetails.Update(labSheetTubeMPNDetail);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
            else
            {
            try
            {
               db.LabSheetTubeMPNDetails.Update(labSheetTubeMPNDetail);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(labSheetTubeMPNDetail));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = validationContext.ObjectInstance as LabSheetTubeMPNDetail;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheetTubeMPNDetail.LabSheetTubeMPNDetailID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LabSheetTubeMPNDetailID"), new[] { nameof(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), new[] { nameof(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID) });
                    }
                }
                else
                {
                    if (!(from c in db.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), new[] { nameof(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID) });
                    }
                }
            }

            LabSheetDetail LabSheetDetailLabSheetDetailID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                LabSheetDetailLabSheetDetailID = (from c in dbLocal.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();
                if (LabSheetDetailLabSheetDetailID == null)
                {
                    LabSheetDetailLabSheetDetailID = (from c in dbIM.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();
                }
            }
            else
            {
                LabSheetDetailLabSheetDetailID = (from c in db.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();
            }

            if (LabSheetDetailLabSheetDetailID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", labSheetTubeMPNDetail.LabSheetDetailID.ToString()), new[] { nameof(labSheetTubeMPNDetail.LabSheetDetailID) });
            }

            if (labSheetTubeMPNDetail.Ordinal < 0 || labSheetTubeMPNDetail.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { nameof(labSheetTubeMPNDetail.Ordinal) });
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();
                if (TVItemMWQMSiteTVItemID == null)
                {
                    TVItemMWQMSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), new[] { nameof(labSheetTubeMPNDetail.MWQMSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { nameof(labSheetTubeMPNDetail.MWQMSiteTVItemID) });
                }
            }

            if (labSheetTubeMPNDetail.SampleDateTime != null && ((DateTime)labSheetTubeMPNDetail.SampleDateTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "SampleDateTime", "1980"), new[] { nameof(labSheetTubeMPNDetail.SampleDateTime) });
            }

            if (labSheetTubeMPNDetail.MPN != null)
            {
                if (labSheetTubeMPNDetail.MPN < 1 || labSheetTubeMPNDetail.MPN > 10000000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN", "1", "10000000"), new[] { nameof(labSheetTubeMPNDetail.MPN) });
                }
            }

            if (labSheetTubeMPNDetail.Tube10 != null)
            {
                if (labSheetTubeMPNDetail.Tube10 < 0 || labSheetTubeMPNDetail.Tube10 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube10", "0", "5"), new[] { nameof(labSheetTubeMPNDetail.Tube10) });
                }
            }

            if (labSheetTubeMPNDetail.Tube1_0 != null)
            {
                if (labSheetTubeMPNDetail.Tube1_0 < 0 || labSheetTubeMPNDetail.Tube1_0 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube1_0", "0", "5"), new[] { nameof(labSheetTubeMPNDetail.Tube1_0) });
                }
            }

            if (labSheetTubeMPNDetail.Tube0_1 != null)
            {
                if (labSheetTubeMPNDetail.Tube0_1 < 0 || labSheetTubeMPNDetail.Tube0_1 > 5)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tube0_1", "0", "5"), new[] { nameof(labSheetTubeMPNDetail.Tube0_1) });
                }
            }

            if (labSheetTubeMPNDetail.Salinity != null)
            {
                if (labSheetTubeMPNDetail.Salinity < 0 || labSheetTubeMPNDetail.Salinity > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Salinity", "0", "40"), new[] { nameof(labSheetTubeMPNDetail.Salinity) });
                }
            }

            if (labSheetTubeMPNDetail.Temperature != null)
            {
                if (labSheetTubeMPNDetail.Temperature < -10 || labSheetTubeMPNDetail.Temperature > 40)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Temperature", "-10", "40"), new[] { nameof(labSheetTubeMPNDetail.Temperature) });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.ProcessedBy) && labSheetTubeMPNDetail.ProcessedBy.Length > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ProcessedBy", "10"), new[] { nameof(labSheetTubeMPNDetail.ProcessedBy) });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetTubeMPNDetail.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"), new[] { nameof(labSheetTubeMPNDetail.SampleType) });
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.SiteComment) && labSheetTubeMPNDetail.SiteComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SiteComment", "250"), new[] { nameof(labSheetTubeMPNDetail.SiteComment) });
            }

            if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(labSheetTubeMPNDetail.LastUpdateDate_UTC) });
            }
            else
            {
                if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(labSheetTubeMPNDetail.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), new[] { nameof(labSheetTubeMPNDetail.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(labSheetTubeMPNDetail.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
