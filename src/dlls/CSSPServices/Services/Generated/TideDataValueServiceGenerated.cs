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
   public partial interface ITideDataValueService
    {
       Task<ActionResult<bool>> Delete(int TideDataValueID);
       Task<ActionResult<List<TideDataValue>>> GetTideDataValueList(int skip = 0, int take = 100);
       Task<ActionResult<TideDataValue>> GetTideDataValueWithTideDataValueID(int TideDataValueID);
       Task<ActionResult<TideDataValue>> Post(TideDataValue tidedatavalue);
       Task<ActionResult<TideDataValue>> Put(TideDataValue tidedatavalue);
    }
    public partial class TideDataValueService : ControllerBase, ITideDataValueService
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
        public TideDataValueService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TideDataValue>> GetTideDataValueWithTideDataValueID(int TideDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TideDataValue tideDataValue = (from c in dbIM.TideDataValues.AsNoTracking()
                                   where c.TideDataValueID == TideDataValueID
                                   select c).FirstOrDefault();

                if (tideDataValue == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TideDataValue tideDataValue = (from c in dbLocal.TideDataValues.AsNoTracking()
                        where c.TideDataValueID == TideDataValueID
                        select c).FirstOrDefault();

                if (tideDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
            else
            {
                TideDataValue tideDataValue = (from c in db.TideDataValues.AsNoTracking()
                        where c.TideDataValueID == TideDataValueID
                        select c).FirstOrDefault();

                if (tideDataValue == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
        }
        public async Task<ActionResult<List<TideDataValue>>> GetTideDataValueList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TideDataValue> tideDataValueList = (from c in dbIM.TideDataValues.AsNoTracking() orderby c.TideDataValueID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tideDataValueList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TideDataValue> tideDataValueList = (from c in dbLocal.TideDataValues.AsNoTracking() orderby c.TideDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tideDataValueList));
            }
            else
            {
                List<TideDataValue> tideDataValueList = (from c in db.TideDataValues.AsNoTracking() orderby c.TideDataValueID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tideDataValueList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TideDataValueID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TideDataValue tideDataValue = (from c in dbIM.TideDataValues
                                   where c.TideDataValueID == TideDataValueID
                                   select c).FirstOrDefault();
            
                if (tideDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", TideDataValueID.ToString())));
                }
            
                try
                {
                    dbIM.TideDataValues.Remove(tideDataValue);
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
                TideDataValue tideDataValue = (from c in dbLocal.TideDataValues
                                   where c.TideDataValueID == TideDataValueID
                                   select c).FirstOrDefault();
                
                if (tideDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", TideDataValueID.ToString())));
                }

                try
                {
                   dbLocal.TideDataValues.Remove(tideDataValue);
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
                TideDataValue tideDataValue = (from c in db.TideDataValues
                                   where c.TideDataValueID == TideDataValueID
                                   select c).FirstOrDefault();
                
                if (tideDataValue == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", TideDataValueID.ToString())));
                }

                try
                {
                   db.TideDataValues.Remove(tideDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TideDataValue>> Post(TideDataValue tideDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TideDataValues.Add(tideDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TideDataValues.Add(tideDataValue);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
            else
            {
                try
                {
                   db.TideDataValues.Add(tideDataValue);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
        }
        public async Task<ActionResult<TideDataValue>> Put(TideDataValue tideDataValue)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TideDataValues.Update(tideDataValue);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tideDataValue));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TideDataValues.Update(tideDataValue);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideDataValue));
            }
            else
            {
            try
            {
               db.TideDataValues.Update(tideDataValue);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tideDataValue));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TideDataValue tideDataValue = validationContext.ObjectInstance as TideDataValue;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideDataValue.TideDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideDataValueID"), new[] { nameof(tideDataValue.TideDataValueID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TideDataValues select c).Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", tideDataValue.TideDataValueID.ToString()), new[] { nameof(tideDataValue.TideDataValueID) });
                    }
                }
                else
                {
                    if (!(from c in db.TideDataValues select c).Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", tideDataValue.TideDataValueID.ToString()), new[] { nameof(tideDataValue.TideDataValueID) });
                    }
                }
            }

            TVItem TVItemTideSiteTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTideSiteTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();
                if (TVItemTideSiteTVItemID == null)
                {
                    TVItemTideSiteTVItemID = (from c in dbIM.TVItems where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();
            }

            if (TVItemTideSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTVItemID", tideDataValue.TideSiteTVItemID.ToString()), new[] { nameof(tideDataValue.TideSiteTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), new[] { nameof(tideDataValue.TideSiteTVItemID) });
                }
            }

            if (tideDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTime_Local"), new[] { nameof(tideDataValue.DateTime_Local) });
            }
            else
            {
                if (tideDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { nameof(tideDataValue.DateTime_Local) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TideDataTypeEnum), (int?)tideDataValue.TideDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideDataType"), new[] { nameof(tideDataValue.TideDataType) });
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)tideDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StorageDataType"), new[] { nameof(tideDataValue.StorageDataType) });
            }

            if (tideDataValue.Depth_m < 0 || tideDataValue.Depth_m > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "10000"), new[] { nameof(tideDataValue.Depth_m) });
            }

            if (tideDataValue.UVelocity_m_s < 0 || tideDataValue.UVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "UVelocity_m_s", "0", "10"), new[] { nameof(tideDataValue.UVelocity_m_s) });
            }

            if (tideDataValue.VVelocity_m_s < 0 || tideDataValue.VVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "VVelocity_m_s", "0", "10"), new[] { nameof(tideDataValue.VVelocity_m_s) });
            }

            if (tideDataValue.TideStart != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideStart);
                if (tideDataValue.TideStart == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideStart"), new[] { nameof(tideDataValue.TideStart) });
                }
            }

            if (tideDataValue.TideEnd != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideEnd);
                if (tideDataValue.TideEnd == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TideEnd"), new[] { nameof(tideDataValue.TideEnd) });
                }
            }

            if (tideDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tideDataValue.LastUpdateDate_UTC) });
            }
            else
            {
                if (tideDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tideDataValue.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideDataValue.LastUpdateContactTVItemID.ToString()), new[] { nameof(tideDataValue.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tideDataValue.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
