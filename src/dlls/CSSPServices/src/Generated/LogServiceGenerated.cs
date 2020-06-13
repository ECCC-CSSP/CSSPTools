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
   public interface ILogService
    {
       Task<ActionResult<Log>> GetLogWithLogID(int LogID);
       Task<ActionResult<List<Log>>> GetLogList();
       Task<ActionResult<Log>> Add(Log log);
       Task<ActionResult<bool>> Delete(int LogID);
       Task<ActionResult<Log>> Update(Log log);
    }
    public partial class LogService : ControllerBase, ILogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LogService(ICultureService CultureService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Log>> GetLogWithLogID(int LogID)
        {
            Log log = (from c in db.Logs.AsNoTracking()
                    where c.LogID == LogID
                    select c).FirstOrDefault();

            if (log == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(log));
        }
        public async Task<ActionResult<List<Log>>> GetLogList()
        {
            List<Log> logList = (from c in db.Logs.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(logList));
        }
        public async Task<ActionResult<Log>> Add(Log log)
        {
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
        public async Task<ActionResult<bool>> Delete(int LogID)
        {
            Log log = (from c in db.Logs
                               where c.LogID == LogID
                               select c).FirstOrDefault();
            
            if (log == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", LogID.ToString())));
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
        public async Task<ActionResult<Log>> Update(Log log)
        {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LogID"), new[] { "LogID" });
                }

                if (!(from c in db.Logs select c).Where(c => c.LogID == log.LogID).Any())
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString()), new[] { "LogID" });
                }
            }

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "TableName"), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "TableName", "50"), new[] { "TableName" });
            }

            if (log.ID < 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MinValueIs_, "ID", "1"), new[] { "ID" });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LogCommand"), new[] { "LogCommand" });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "Information"), new[] { "Information" });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
