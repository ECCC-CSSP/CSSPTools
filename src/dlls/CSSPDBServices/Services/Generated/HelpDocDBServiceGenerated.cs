/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IHelpDocDBService
    {
        Task<ActionResult<bool>> Delete(int HelpDocID);
        Task<ActionResult<List<HelpDoc>>> GetHelpDocList(int skip = 0, int take = 100);
        Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID);
        Task<ActionResult<HelpDoc>> Post(HelpDoc helpdoc);
        Task<ActionResult<HelpDoc>> Put(HelpDoc helpdoc);
    }
    public partial class HelpDocDBService : ControllerBase, IHelpDocDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<HelpDoc>> GetHelpDocWithHelpDocID(int HelpDocID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            HelpDoc helpDoc = (from c in db.HelpDocs.AsNoTracking()
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
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<HelpDoc> helpDocList = (from c in db.HelpDocs.AsNoTracking() orderby c.HelpDocID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(helpDocList));
        }
        public async Task<ActionResult<bool>> Delete(int HelpDocID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            HelpDoc helpDoc = (from c in db.HelpDocs
                    where c.HelpDocID == HelpDocID
                    select c).FirstOrDefault();

            if (helpDoc == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", HelpDocID.ToString())));
            }

            try
            {
                db.HelpDocs.Remove(helpDoc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<HelpDoc>> Post(HelpDoc helpDoc)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Create))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.HelpDocs.Add(helpDoc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        public async Task<ActionResult<HelpDoc>> Put(HelpDoc helpDoc)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!Validate(new ValidationContext(helpDoc), ActionDBTypeEnum.Update))
            {
                return await Task.FromResult(BadRequest(ValidationResultList));
            }

            try
            {
                db.HelpDocs.Update(helpDoc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(helpDoc));
        }
        #endregion Functions public

        #region Functions private
        private bool Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            HelpDoc helpDoc = validationContext.ObjectInstance as HelpDoc;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (helpDoc.HelpDocID == 0)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), new[] { nameof(helpDoc.HelpDocID) }));
                }

                if (!(from c in db.HelpDocs.AsNoTracking() select c).Where(c => c.HelpDocID == helpDoc.HelpDocID).Any())
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), new[] { nameof(helpDoc.HelpDocID) }));
                }
            }

            retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)helpDoc.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { nameof(helpDoc.DBCommand) }));
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocKey))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), new[] { nameof(helpDoc.DocKey) }));
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocKey) && helpDoc.DocKey.Length > 100)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "DocKey", "100"), new[] { nameof(helpDoc.DocKey) }));
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)helpDoc.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(helpDoc.Language) }));
            }

            if (string.IsNullOrWhiteSpace(helpDoc.DocHTMLText))
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), new[] { nameof(helpDoc.DocHTMLText) }));
            }

            if (!string.IsNullOrWhiteSpace(helpDoc.DocHTMLText) && helpDoc.DocHTMLText.Length > 100000)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "DocHTMLText", "100000"), new[] { nameof(helpDoc.DocHTMLText) }));
            }

            if (helpDoc.LastUpdateDate_UTC.Year == 1)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(helpDoc.LastUpdateDate_UTC) }));
            }
            else
            {
                if (helpDoc.LastUpdateDate_UTC.Year < 1980)
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(helpDoc.LastUpdateDate_UTC) }));
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == helpDoc.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", helpDoc.LastUpdateContactTVItemID.ToString()), new[] { nameof(helpDoc.LastUpdateContactTVItemID)}));
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(helpDoc.LastUpdateContactTVItemID) }));
                }
            }

            return ValidationResultList.Count == 0 ? true : false;
        }
        #endregion Functions private
    }

}
