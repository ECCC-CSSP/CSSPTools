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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalIMServices
{
    public partial interface IHelpDocDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int HelpDocID);
        Task<ActionResult<List<HelpDoc>>> GetHelpDocList(int skip = 0, int take = 100);
        Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID);
        Task<ActionResult<HelpDoc>> Post(HelpDoc helpdoc);
        Task<ActionResult<HelpDoc>> Put(HelpDoc helpdoc);
    }
    public partial class HelpDocDBLocalIMService : ControllerBase, IHelpDocDBLocalIMService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            HelpDoc helpDoc = (from c in dbLocalIM.HelpDocs.AsNoTracking()
                    where c.HelpDocID == HelpDocID
                    select c).FirstOrDefault();

            if (helpDoc == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        public async Task<ActionResult<List<HelpDoc>>> GetHelpDocList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<HelpDoc> helpDocList = (from c in dbLocalIM.HelpDocs.AsNoTracking() orderby c.HelpDocID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(helpDocList));
        }
        public async Task<ActionResult<bool>> Delete(int HelpDocID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            HelpDoc helpDoc = (from c in dbLocalIM.HelpDocs
                    where c.HelpDocID == HelpDocID
                    select c).FirstOrDefault();

            if (helpDoc == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", HelpDocID.ToString())));
            }

            try
            {
                dbLocalIM.HelpDocs.Remove(helpDoc);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<HelpDoc>> Post(HelpDoc helpDoc)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.HelpDocs.Add(helpDoc);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        public async Task<ActionResult<HelpDoc>> Put(HelpDoc helpDoc)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.HelpDocs.Update(helpDoc);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            HelpDoc helpDoc = validationContext.ObjectInstance as HelpDoc;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (helpDoc.HelpDocID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), new[] { nameof(helpDoc.HelpDocID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (helpDoc.HelpDocID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), new[] { nameof(helpDoc.HelpDocID) });
                }

                if (!(from c in dbLocalIM.HelpDocs select c).Where(c => c.HelpDocID == helpDoc.HelpDocID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), new[] { nameof(helpDoc.HelpDocID) });
                }
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocKey))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), new[] { nameof(helpDoc.DocKey) });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocKey) && helpDoc.DocKey.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "DocKey", "100"), new[] { nameof(helpDoc.DocKey) });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDoc.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(helpDoc.Language) });
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocHTMLText))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), new[] { nameof(helpDoc.DocHTMLText) });
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocHTMLText) && helpDoc.DocHTMLText.Length > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "DocHTMLText", "100000"), new[] { nameof(helpDoc.DocHTMLText) });
            }

            if (helpDoc.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(helpDoc.LastUpdateDate_UTC) });
            }
            else
            {
                if (helpDoc.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(helpDoc.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == helpDoc.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", helpDoc.LastUpdateContactTVItemID.ToString()), new[] { nameof(helpDoc.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(helpDoc.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
