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
   public partial interface IMWQMSubsectorLanguageService
    {
       Task<ActionResult<bool>> Delete(int MWQMSubsectorLanguageID);
       Task<ActionResult<List<MWQMSubsectorLanguage>>> GetMWQMSubsectorLanguageList(int skip = 0, int take = 100);
       Task<ActionResult<MWQMSubsectorLanguage>> GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID);
       Task<ActionResult<MWQMSubsectorLanguage>> Post(MWQMSubsectorLanguage mwqmsubsectorlanguage);
       Task<ActionResult<MWQMSubsectorLanguage>> Put(MWQMSubsectorLanguage mwqmsubsectorlanguage);
    }
    public partial class MWQMSubsectorLanguageService : ControllerBase, IMWQMSubsectorLanguageService
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
        public MWQMSubsectorLanguageService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<MWQMSubsectorLanguage>> GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbIM.MWQMSubsectorLanguages.AsNoTracking()
                                   where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                   select c).FirstOrDefault();

                if (mwqmSubsectorLanguage == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbLocal.MWQMSubsectorLanguages.AsNoTracking()
                        where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                        select c).FirstOrDefault();

                if (mwqmSubsectorLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else
            {
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in db.MWQMSubsectorLanguages.AsNoTracking()
                        where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                        select c).FirstOrDefault();

                if (mwqmSubsectorLanguage == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
        }
        public async Task<ActionResult<List<MWQMSubsectorLanguage>>> GetMWQMSubsectorLanguageList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = (from c in dbIM.MWQMSubsectorLanguages.AsNoTracking() orderby c.MWQMSubsectorLanguageID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(mwqmSubsectorLanguageList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = (from c in dbLocal.MWQMSubsectorLanguages.AsNoTracking() orderby c.MWQMSubsectorLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSubsectorLanguageList));
            }
            else
            {
                List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = (from c in db.MWQMSubsectorLanguages.AsNoTracking() orderby c.MWQMSubsectorLanguageID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(mwqmSubsectorLanguageList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSubsectorLanguageID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbIM.MWQMSubsectorLanguages
                                   where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                   select c).FirstOrDefault();
            
                if (mwqmSubsectorLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", MWQMSubsectorLanguageID.ToString())));
                }
            
                try
                {
                    dbIM.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);
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
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbLocal.MWQMSubsectorLanguages
                                   where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                   select c).FirstOrDefault();
                
                if (mwqmSubsectorLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", MWQMSubsectorLanguageID.ToString())));
                }

                try
                {
                   dbLocal.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);
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
                MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in db.MWQMSubsectorLanguages
                                   where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                   select c).FirstOrDefault();
                
                if (mwqmSubsectorLanguage == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", MWQMSubsectorLanguageID.ToString())));
                }

                try
                {
                   db.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<MWQMSubsectorLanguage>> Post(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguage);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else
            {
                try
                {
                   db.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguage);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
        }
        public async Task<ActionResult<MWQMSubsectorLanguage>> Put(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.MWQMSubsectorLanguages.Update(mwqmSubsectorLanguage);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.MWQMSubsectorLanguages.Update(mwqmSubsectorLanguage);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
            else
            {
            try
            {
               db.MWQMSubsectorLanguages.Update(mwqmSubsectorLanguage);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsectorLanguage));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MWQMSubsectorLanguage mwqmSubsectorLanguage = validationContext.ObjectInstance as MWQMSubsectorLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsectorLanguage.MWQMSubsectorLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSubsectorLanguageID"), new[] { nameof(mwqmSubsectorLanguage.MWQMSubsectorLanguageID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), new[] { nameof(mwqmSubsectorLanguage.MWQMSubsectorLanguageID) });
                    }
                }
                else
                {
                    if (!(from c in db.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), new[] { nameof(mwqmSubsectorLanguage.MWQMSubsectorLanguageID) });
                    }
                }
            }

            MWQMSubsector MWQMSubsectorMWQMSubsectorID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                MWQMSubsectorMWQMSubsectorID = (from c in dbLocal.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();
                if (MWQMSubsectorMWQMSubsectorID == null)
                {
                    MWQMSubsectorMWQMSubsectorID = (from c in dbIM.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();
                }
            }
            else
            {
                MWQMSubsectorMWQMSubsectorID = (from c in db.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();
            }

            if (MWQMSubsectorMWQMSubsectorID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), new[] { nameof(mwqmSubsectorLanguage.MWQMSubsectorID) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSubsectorLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(mwqmSubsectorLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorDesc"), new[] { nameof(mwqmSubsectorLanguage.SubsectorDesc) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc) && mwqmSubsectorLanguage.SubsectorDesc.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SubsectorDesc", "250"), new[] { nameof(mwqmSubsectorLanguage.SubsectorDesc) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusSubsectorDesc);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusSubsectorDesc"), new[] { nameof(mwqmSubsectorLanguage.TranslationStatusSubsectorDesc) });
            }

            //LogBook has no StringLength Attribute

            if (mwqmSubsectorLanguage.TranslationStatusLogBook != null)
            {
                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusLogBook);
                if (mwqmSubsectorLanguage.TranslationStatusLogBook == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatusLogBook"), new[] { nameof(mwqmSubsectorLanguage.TranslationStatusLogBook) });
                }
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSubsectorLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSubsectorLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSubsectorLanguage.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSubsectorLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
