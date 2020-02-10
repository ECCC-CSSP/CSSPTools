/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ClassName]ServiceGenerated.cs] button
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
    public partial class PolSourceSiteEffectTermService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = validationContext.ObjectInstance as PolSourceSiteEffectTerm;
            polSourceSiteEffectTerm.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffectTerm.PolSourceSiteEffectTermID == 0)
                {
                    polSourceSiteEffectTerm.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteEffectTermID"), new[] { "PolSourceSiteEffectTermID" });
                }

                if (!(from c in db.PolSourceSiteEffectTerms select c).Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.PolSourceSiteEffectTermID).Any())
                {
                    polSourceSiteEffectTerm.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "PolSourceSiteEffectTermID", polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), new[] { "PolSourceSiteEffectTermID" });
                }
            }

            if (polSourceSiteEffectTerm.UnderGroupID != null)
            {
                PolSourceSiteEffectTerm PolSourceSiteEffectTermUnderGroupID = (from c in db.PolSourceSiteEffectTerms where c.PolSourceSiteEffectTermID == polSourceSiteEffectTerm.UnderGroupID select c).FirstOrDefault();

                if (PolSourceSiteEffectTermUnderGroupID == null)
                {
                    polSourceSiteEffectTerm.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffectTerm", "UnderGroupID", (polSourceSiteEffectTerm.UnderGroupID == null ? "" : polSourceSiteEffectTerm.UnderGroupID.ToString())), new[] { "UnderGroupID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN))
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EffectTermEN"), new[] { "EffectTermEN" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermEN) && polSourceSiteEffectTerm.EffectTermEN.Length > 100)
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "EffectTermEN", "100"), new[] { "EffectTermEN" });
            }

            if (string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR))
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EffectTermFR"), new[] { "EffectTermFR" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTerm.EffectTermFR) && polSourceSiteEffectTerm.EffectTermFR.Length > 100)
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "EffectTermFR", "100"), new[] { "EffectTermFR" });
            }

            if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year == 1)
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceSiteEffectTerm.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceSiteEffectTerm.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffectTerm.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffectTerm.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceSiteEffectTerm.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceSiteEffectTerm.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceSiteEffectTerm GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(int PolSourceSiteEffectTermID)
        {
            return (from c in db.PolSourceSiteEffectTerms
                    where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceSiteEffectTerm> GetPolSourceSiteEffectTermList()
        {
            IQueryable<PolSourceSiteEffectTerm> PolSourceSiteEffectTermQuery = (from c in db.PolSourceSiteEffectTerms select c);

            PolSourceSiteEffectTermQuery = EnhanceQueryStatements<PolSourceSiteEffectTerm>(PolSourceSiteEffectTermQuery) as IQueryable<PolSourceSiteEffectTerm>;

            return PolSourceSiteEffectTermQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            polSourceSiteEffectTerm.ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Create);
            if (polSourceSiteEffectTerm.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTerm);

            if (!TryToSave(polSourceSiteEffectTerm)) return false;

            return true;
        }
        public bool Delete(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            polSourceSiteEffectTerm.ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Delete);
            if (polSourceSiteEffectTerm.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTerm);

            if (!TryToSave(polSourceSiteEffectTerm)) return false;

            return true;
        }
        public bool Update(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            polSourceSiteEffectTerm.ValidationResults = Validate(new ValidationContext(polSourceSiteEffectTerm), ActionDBTypeEnum.Update);
            if (polSourceSiteEffectTerm.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffectTerms.Update(polSourceSiteEffectTerm);

            if (!TryToSave(polSourceSiteEffectTerm)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceSiteEffectTerm.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
