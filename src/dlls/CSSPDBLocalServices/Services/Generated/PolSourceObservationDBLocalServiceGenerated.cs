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

namespace CSSPDBLocalServices
{
    public partial interface IPolSourceObservationDBLocalService
    {
        Task<ActionResult<bool>> Delete(int PolSourceObservationID);
        Task<ActionResult<List<PolSourceObservation>>> GetPolSourceObservationList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID);
        Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polsourceobservation);
        Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polsourceobservation);
    }
    public partial class PolSourceObservationDBLocalService : ControllerBase, IPolSourceObservationDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PolSourceObservation>> GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            PolSourceObservation polSourceObservation = (from c in dbLocal.PolSourceObservations.AsNoTracking()
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

            if (polSourceObservation == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceObservation));
        }
        public async Task<ActionResult<List<PolSourceObservation>>> GetPolSourceObservationList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<PolSourceObservation> polSourceObservationList = (from c in dbLocal.PolSourceObservations.AsNoTracking() orderby c.PolSourceObservationID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceObservationList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceObservation polSourceObservation = (from c in dbLocal.PolSourceObservations
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

            if (polSourceObservation == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", PolSourceObservationID.ToString())));
            }

            try
            {
                dbLocal.PolSourceObservations.Remove(polSourceObservation);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polSourceObservation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (polSourceObservation.PolSourceObservationID == 0)
            {
                int LastPolSourceObservationID = (from c in dbLocal.PolSourceObservations
                          orderby c.PolSourceObservationID descending
                          select c.PolSourceObservationID).FirstOrDefault();

                polSourceObservation.PolSourceObservationID = LastPolSourceObservationID + 1;
            }

            try
            {
                dbLocal.PolSourceObservations.Add(polSourceObservation);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservation));
        }
        public async Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polSourceObservation)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.PolSourceObservations.Update(polSourceObservation);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceObservation));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceObservationID"), new[] { nameof(polSourceObservation.PolSourceObservationID) });
                }

                if (!(from c in dbLocal.PolSourceObservations select c).Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), new[] { nameof(polSourceObservation.PolSourceObservationID) });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = null;
            PolSourceSitePolSourceSiteID = (from c in dbLocal.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), new[] { nameof(polSourceObservation.PolSourceSiteID) });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ObservationDate_Local"), new[] { nameof(polSourceObservation.ObservationDate_Local) });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), new[] { nameof(polSourceObservation.ObservationDate_Local) });
                }
            }

            TVItem TVItemContactTVItemID = null;
            TVItemContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), new[] { nameof(polSourceObservation.ContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { nameof(polSourceObservation.ContactTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Observation_ToBeDeleted"), new[] { nameof(polSourceObservation.Observation_ToBeDeleted) });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceObservation.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceObservation.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceObservation.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceObservation.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
