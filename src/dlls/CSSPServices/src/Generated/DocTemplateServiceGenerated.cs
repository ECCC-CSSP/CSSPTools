/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IDocTemplateService
    {
       Task<ActionResult<DocTemplate>> GetDocTemplateWithDocTemplateID(int DocTemplateID);
       Task<ActionResult<List<DocTemplate>>> GetDocTemplateList();
       Task<ActionResult<DocTemplate>> Add(DocTemplate doctemplate);
       Task<ActionResult<DocTemplate>> Delete(DocTemplate doctemplate);
       Task<ActionResult<DocTemplate>> Update(DocTemplate doctemplate);
       Task SetCulture(CultureInfo culture);
    }
    public partial class DocTemplateService : ControllerBase, IDocTemplateService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<DocTemplate>> GetDocTemplateWithDocTemplateID(int DocTemplateID)
        {
            DocTemplate doctemplate = (from c in db.DocTemplates.AsNoTracking()
                    where c.DocTemplateID == DocTemplateID
                    select c).FirstOrDefault();

            if (doctemplate == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(doctemplate));
        }
        public async Task<ActionResult<List<DocTemplate>>> GetDocTemplateList()
        {
            List<DocTemplate> doctemplateList = (from c in db.DocTemplates.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(doctemplateList));
        }
        public async Task<ActionResult<DocTemplate>> Add(DocTemplate docTemplate)
        {
            ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task<ActionResult<DocTemplate>> Delete(DocTemplate docTemplate)
        {
            ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
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

            return await Task.FromResult(Ok(docTemplate));
        }
        public async Task<ActionResult<DocTemplate>> Update(DocTemplate docTemplate)
        {
            ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

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
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateID"), new[] { "DocTemplateID" });
                }

                if (!(from c in db.DocTemplates select c).Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString()), new[] { "DocTemplateID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)docTemplate.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)docTemplate.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVItemID", docTemplate.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileName"), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "FileName", "150"), new[] { "FileName" });
            }

            if (docTemplate.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (docTemplate.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", docTemplate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
