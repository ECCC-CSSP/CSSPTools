/*
 * Manually edited
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
using LocalServices;

namespace CSSPDBCommandLogServices
{
    public partial interface ICSSPDBCommandLogService
    {
        Task<ActionResult<bool>> Delete(int CSSPCommandLogID);
        Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogTodayList();
        Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogLastWeekList();
        Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogLastMonthList();
        Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogBetweenDatesList(DateTime StartDate, DateTime EndDate);
        Task<ActionResult<int>> GetCSSPCommandLogNextIndexToUse();
        Task<ActionResult<CSSPCommandLog>> GetWithCSSPCommandLogID(int CSSPCommandLogID);
        Task<ActionResult<CSSPCommandLog>> Post(CSSPCommandLog CSSPCommandLog);
        Task<ActionResult<CSSPCommandLog>> Put(CSSPCommandLog CSSPCommandLog);
        CSSPDBCommandLogContext dbCommandLog { get; set; }

    }
    public partial class CSSPDBCommandLogService : ControllerBase, ICSSPDBCommandLogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public CSSPDBCommandLogContext dbCommandLog { get; set; }

        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBCommandLogService(ICSSPCultureService CSSPCultureService, ILocalService LocalService, CSSPDBCommandLogContext dbCommandLog)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.dbCommandLog = dbCommandLog;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<int>> GetCSSPCommandLogNextIndexToUse()
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            int? LastIndex = (from c in dbCommandLog.CSSPCommandLogs
                              orderby c.CSSPCommandLogID descending
                              select c.CSSPCommandLogID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            return await Task.FromResult(Ok(LastIndex));
        }
        public async Task<ActionResult<CSSPCommandLog>> GetWithCSSPCommandLogID(int CSSPCommandLogID)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CSSPCommandLog CSSPCommandLog = (from c in dbCommandLog.CSSPCommandLogs.AsNoTracking()
                                             where c.CSSPCommandLogID == CSSPCommandLogID
                                             select c).FirstOrDefault();

            if (CSSPCommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPCommandLog", "CSSPCommandLogID", CSSPCommandLogID.ToString())));
            }

            return await Task.FromResult(Ok(CSSPCommandLog));
        }
        public async Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogTodayList()
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

            return await GetCSSPCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogLastWeekList()
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 6);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

            return await GetCSSPCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogLastMonthList()
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return await GetCSSPCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CSSPCommandLog>>> GetCSSPCommandLogBetweenDatesList(DateTime StartDate, DateTime EndDate)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<CSSPCommandLog> CSSPCommandLogList = (from c in dbCommandLog.CSSPCommandLogs.AsNoTracking()
                                                       where c.DateTimeUTC >= StartDate
                                                       && c.DateTimeUTC <= EndDate
                                                       orderby c.CSSPCommandLogID
                                                       select c).ToList();

            return await Task.FromResult(Ok(CSSPCommandLogList));
        }

        public async Task<ActionResult<bool>> Delete(int CSSPCommandLogID)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CSSPCommandLog CSSPCommandLog = (from c in dbCommandLog.CSSPCommandLogs
                                             where c.CSSPCommandLogID == CSSPCommandLogID
                                             select c).FirstOrDefault();

            if (CSSPCommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPCommandLog", "CSSPCommandLogID", CSSPCommandLogID.ToString())));
            }

            try
            {
                dbCommandLog.CSSPCommandLogs.Remove(CSSPCommandLog);
                dbCommandLog.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<CSSPCommandLog>> Post(CSSPCommandLog CSSPCommandLog)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            if (CSSPCommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CSSPCommandLog")));
            }

            ValidationResults = Validate(new ValidationContext(CSSPCommandLog), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            int? LastIndex = (from c in dbCommandLog.CSSPCommandLogs
                              orderby c.CSSPCommandLogID descending
                              select c.CSSPCommandLogID).FirstOrDefault();

            LastIndex = LastIndex == null ? 1 : LastIndex + 1;

            try
            {
                CSSPCommandLog.CSSPCommandLogID = (int)LastIndex;
                dbCommandLog.CSSPCommandLogs.Add(CSSPCommandLog);
                dbCommandLog.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(CSSPCommandLog));
        }
        public async Task<ActionResult<CSSPCommandLog>> Put(CSSPCommandLog CSSPCommandLog)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            if (CSSPCommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CSSPCommandLog")));
            }

            ValidationResults = Validate(new ValidationContext(CSSPCommandLog), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbCommandLog.CSSPCommandLogs.Update(CSSPCommandLog);
                dbCommandLog.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(CSSPCommandLog));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPCommandLog CSSPCommandLog = validationContext.ObjectInstance as CSSPCommandLog;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (CSSPCommandLog.CSSPCommandLogID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CSSPCommandLogID"), new[] { nameof(CSSPCommandLog.CSSPCommandLogID) });
                }

                if (!(from c in dbCommandLog.CSSPCommandLogs select c).Where(c => c.CSSPCommandLogID == CSSPCommandLog.CSSPCommandLogID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPCommandLog", "CSSPCommandLogID", CSSPCommandLog.CSSPCommandLogID.ToString()), new[] { nameof(CSSPCommandLog.CSSPCommandLogID) });
                }
            }

            // doing AppName
            if (string.IsNullOrWhiteSpace(CSSPCommandLog.AppName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppName"), new[] { nameof(CSSPCommandLog.AppName) });
            }

            if (!string.IsNullOrWhiteSpace(CSSPCommandLog.AppName) && CSSPCommandLog.AppName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200"), new[] { nameof(CSSPCommandLog.AppName) });
            }

            // doing CommandName
            if (string.IsNullOrWhiteSpace(CSSPCommandLog.CommandName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CommandName"), new[] { nameof(CSSPCommandLog.CommandName) });
            }

            if (!string.IsNullOrWhiteSpace(CSSPCommandLog.CommandName) && CSSPCommandLog.CommandName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200"), new[] { nameof(CSSPCommandLog.CommandName) });
            }

            // doing DateTimeUTC
            if (CSSPCommandLog.DateTimeUTC == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DateTimeUTC"), new[] { nameof(CSSPCommandLog.DateTimeUTC) });
            }

            if (CSSPCommandLog.DateTimeUTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980"), new[] { nameof(CSSPCommandLog.DateTimeUTC) });
            }
        }
        #endregion Functions private

    }
}
