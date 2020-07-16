/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
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
   public partial interface IMWQMSampleService
    {
       Task<ActionResult<bool>> Delete(int MWQMSampleID);
       Task<ActionResult<List<MWQMSample>>> GetMWQMSampleList(int skip = 0, int take = 100);
       Task<ActionResult<MWQMSample>> GetMWQMSampleWithMWQMSampleID(int MWQMSampleID);
       Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmsample);
       Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmsample);
    }
    public partial class MWQMSampleService : ControllerBase, IMWQMSampleService
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
        public MWQMSampleService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<MWQMSample>> GetMWQMSampleWithMWQMSampleID(int MWQMSampleID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSample mwqmSample = (from c in dbIM.MWQMSamples.AsNoTracking()
                                   where c.MWQMSampleID == MWQMSampleID
                                   select c).FirstOrDefault();

                if (mwqmSample == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMSample mwqmSample = (from c in dbLocal.MWQMSamples.AsNoTracking()
                        where c.MWQMSampleID == MWQMSampleID
                        select c).FirstOrDefault();

                if (mwqmSample == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
            else
            {
                MWQMSample mwqmSample = (from c in db.MWQMSamples.AsNoTracking()
                        where c.MWQMSampleID == MWQMSampleID
                        select c).FirstOrDefault();

                if (mwqmSample == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
        }
        public async Task<ActionResult<List<MWQMSample>>> GetMWQMSampleList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MWQMSample> mwqmSampleList = (from c in dbIM.MWQMSamples.AsNoTracking() orderby c.MWQMSampleID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mwqmSampleList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MWQMSample> mwqmSampleList = (from c in dbLocal.MWQMSamples.AsNoTracking() orderby c.MWQMSampleID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSampleList));
            }
            else
            {
                List<MWQMSample> mwqmSampleList = (from c in db.MWQMSamples.AsNoTracking() orderby c.MWQMSampleID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSampleList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSampleID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSample mwqmSample = (from c in dbIM.MWQMSamples
                                   where c.MWQMSampleID == MWQMSampleID
                                   select c).FirstOrDefault();
            
                if (mwqmSample == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", MWQMSampleID.ToString())));
                }
            
                try
                {
                    dbIM.MWQMSamples.Remove(mwqmSample);
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
                MWQMSample mwqmSample = (from c in dbLocal.MWQMSamples
                                   where c.MWQMSampleID == MWQMSampleID
                                   select c).FirstOrDefault();
                
                if (mwqmSample == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", MWQMSampleID.ToString())));
                }

                try
                {
                   dbLocal.MWQMSamples.Remove(mwqmSample);
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
                MWQMSample mwqmSample = (from c in db.MWQMSamples
                                   where c.MWQMSampleID == MWQMSampleID
                                   select c).FirstOrDefault();
                
                if (mwqmSample == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", MWQMSampleID.ToString())));
                }

                try
                {
                   db.MWQMSamples.Remove(mwqmSample);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmSample)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSamples.Add(mwqmSample);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MWQMSamples.Add(mwqmSample);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
            else
            {
                try
                {
                   db.MWQMSamples.Add(mwqmSample);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
        }
        public async Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmSample)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSamples.Update(mwqmSample);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSample));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MWQMSamples.Update(mwqmSample);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSample));
            }
            else
            {
            try
            {
               db.MWQMSamples.Update(mwqmSample);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSample));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSample mwqmSample = validationContext.ObjectInstance as MWQMSample;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSample.MWQMSampleID == 0)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "MWQMSampleID"), new[] { "MWQMSampleID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MWQMSamples select c).Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSample.MWQMSampleID.ToString()), new[] { "MWQMSampleID" });
                    }
                }
                else
                {
                    if (!(from c in db.MWQMSamples select c).Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSample.MWQMSampleID.ToString()), new[] { "MWQMSampleID" });
                    }
                }
            }

            TVItem TVItemMWQMSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();
                if (TVItemMWQMSiteTVItemID == null)
                {
                    TVItemMWQMSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", mwqmSample.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            TVItem TVItemMWQMRunTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMRunTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();
                if (TVItemMWQMRunTVItemID == null)
                {
                    TVItemMWQMRunTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMRunTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunTVItemID", mwqmSample.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "MWQMRunTVItemID", "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            if (mwqmSample.SampleDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SampleDateTime_Local"), new[] { "SampleDateTime_Local" });
            }
            else
            {
                if (mwqmSample.SampleDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "SampleDateTime_Local", "1980"), new[] { "SampleDateTime_Local" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.TimeText) && mwqmSample.TimeText.Length > 6)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "TimeText", "6"), new[] { "TimeText" });
            }

            if (mwqmSample.Depth_m != null)
            {
                if (mwqmSample.Depth_m < 0 || mwqmSample.Depth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "1000"), new[] { "Depth_m" });
                }
            }

            if (mwqmSample.FecCol_MPN_100ml < 0 || mwqmSample.FecCol_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "FecCol_MPN_100ml", "0", "10000000"), new[] { "FecCol_MPN_100ml" });
            }

            if (mwqmSample.Salinity_PPT != null)
            {
                if (mwqmSample.Salinity_PPT < 0 || mwqmSample.Salinity_PPT > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Salinity_PPT", "0", "40"), new[] { "Salinity_PPT" });
                }
            }

            if (mwqmSample.WaterTemp_C != null)
            {
                if (mwqmSample.WaterTemp_C < -10 || mwqmSample.WaterTemp_C > 40)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "WaterTemp_C", "-10", "40"), new[] { "WaterTemp_C" });
                }
            }

            if (mwqmSample.PH != null)
            {
                if (mwqmSample.PH < 0 || mwqmSample.PH > 14)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "PH", "0", "14"), new[] { "PH" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SampleTypesText"), new[] { "SampleTypesText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText) && mwqmSample.SampleTypesText.Length > 50)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "SampleTypesText", "50"), new[] { "SampleTypesText" });
            }

            if (mwqmSample.SampleType_old != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmSample.SampleType_old);
                if (mwqmSample.SampleType_old == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "SampleType_old"), new[] { "SampleType_old" });
                }
            }

            if (mwqmSample.Tube_10 != null)
            {
                if (mwqmSample.Tube_10 < 0 || mwqmSample.Tube_10 > 5)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Tube_10", "0", "5"), new[] { "Tube_10" });
                }
            }

            if (mwqmSample.Tube_1_0 != null)
            {
                if (mwqmSample.Tube_1_0 < 0 || mwqmSample.Tube_1_0 > 5)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Tube_1_0", "0", "5"), new[] { "Tube_1_0" });
                }
            }

            if (mwqmSample.Tube_0_1 != null)
            {
                if (mwqmSample.Tube_0_1 < 0 || mwqmSample.Tube_0_1 > 5)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._ValueShouldBeBetween_And_, "Tube_0_1", "0", "5"), new[] { "Tube_0_1" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.ProcessedBy) && mwqmSample.ProcessedBy.Length > 10)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "ProcessedBy", "10"), new[] { "ProcessedBy" });
            }

            if (mwqmSample.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSample.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSample.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
