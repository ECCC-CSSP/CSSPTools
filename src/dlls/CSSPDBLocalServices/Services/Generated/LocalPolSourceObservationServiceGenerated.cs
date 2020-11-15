/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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

namespace CSSPDBLocalServices
{
    public partial interface ILocalPolSourceObservationDBService
    {
        Task<ActionResult<bool>> Delete(int LocalPolSourceObservationID);
        Task<ActionResult<List<LocalPolSourceObservation>>> GetLocalPolSourceObservationList(int skip = 0, int take = 100);
        Task<ActionResult<LocalPolSourceObservation>> GetLocalPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID);
        Task<ActionResult<LocalPolSourceObservation>> Post(LocalPolSourceObservation localpolsourceobservation);
        Task<ActionResult<LocalPolSourceObservation>> Put(LocalPolSourceObservation localpolsourceobservation);
    }
    public partial class LocalPolSourceObservationDBService : ControllerBase, ILocalPolSourceObservationDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalPolSourceObservationDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<LocalPolSourceObservation>> GetLocalPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalPolSourceObservation localPolSourceObservation = (from c in db.LocalPolSourceObservations.AsNoTracking()
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

            if (localPolSourceObservation == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localPolSourceObservation));
        }
        public async Task<ActionResult<List<LocalPolSourceObservation>>> GetLocalPolSourceObservationList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalPolSourceObservation> localPolSourceObservationList = (from c in db.LocalPolSourceObservations.AsNoTracking() orderby c.PolSourceObservationID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localPolSourceObservationList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalPolSourceObservationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalPolSourceObservation localPolSourceObservation = (from c in db.LocalPolSourceObservations
                    where c.PolSourceObservationID == LocalPolSourceObservationID
                    select c).FirstOrDefault();

            if (localPolSourceObservation == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalPolSourceObservation", "LocalPolSourceObservationID", LocalPolSourceObservationID.ToString())));
            }

            try
            {
                db.LocalPolSourceObservations.Remove(localPolSourceObservation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalPolSourceObservation>> Post(LocalPolSourceObservation localPolSourceObservation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localPolSourceObservation), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalPolSourceObservations.Add(localPolSourceObservation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localPolSourceObservation));
        }
        public async Task<ActionResult<LocalPolSourceObservation>> Put(LocalPolSourceObservation localPolSourceObservation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localPolSourceObservation), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalPolSourceObservations.Update(localPolSourceObservation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localPolSourceObservation));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalPolSourceObservation localPolSourceObservation = validationContext.ObjectInstance as LocalPolSourceObservation;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localPolSourceObservation.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localPolSourceObservation.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localPolSourceObservation.PolSourceObservationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObservationID"), new[] { nameof(localPolSourceObservation.PolSourceObservationID) });
                }

                if (!(from c in db.LocalPolSourceObservations.AsNoTracking() select c).Where(c => c.PolSourceObservationID == localPolSourceObservation.PolSourceObservationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", localPolSourceObservation.PolSourceObservationID.ToString()), new[] { nameof(localPolSourceObservation.PolSourceObservationID) });
                }
            }

            LocalPolSourceSite localPolSourceSitePolSourceSiteID = null;
            localPolSourceSitePolSourceSiteID = (from c in db.LocalPolSourceSites.AsNoTracking() where c.PolSourceSiteID == localPolSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (localPolSourceSitePolSourceSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalPolSourceSite", "PolSourceSiteID", localPolSourceObservation.PolSourceSiteID.ToString()), new[] { nameof(localPolSourceObservation.PolSourceSiteID) });
            }

            if (localPolSourceObservation.ObservationDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ObservationDate_Local"), new[] { nameof(localPolSourceObservation.ObservationDate_Local) });
            }
            else
            {
                if (localPolSourceObservation.ObservationDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), new[] { nameof(localPolSourceObservation.ObservationDate_Local) });
                }
            }

            LocalTVItem localTVItemContactTVItemID = null;
            localTVItemContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (localTVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "ContactTVItemID", localPolSourceObservation.ContactTVItemID.ToString()), new[] { nameof(localPolSourceObservation.ContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { nameof(localPolSourceObservation.ContactTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(localPolSourceObservation.Observation_ToBeDeleted))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Observation_ToBeDeleted"), new[] { nameof(localPolSourceObservation.Observation_ToBeDeleted) });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (localPolSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localPolSourceObservation.LastUpdateDate_UTC) });
            }
            else
            {
                if (localPolSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localPolSourceObservation.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localPolSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localPolSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { nameof(localPolSourceObservation.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localPolSourceObservation.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}