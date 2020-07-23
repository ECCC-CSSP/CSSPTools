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
   public partial interface IMWQMSubsectorService
    {
       Task<ActionResult<bool>> Delete(int MWQMSubsectorID);
       Task<ActionResult<List<MWQMSubsector>>> GetMWQMSubsectorList(int skip = 0, int take = 100);
       Task<ActionResult<MWQMSubsector>> GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID);
       Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmsubsector);
       Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmsubsector);
    }
    public partial class MWQMSubsectorService : ControllerBase, IMWQMSubsectorService
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
        public MWQMSubsectorService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<MWQMSubsector>> GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSubsector mwqmSubsector = (from c in dbIM.MWQMSubsectors.AsNoTracking()
                                   where c.MWQMSubsectorID == MWQMSubsectorID
                                   select c).FirstOrDefault();

                if (mwqmSubsector == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMSubsector mwqmSubsector = (from c in dbLocal.MWQMSubsectors.AsNoTracking()
                        where c.MWQMSubsectorID == MWQMSubsectorID
                        select c).FirstOrDefault();

                if (mwqmSubsector == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
            else
            {
                MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors.AsNoTracking()
                        where c.MWQMSubsectorID == MWQMSubsectorID
                        select c).FirstOrDefault();

                if (mwqmSubsector == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
        }
        public async Task<ActionResult<List<MWQMSubsector>>> GetMWQMSubsectorList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MWQMSubsector> mwqmSubsectorList = (from c in dbIM.MWQMSubsectors.AsNoTracking() orderby c.MWQMSubsectorID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mwqmSubsectorList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MWQMSubsector> mwqmSubsectorList = (from c in dbLocal.MWQMSubsectors.AsNoTracking() orderby c.MWQMSubsectorID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSubsectorList));
            }
            else
            {
                List<MWQMSubsector> mwqmSubsectorList = (from c in db.MWQMSubsectors.AsNoTracking() orderby c.MWQMSubsectorID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSubsectorList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSubsectorID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSubsector mwqmSubsector = (from c in dbIM.MWQMSubsectors
                                   where c.MWQMSubsectorID == MWQMSubsectorID
                                   select c).FirstOrDefault();
            
                if (mwqmSubsector == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", MWQMSubsectorID.ToString())));
                }
            
                try
                {
                    dbIM.MWQMSubsectors.Remove(mwqmSubsector);
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
                MWQMSubsector mwqmSubsector = (from c in dbLocal.MWQMSubsectors
                                   where c.MWQMSubsectorID == MWQMSubsectorID
                                   select c).FirstOrDefault();
                
                if (mwqmSubsector == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", MWQMSubsectorID.ToString())));
                }

                try
                {
                   dbLocal.MWQMSubsectors.Remove(mwqmSubsector);
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
                MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors
                                   where c.MWQMSubsectorID == MWQMSubsectorID
                                   select c).FirstOrDefault();
                
                if (mwqmSubsector == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", MWQMSubsectorID.ToString())));
                }

                try
                {
                   db.MWQMSubsectors.Remove(mwqmSubsector);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmSubsector)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSubsectors.Add(mwqmSubsector);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MWQMSubsectors.Add(mwqmSubsector);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
            else
            {
                try
                {
                   db.MWQMSubsectors.Add(mwqmSubsector);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
        }
        public async Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmSubsector)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSubsectors.Update(mwqmSubsector);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsector));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MWQMSubsectors.Update(mwqmSubsector);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsector));
            }
            else
            {
            try
            {
               db.MWQMSubsectors.Update(mwqmSubsector);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsector));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSubsector mwqmSubsector = validationContext.ObjectInstance as MWQMSubsector;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsector.MWQMSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSubsectorID"), new[] { nameof(mwqmSubsector.MWQMSubsectorID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MWQMSubsectors select c).Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString()), new[] { nameof(mwqmSubsector.MWQMSubsectorID) });
                    }
                }
                else
                {
                    if (!(from c in db.MWQMSubsectors select c).Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString()), new[] { nameof(mwqmSubsector.MWQMSubsectorID) });
                    }
                }
            }

            TVItem TVItemMWQMSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemMWQMSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();
                if (TVItemMWQMSubsectorTVItemID == null)
                {
                    TVItemMWQMSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMWQMSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();
            }

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorTVItemID", mwqmSubsector.MWQMSubsectorTVItemID.ToString()), new[] { nameof(mwqmSubsector.MWQMSubsectorTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSubsectorTVItemID", "Subsector"), new[] { nameof(mwqmSubsector.MWQMSubsectorTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorHistoricKey"), new[] { nameof(mwqmSubsector.SubsectorHistoricKey) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SubsectorHistoricKey", "20"), new[] { nameof(mwqmSubsector.SubsectorHistoricKey) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TideLocationSIDText", "20"), new[] { nameof(mwqmSubsector.TideLocationSIDText) });
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSubsector.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSubsector.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSubsector.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSubsector.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSubsector.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
