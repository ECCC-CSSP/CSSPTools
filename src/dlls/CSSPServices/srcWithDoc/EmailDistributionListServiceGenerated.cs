/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
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
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [EmailDistributionListController](CSSPWebAPI.Controllers.EmailDistributionListController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.EmailDistributionList](CSSPModels.EmailDistributionList.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class EmailDistributionListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB EmailDistributionLists table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public EmailDistributionListService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all EmailDistributionListService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionList emailDistributionList = validationContext.ObjectInstance as EmailDistributionList;
            emailDistributionList.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionList.EmailDistributionListID == 0)
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListID"), new[] { "EmailDistributionListID" });
                }

                if (!(from c in db.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
                }
            }

            TVItem TVItemParentTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.ParentTVItemID select c).FirstOrDefault();

            if (TVItemParentTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentTVItemID", emailDistributionList.ParentTVItemID.ToString()), new[] { "ParentTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemParentTVItemID.TVType))
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ParentTVItemID", "Country"), new[] { "ParentTVItemID" });
                }
            }

            if (emailDistributionList.Ordinal < 0 || emailDistributionList.Ordinal > 1000)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (emailDistributionList.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionList.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", emailDistributionList.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the EmailDistributionList model with the EmailDistributionListID identifier
        /// </summary>
        /// <param name="EmailDistributionListID">Is the identifier of [EmailDistributionLists](CSSPModels.EmailDistributionList.html) table of CSSPDB</param>
        /// <returns>[EmailDistributionList](CSSPModels.EmailDistributionList.html) object connected to the CSSPDB</returns>
        public EmailDistributionList GetEmailDistributionListWithEmailDistributionListID(int EmailDistributionListID)
        {
            return (from c in db.EmailDistributionLists
                    where c.EmailDistributionListID == EmailDistributionListID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [EmailDistributionList](CSSPModels.EmailDistributionList.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [EmailDistributionList](CSSPModels.EmailDistributionList.html)</returns>
        public IQueryable<EmailDistributionList> GetEmailDistributionListList()
        {
            IQueryable<EmailDistributionList> EmailDistributionListQuery = (from c in db.EmailDistributionLists select c);

            EmailDistributionListQuery = EnhanceQueryStatements<EmailDistributionList>(EmailDistributionListQuery) as IQueryable<EmailDistributionList>;

            return EmailDistributionListQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [EmailDistributionList](CSSPModels.EmailDistributionList.html) item in CSSPDB
        /// </summary>
        /// <param name="emailDistributionList">Is the EmailDistributionList item the client want to add to CSSPDB</param>
        /// <returns>true if EmailDistributionList item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Create);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Add(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [EmailDistributionList](CSSPModels.EmailDistributionList.html) item in CSSPDB
        /// </summary>
        /// <param name="emailDistributionList">Is the EmailDistributionList item the client want to add to CSSPDB. What's important here is the EmailDistributionListID</param>
        /// <returns>true if EmailDistributionList item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Delete);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Remove(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [EmailDistributionList](CSSPModels.EmailDistributionList.html) item in CSSPDB
        /// </summary>
        /// <param name="emailDistributionList">Is the EmailDistributionList item the client want to add to CSSPDB. What's important here is the EmailDistributionListID</param>
        /// <returns>true if EmailDistributionList item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Update);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Update(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [EmailDistributionList](CSSPModels.EmailDistributionList.html) item
        /// </summary>
        /// <param name="emailDistributionList">Is the EmailDistributionList item the client want to add to CSSPDB. What's important here is the EmailDistributionListID</param>
        /// <returns>true if EmailDistributionList item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(EmailDistributionList emailDistributionList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionList.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
