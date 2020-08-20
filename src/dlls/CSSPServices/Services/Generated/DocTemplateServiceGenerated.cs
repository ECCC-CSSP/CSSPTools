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
   public partial interface IDocTemplateService
    {
       Task<ActionResult<bool>> Delete(int DocTemplateID);
       Task<ActionResult<List<DocTemplate>>> GetDocTemplateList(int skip = 0, int take = 100);
       Task<ActionResult<DocTemplate>> GetDocTemplateWithDocTemplateID(int DocTemplateID);
       Task<ActionResult<DocTemplate>> Post(DocTemplate doctemplate);
       Task<ActionResult<DocTemplate>> Put(DocTemplate doctemplate);
    }
    public partial class DocTemplateService : ControllerBase, IDocTemplateService
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
        public DocTemplateService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null)
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
        public async Task<ActionResult<DocTemplate>> GetDocTemplateWithDocTemplateID(int DocTemplateID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DocTemplate docTemplate = (from c in dbIM.DocTemplates.AsNoTracking()
                                   where c.DocTemplateID == DocTemplateID
                                   select c).FirstOrDefault();

                if (docTemplate == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(docTemplate));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                DocTemplate docTemplate = (from c in dbLocal.DocTemplates.AsNoTracking()
                        where c.DocTemplateID == DocTemplateID
                        select c).FirstOrDefault();

                if (docTemplate == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(docTemplate));
            }
            else
            {
                DocTemplate docTemplate = (from c in db.DocTemplates.AsNoTracking()
                        where c.DocTemplateID == DocTemplateID
                        select c).FirstOrDefault();

                if (docTemplate == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(docTemplate));
            }
        }
        public async Task<ActionResult<List<DocTemplate>>> GetDocTemplateList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<DocTemplate> docTemplateList = (from c in dbIM.DocTemplates.AsNoTracking() orderby c.DocTemplateID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(docTemplateList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<DocTemplate> docTemplateList = (from c in dbLocal.DocTemplates.AsNoTracking() orderby c.DocTemplateID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(docTemplateList));
            }
            else
            {
                List<DocTemplate> docTemplateList = (from c in db.DocTemplates.AsNoTracking() orderby c.DocTemplateID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(docTemplateList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int DocTemplateID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                DocTemplate docTemplate = (from c in dbIM.DocTemplates
                                   where c.DocTemplateID == DocTemplateID
                                   select c).FirstOrDefault();
            
                if (docTemplate == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", DocTemplateID.ToString())));
                }
            
                try
                {
                    dbIM.DocTemplates.Remove(docTemplate);
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
                DocTemplate docTemplate = (from c in dbLocal.DocTemplates
                                   where c.DocTemplateID == DocTemplateID
                                   select c).FirstOrDefault();
                
                if (docTemplate == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", DocTemplateID.ToString())));
                }

                try
                {
                   dbLocal.DocTemplates.Remove(docTemplate);
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
                DocTemplate docTemplate = (from c in db.DocTemplates
                                   where c.DocTemplateID == DocTemplateID
                                   select c).FirstOrDefault();
                
                if (docTemplate == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", DocTemplateID.ToString())));
                }

                try
                {
                   db.DocTemplates.Remove(docTemplate);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<DocTemplate>> Post(DocTemplate docTemplate)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DocTemplates.Add(docTemplate);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(docTemplate));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.DocTemplates.Add(docTemplate);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(docTemplate));
            }
            else
            {
                try
                {
                   db.DocTemplates.Add(docTemplate);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(docTemplate));
            }
        }
        public async Task<ActionResult<DocTemplate>> Put(DocTemplate docTemplate)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.DocTemplates.Update(docTemplate);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(docTemplate));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.DocTemplates.Update(docTemplate);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(docTemplate));
            }
            else
            {
            try
            {
               db.DocTemplates.Update(docTemplate);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(docTemplate));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            DocTemplate docTemplate = validationContext.ObjectInstance as DocTemplate;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (docTemplate.DocTemplateID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DocTemplateID"), new[] { nameof(docTemplate.DocTemplateID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.DocTemplates select c).Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString()), new[] { nameof(docTemplate.DocTemplateID) });
                    }
                }
                else
                {
                    if (!(from c in db.DocTemplates select c).Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString()), new[] { nameof(docTemplate.DocTemplateID) });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)docTemplate.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(docTemplate.Language) });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)docTemplate.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(docTemplate.TVType) });
            }

            TVItem TVItemTVFileTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemTVFileTVItemID = (from c in dbLocal.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();
                if (TVItemTVFileTVItemID == null)
                {
                    TVItemTVFileTVItemID = (from c in dbIM.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();
            }

            if (TVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVItemID", docTemplate.TVFileTVItemID.ToString()), new[] { nameof(docTemplate.TVFileTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), new[] { nameof(docTemplate.TVFileTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "FileName"), new[] { nameof(docTemplate.FileName) });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "FileName", "150"), new[] { nameof(docTemplate.FileName) });
            }

            if (docTemplate.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(docTemplate.LastUpdateDate_UTC) });
            }
            else
            {
                if (docTemplate.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(docTemplate.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", docTemplate.LastUpdateContactTVItemID.ToString()), new[] { nameof(docTemplate.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(docTemplate.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
