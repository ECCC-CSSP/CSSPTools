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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface ILogDBService
    {
        Task<ActionResult<bool>> Delete(int LogID);
        Task<ActionResult<List<Log>>> GetLogList(int skip = 0, int take = 100);
        Task<ActionResult<Log>> GetLogWithLogID(int LogID);
        Task<ActionResult<Log>> Post(Log log);
        Task<ActionResult<Log>> Put(Log log);
    }
    public partial class LogDBService : ControllerBase, ILogDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LogDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Log>> GetLogWithLogID(int LogID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            Log log = (from c in db.Logs.AsNoTracking()
                    where c.LogID == LogID
                    select c).FirstOrDefault();

            if (log == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(log));
        }
        public async Task<ActionResult<List<Log>>> GetLogList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<Log> logList = (from c in db.Logs.AsNoTracking() orderby c.LogID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(logList));
        }
        public async Task<ActionResult<bool>> Delete(int LogID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Log log = (from c in db.Logs
                    where c.LogID == LogID
                    select c).FirstOrDefault();

            if (log == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", LogID.ToString())));
            }

            try
            {
                db.Logs.Remove(log);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Log>> Post(Log log)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(log));
        }
        public async Task<ActionResult<Log>> Put(Log log)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.Logs.Update(log);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(log));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Log log = validationContext.ObjectInstance as Log;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (log.LogID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LogID"), new[] { nameof(log.LogID) });
                }

                if (!(from c in db.Logs select c).Where(c => c.LogID == log.LogID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString()), new[] { nameof(log.LogID) });
                }
            }

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TableName"), new[] { nameof(log.TableName) });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TableName", "50"), new[] { nameof(log.TableName) });
            }

            if (log.ID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "ID", "1"), new[] { nameof(log.ID) });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LogCommand"), new[] { nameof(log.LogCommand) });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Information"), new[] { nameof(log.Information) });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(log.LastUpdateDate_UTC) });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(log.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), new[] { nameof(log.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(log.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
