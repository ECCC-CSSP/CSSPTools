/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class HelpDocService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HelpDocService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            HelpDoc helpDoc = validationContext.ObjectInstance as HelpDoc;
            helpDoc.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (helpDoc.HelpDocID == 0)
                {
                    helpDoc.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HelpDocID"), new[] { "HelpDocID" });
                }

                if (!(from c in db.HelpDocs select c).Where(c => c.HelpDocID == helpDoc.HelpDocID).Any())
                {
                    helpDoc.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), new[] { "HelpDocID" });
                }
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocKey))
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocKey"), new[] { "DocKey" });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocKey) && helpDoc.DocKey.Length > 100)
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DocKey", "100"), new[] { "DocKey" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDoc.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocHTMLText))
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocHTMLText"), new[] { "DocHTMLText" });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocHTMLText) && helpDoc.DocHTMLText.Length > 100000)
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DocHTMLText", "100000"), new[] { "DocHTMLText" });
            }

            if (helpDoc.LastUpdateDate_UTC.Year == 1)
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (helpDoc.LastUpdateDate_UTC.Year < 1980)
                {
                helpDoc.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == helpDoc.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                helpDoc.HasErrors = true;
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
                    helpDoc.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                helpDoc.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HelpDoc GetHelpDocWithHelpDocID(int HelpDocID)
        {
            return (from c in db.HelpDocs
                    where c.HelpDocID == HelpDocID
                    select c).FirstOrDefault();

        }
        public IQueryable<HelpDoc> GetHelpDocList()
        {
            IQueryable<HelpDoc> HelpDocQuery = (from c in db.HelpDocs select c);

            HelpDocQuery = EnhanceQueryStatements<HelpDoc>(HelpDocQuery) as IQueryable<HelpDoc>;

            return HelpDocQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(HelpDoc helpDoc)
        {
            helpDoc.ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Create);
            if (helpDoc.ValidationResults.Count() > 0) return false;

            db.HelpDocs.Add(helpDoc);

            if (!TryToSave(helpDoc)) return false;

            return true;
        }
        public bool Delete(HelpDoc helpDoc)
        {
            helpDoc.ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Delete);
            if (helpDoc.ValidationResults.Count() > 0) return false;

            db.HelpDocs.Remove(helpDoc);

            if (!TryToSave(helpDoc)) return false;

            return true;
        }
        public bool Update(HelpDoc helpDoc)
        {
            helpDoc.ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Update);
            if (helpDoc.ValidationResults.Count() > 0) return false;

            db.HelpDocs.Update(helpDoc);

            if (!TryToSave(helpDoc)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(HelpDoc helpDoc)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                helpDoc.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
