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
   public interface IHelpDocService
    {
       Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID);
       Task<ActionResult<List<HelpDoc>>> GetHelpDocList();
       Task<ActionResult<HelpDoc>> Add(HelpDoc helpdoc);
       Task<ActionResult<HelpDoc>> Delete(HelpDoc helpdoc);
       Task<ActionResult<HelpDoc>> Update(HelpDoc helpdoc);
       Task SetCulture(CultureInfo culture);
    }
    public partial class HelpDocService : ControllerBase, IHelpDocService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID)
        {
            HelpDoc helpdoc = (from c in db.HelpDocs.AsNoTracking()
                    where c.HelpDocID == HelpDocID
                    select c).FirstOrDefault();

            if (helpdoc == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(helpdoc));
        }
        public async Task<ActionResult<List<HelpDoc>>> GetHelpDocList()
        {
            List<HelpDoc> helpdocList = (from c in db.HelpDocs.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(helpdocList));
        }
        public async Task<ActionResult<HelpDoc>> Add(HelpDoc helpDoc)
        {
            ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.HelpDocs.Add(helpDoc);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        public async Task<ActionResult<HelpDoc>> Delete(HelpDoc helpDoc)
        {
            ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Delete);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.HelpDocs.Remove(helpDoc);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        public async Task<ActionResult<HelpDoc>> Update(HelpDoc helpDoc)
        {
            ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.HelpDocs.Update(helpDoc);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
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
            HelpDoc helpDoc = validationContext.ObjectInstance as HelpDoc;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (helpDoc.HelpDocID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HelpDocID"), new[] { "HelpDocID" });
                }

                if (!(from c in db.HelpDocs select c).Where(c => c.HelpDocID == helpDoc.HelpDocID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), new[] { "HelpDocID" });
                }
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocKey))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocKey"), new[] { "DocKey" });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocKey) && helpDoc.DocKey.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DocKey", "100"), new[] { "DocKey" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDoc.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocHTMLText))
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocHTMLText"), new[] { "DocHTMLText" });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocHTMLText) && helpDoc.DocHTMLText.Length > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DocHTMLText", "100000"), new[] { "DocHTMLText" });
            }

            if (helpDoc.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (helpDoc.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == helpDoc.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", helpDoc.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
