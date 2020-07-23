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
   public partial interface ITelService
    {
       Task<ActionResult<bool>> Delete(int TelID);
       Task<ActionResult<List<Tel>>> GetTelList(int skip = 0, int take = 100);
       Task<ActionResult<Tel>> GetTelWithTelID(int TelID);
       Task<ActionResult<Tel>> Post(Tel tel);
       Task<ActionResult<Tel>> Put(Tel tel);
    }
    public partial class TelService : ControllerBase, ITelService
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
        public TelService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<Tel>> GetTelWithTelID(int TelID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Tel tel = (from c in dbIM.Tels.AsNoTracking()
                                   where c.TelID == TelID
                                   select c).FirstOrDefault();

                if (tel == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                Tel tel = (from c in dbLocal.Tels.AsNoTracking()
                        where c.TelID == TelID
                        select c).FirstOrDefault();

                if (tel == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tel));
            }
            else
            {
                Tel tel = (from c in db.Tels.AsNoTracking()
                        where c.TelID == TelID
                        select c).FirstOrDefault();

                if (tel == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tel));
            }
        }
        public async Task<ActionResult<List<Tel>>> GetTelList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<Tel> telList = (from c in dbIM.Tels.AsNoTracking() orderby c.TelID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(telList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<Tel> telList = (from c in dbLocal.Tels.AsNoTracking() orderby c.TelID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(telList));
            }
            else
            {
                List<Tel> telList = (from c in db.Tels.AsNoTracking() orderby c.TelID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(telList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TelID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                Tel tel = (from c in dbIM.Tels
                                   where c.TelID == TelID
                                   select c).FirstOrDefault();
            
                if (tel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", TelID.ToString())));
                }
            
                try
                {
                    dbIM.Tels.Remove(tel);
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
                Tel tel = (from c in dbLocal.Tels
                                   where c.TelID == TelID
                                   select c).FirstOrDefault();
                
                if (tel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", TelID.ToString())));
                }

                try
                {
                   dbLocal.Tels.Remove(tel);
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
                Tel tel = (from c in db.Tels
                                   where c.TelID == TelID
                                   select c).FirstOrDefault();
                
                if (tel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", TelID.ToString())));
                }

                try
                {
                   db.Tels.Remove(tel);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<Tel>> Post(Tel tel)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Tels.Add(tel);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.Tels.Add(tel);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tel));
            }
            else
            {
                try
                {
                   db.Tels.Add(tel);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tel));
            }
        }
        public async Task<ActionResult<Tel>> Put(Tel tel)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.Tels.Update(tel);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.Tels.Update(tel);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tel));
            }
            else
            {
            try
            {
               db.Tels.Update(tel);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tel));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Tel tel = validationContext.ObjectInstance as Tel;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tel.TelID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TelID"), new[] { nameof(tel.TelID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.Tels select c).Where(c => c.TelID == tel.TelID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString()), new[] { nameof(tel.TelID) });
                    }
                }
                else
                {
                    if (!(from c in db.Tels select c).Where(c => c.TelID == tel.TelID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString()), new[] { nameof(tel.TelID) });
                    }
                }
            }

            TVItem TVItemTelTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTelTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();
                if (TVItemTelTVItemID == null)
                {
                    TVItemTelTVItemID = (from c in dbIM.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTelTVItemID = (from c in db.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();
            }

            if (TVItemTelTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TelTVItemID", tel.TelTVItemID.ToString()), new[] { nameof(tel.TelTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Tel,
                };
                if (!AllowableTVTypes.Contains(TVItemTelTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TelTVItemID", "Tel"), new[] { nameof(tel.TelTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(tel.TelNumber))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TelNumber"), new[] { nameof(tel.TelNumber) });
            }

            if (!string.IsNullOrWhiteSpace(tel.TelNumber) && tel.TelNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TelNumber", "50"), new[] { nameof(tel.TelNumber) });
            }

            retStr = enums.EnumTypeOK(typeof(TelTypeEnum), (int?)tel.TelType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TelType"), new[] { nameof(tel.TelType) });
            }

            if (tel.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tel.LastUpdateDate_UTC) });
            }
            else
            {
                if (tel.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tel.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tel.LastUpdateContactTVItemID.ToString()), new[] { nameof(tel.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tel.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
