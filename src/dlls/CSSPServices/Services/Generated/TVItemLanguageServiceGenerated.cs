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
   public partial interface ITVItemLanguageService
    {
       Task<ActionResult<bool>> Delete(int TVItemLanguageID);
       Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<TVItemLanguage>> GetTVItemLanguageWithTVItemLanguageID(int TVItemLanguageID);
       Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage tvitemlanguage);
       Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage tvitemlanguage);
    }
    public partial class TVItemLanguageService : ControllerBase, ITVItemLanguageService
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
        public TVItemLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
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
        public async Task<ActionResult<TVItemLanguage>> GetTVItemLanguageWithTVItemLanguageID(int TVItemLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVItemLanguage tvItemLanguage = (from c in dbIM.TVItemLanguages.AsNoTracking()
                                   where c.TVItemLanguageID == TVItemLanguageID
                                   select c).FirstOrDefault();

                if (tvItemLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages.AsNoTracking()
                        where c.TVItemLanguageID == TVItemLanguageID
                        select c).FirstOrDefault();

                if (tvItemLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
            else
            {
                TVItemLanguage tvItemLanguage = (from c in db.TVItemLanguages.AsNoTracking()
                        where c.TVItemLanguageID == TVItemLanguageID
                        select c).FirstOrDefault();

                if (tvItemLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
        }
        public async Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVItemLanguage> tvItemLanguageList = (from c in dbIM.TVItemLanguages.AsNoTracking() orderby c.TVItemLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(tvItemLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages.AsNoTracking() orderby c.TVItemLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvItemLanguageList));
            }
            else
            {
                List<TVItemLanguage> tvItemLanguageList = (from c in db.TVItemLanguages.AsNoTracking() orderby c.TVItemLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(tvItemLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int TVItemLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                TVItemLanguage tvItemLanguage = (from c in dbIM.TVItemLanguages
                                   where c.TVItemLanguageID == TVItemLanguageID
                                   select c).FirstOrDefault();
            
                if (tvItemLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", TVItemLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.TVItemLanguages.Remove(tvItemLanguage);
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
                TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                   where c.TVItemLanguageID == TVItemLanguageID
                                   select c).FirstOrDefault();
                
                if (tvItemLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", TVItemLanguageID.ToString())));
                }

                try
                {
                   dbLocal.TVItemLanguages.Remove(tvItemLanguage);
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
                TVItemLanguage tvItemLanguage = (from c in db.TVItemLanguages
                                   where c.TVItemLanguageID == TVItemLanguageID
                                   select c).FirstOrDefault();
                
                if (tvItemLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", TVItemLanguageID.ToString())));
                }

                try
                {
                   db.TVItemLanguages.Remove(tvItemLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage tvItemLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVItemLanguages.Add(tvItemLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.TVItemLanguages.Add(tvItemLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
            else
            {
                try
                {
                   db.TVItemLanguages.Add(tvItemLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
        }
        public async Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage tvItemLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.TVItemLanguages.Update(tvItemLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(tvItemLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.TVItemLanguages.Update(tvItemLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemLanguage));
            }
            else
            {
            try
            {
               db.TVItemLanguages.Update(tvItemLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItemLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItemLanguage tvItemLanguage = validationContext.ObjectInstance as TVItemLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemLanguage.TVItemLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemLanguageID"), new[] { "TVItemLanguageID" });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.TVItemLanguages select c).Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString()), new[] { "TVItemLanguageID" });
                    }
                }
                else
                {
                    if (!(from c in db.TVItemLanguages select c).Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString()), new[] { "TVItemLanguageID" });
                    }
                }
            }

            TVItem TVItemTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).FirstOrDefault();
                if (TVItemTVItemID == null)
                {
                    TVItemTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).FirstOrDefault();
            }

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItemLanguage.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Contact,
                    TVTypeEnum.Country,
                    TVTypeEnum.Email,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.Tel,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvItemLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TVText) && tvItemLanguage.TVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVText", "200"), new[] { "TVText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvItemLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (tvItemLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
