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
   public partial interface IMWQMAnalysisReportParameterService
    {
       Task<ActionResult<bool>> Delete(int MWQMAnalysisReportParameterID);
       Task<ActionResult<List<MWQMAnalysisReportParameter>>> GetMWQMAnalysisReportParameterList(int skip = 0, int take = 100);
       Task<ActionResult<MWQMAnalysisReportParameter>> GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(int MWQMAnalysisReportParameterID);
       Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter mwqmanalysisreportparameter);
       Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter mwqmanalysisreportparameter);
    }
    public partial class MWQMAnalysisReportParameterService : ControllerBase, IMWQMAnalysisReportParameterService
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
        public MWQMAnalysisReportParameterService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<MWQMAnalysisReportParameter>> GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(int MWQMAnalysisReportParameterID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in dbIM.MWQMAnalysisReportParameters.AsNoTracking()
                                   where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                   select c).FirstOrDefault();

                if (mwqmAnalysisReportParameter == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in dbLocal.MWQMAnalysisReportParameters.AsNoTracking()
                        where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                        select c).FirstOrDefault();

                if (mwqmAnalysisReportParameter == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in db.MWQMAnalysisReportParameters.AsNoTracking()
                        where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                        select c).FirstOrDefault();

                if (mwqmAnalysisReportParameter == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
        }
        public async Task<ActionResult<List<MWQMAnalysisReportParameter>>> GetMWQMAnalysisReportParameterList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = (from c in dbIM.MWQMAnalysisReportParameters.AsNoTracking() orderby c.MWQMAnalysisReportParameterID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mwqmAnalysisReportParameterList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = (from c in dbLocal.MWQMAnalysisReportParameters.AsNoTracking() orderby c.MWQMAnalysisReportParameterID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmAnalysisReportParameterList));
            }
            else
            {
                List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = (from c in db.MWQMAnalysisReportParameters.AsNoTracking() orderby c.MWQMAnalysisReportParameterID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmAnalysisReportParameterList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MWQMAnalysisReportParameterID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in dbIM.MWQMAnalysisReportParameters
                                   where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                   select c).FirstOrDefault();
            
                if (mwqmAnalysisReportParameter == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterID", MWQMAnalysisReportParameterID.ToString())));
                }
            
                try
                {
                    dbIM.MWQMAnalysisReportParameters.Remove(mwqmAnalysisReportParameter);
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
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in dbLocal.MWQMAnalysisReportParameters
                                   where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                   select c).FirstOrDefault();
                
                if (mwqmAnalysisReportParameter == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterID", MWQMAnalysisReportParameterID.ToString())));
                }

                try
                {
                   dbLocal.MWQMAnalysisReportParameters.Remove(mwqmAnalysisReportParameter);
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
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in db.MWQMAnalysisReportParameters
                                   where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                   select c).FirstOrDefault();
                
                if (mwqmAnalysisReportParameter == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterID", MWQMAnalysisReportParameterID.ToString())));
                }

                try
                {
                   db.MWQMAnalysisReportParameters.Remove(mwqmAnalysisReportParameter);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmAnalysisReportParameter), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMAnalysisReportParameters.Add(mwqmAnalysisReportParameter);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MWQMAnalysisReportParameters.Add(mwqmAnalysisReportParameter);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else
            {
                try
                {
                   db.MWQMAnalysisReportParameters.Add(mwqmAnalysisReportParameter);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
        }
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmAnalysisReportParameter), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMAnalysisReportParameters.Update(mwqmAnalysisReportParameter);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MWQMAnalysisReportParameters.Update(mwqmAnalysisReportParameter);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
            else
            {
            try
            {
               db.MWQMAnalysisReportParameters.Update(mwqmAnalysisReportParameter);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmAnalysisReportParameter));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = validationContext.ObjectInstance as MWQMAnalysisReportParameter;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMAnalysisReportParameterID"), new[] { "MWQMAnalysisReportParameterID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MWQMAnalysisReportParameters select c).Where(c => c.MWQMAnalysisReportParameterID == mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterID", mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), new[] { "MWQMAnalysisReportParameterID" });
                    }
                }
                else
                {
                    if (!(from c in db.MWQMAnalysisReportParameters select c).Where(c => c.MWQMAnalysisReportParameterID == mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterID", mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), new[] { "MWQMAnalysisReportParameterID" });
                    }
                }
            }

            TVItem TVItemSubsectorTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemSubsectorTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmAnalysisReportParameter.SubsectorTVItemID select c).FirstOrDefault();
                if (TVItemSubsectorTVItemID == null)
                {
                    TVItemSubsectorTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmAnalysisReportParameter.SubsectorTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.SubsectorTVItemID select c).FirstOrDefault();
            }

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", mwqmAnalysisReportParameter.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.AnalysisName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AnalysisName"), new[] { "AnalysisName" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.AnalysisName) && (mwqmAnalysisReportParameter.AnalysisName.Length < 5 || mwqmAnalysisReportParameter.AnalysisName.Length > 250))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "AnalysisName", "5", "250"), new[] { "AnalysisName" });
            }

            if (mwqmAnalysisReportParameter.AnalysisReportYear != null)
            {
                if (mwqmAnalysisReportParameter.AnalysisReportYear < 1980 || mwqmAnalysisReportParameter.AnalysisReportYear > 2050)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "AnalysisReportYear", "1980", "2050"), new[] { "AnalysisReportYear" });
                }
            }

            if (mwqmAnalysisReportParameter.StartDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StartDate"), new[] { "StartDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.StartDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmAnalysisReportParameter.EndDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EndDate"), new[] { "EndDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.EndDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDate", "1980"), new[] { "EndDate" });
                }
            }

            if (mwqmAnalysisReportParameter.StartDate > mwqmAnalysisReportParameter.EndDate)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDate", "MWQMAnalysisReportParameterStartDate"), new[] { "EndDate" });
            }

            retStr = enums.EnumTypeOK(typeof(AnalysisCalculationTypeEnum), (int?)mwqmAnalysisReportParameter.AnalysisCalculationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AnalysisCalculationType"), new[] { "AnalysisCalculationType" });
            }

            if (mwqmAnalysisReportParameter.NumberOfRuns < 1 || mwqmAnalysisReportParameter.NumberOfRuns > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfRuns", "1", "1000"), new[] { "NumberOfRuns" });
            }

            if (mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage < 1 || mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "SalinityHighlightDeviationFromAverage", "1", "20"), new[] { "SalinityHighlightDeviationFromAverage" });
            }

            if (mwqmAnalysisReportParameter.ShortRangeNumberOfDays < 0 || mwqmAnalysisReportParameter.ShortRangeNumberOfDays > 5)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ShortRangeNumberOfDays", "0", "5"), new[] { "ShortRangeNumberOfDays" });
            }

            if (mwqmAnalysisReportParameter.MidRangeNumberOfDays < 2 || mwqmAnalysisReportParameter.MidRangeNumberOfDays > 7)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MidRangeNumberOfDays", "2", "7"), new[] { "MidRangeNumberOfDays" });
            }

            if (mwqmAnalysisReportParameter.DryLimit24h < 1 || mwqmAnalysisReportParameter.DryLimit24h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DryLimit24h", "1", "100"), new[] { "DryLimit24h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit48h < 1 || mwqmAnalysisReportParameter.DryLimit48h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DryLimit48h", "1", "100"), new[] { "DryLimit48h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit72h < 1 || mwqmAnalysisReportParameter.DryLimit72h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DryLimit72h", "1", "100"), new[] { "DryLimit72h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit96h < 1 || mwqmAnalysisReportParameter.DryLimit96h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DryLimit96h", "1", "100"), new[] { "DryLimit96h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit24h < 1 || mwqmAnalysisReportParameter.WetLimit24h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WetLimit24h", "1", "100"), new[] { "WetLimit24h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit48h < 1 || mwqmAnalysisReportParameter.WetLimit48h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WetLimit48h", "1", "100"), new[] { "WetLimit48h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit72h < 1 || mwqmAnalysisReportParameter.WetLimit72h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WetLimit72h", "1", "100"), new[] { "WetLimit72h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit96h < 1 || mwqmAnalysisReportParameter.WetLimit96h > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "WetLimit96h", "1", "100"), new[] { "WetLimit96h" });
            }

            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.RunsToOmit))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunsToOmit"), new[] { "RunsToOmit" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.RunsToOmit) && mwqmAnalysisReportParameter.RunsToOmit.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "RunsToOmit", "250"), new[] { "RunsToOmit" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.ShowDataTypes) && mwqmAnalysisReportParameter.ShowDataTypes.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ShowDataTypes", "20"), new[] { "ShowDataTypes" });
            }

            if (mwqmAnalysisReportParameter.ExcelTVFileTVItemID != null)
            {
                TVItem TVItemExcelTVFileTVItemID = null;
                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    TVItemExcelTVFileTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmAnalysisReportParameter.ExcelTVFileTVItemID select c).FirstOrDefault();
                    if (TVItemExcelTVFileTVItemID == null)
                    {
                        TVItemExcelTVFileTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmAnalysisReportParameter.ExcelTVFileTVItemID select c).FirstOrDefault();
                    }
                }
                else
                {
                    TVItemExcelTVFileTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.ExcelTVFileTVItemID select c).FirstOrDefault();
                }

                if (TVItemExcelTVFileTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ExcelTVFileTVItemID", (mwqmAnalysisReportParameter.ExcelTVFileTVItemID == null ? "" : mwqmAnalysisReportParameter.ExcelTVFileTVItemID.ToString())), new[] { "ExcelTVFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemExcelTVFileTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ExcelTVFileTVItemID", "File"), new[] { "ExcelTVFileTVItemID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(AnalysisReportExportCommandEnum), (int?)mwqmAnalysisReportParameter.Command);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Command"), new[] { "Command" });
            }

            if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmAnalysisReportParameter.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmAnalysisReportParameter.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmAnalysisReportParameter.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
