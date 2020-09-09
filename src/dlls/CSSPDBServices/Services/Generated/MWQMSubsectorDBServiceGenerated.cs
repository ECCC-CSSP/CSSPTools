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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public partial interface IMWQMSubsectorDBService
    {
        Task<ActionResult<bool>> Delete(int MWQMSubsectorID);
        Task<ActionResult<List<MWQMSubsector>>> GetMWQMSubsectorList(int skip = 0, int take = 100);
        Task<ActionResult<MWQMSubsector>> GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID);
        Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmsubsector);
        Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmsubsector);
    }
    public partial class MWQMSubsectorDBService : ControllerBase, IMWQMSubsectorDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MWQMSubsector>> GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors.AsNoTracking()
                    where c.MWQMSubsectorID == MWQMSubsectorID
                    select c).FirstOrDefault();

            if (mwqmSubsector == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mwqmSubsector));
        }
        public async Task<ActionResult<List<MWQMSubsector>>> GetMWQMSubsectorList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MWQMSubsector> mwqmSubsectorList = (from c in db.MWQMSubsectors.AsNoTracking() orderby c.MWQMSubsectorID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mwqmSubsectorList));
        }
        public async Task<ActionResult<bool>> Delete(int MWQMSubsectorID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors.Local
                    where c.MWQMSubsectorID == MWQMSubsectorID
                    select c).FirstOrDefault();

            if (mwqmSubsector == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", MWQMSubsectorID.ToString())));
            }

            try
            {
                db.MWQMSubsectors.Remove(mwqmSubsector);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmSubsector)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MWQMSubsectors.Add(mwqmSubsector);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsector));
        }
        public async Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmSubsector)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.MWQMSubsectors.Update(mwqmSubsector);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mwqmSubsector));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MWQMSubsector mwqmSubsector = validationContext.ObjectInstance as MWQMSubsector;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsector.MWQMSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMSubsectorID"), new[] { nameof(mwqmSubsector.MWQMSubsectorID) });
                }

                if (!(from c in db.MWQMSubsectors.AsNoTracking() select c).Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString()), new[] { nameof(mwqmSubsector.MWQMSubsectorID) });
                }
            }

            TVItem TVItemMWQMSubsectorTVItemID = null;
            TVItemMWQMSubsectorTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorTVItemID", mwqmSubsector.MWQMSubsectorTVItemID.ToString()), new[] { nameof(mwqmSubsector.MWQMSubsectorTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MWQMSubsectorTVItemID", "Subsector"), new[] { nameof(mwqmSubsector.MWQMSubsectorTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorHistoricKey"), new[] { nameof(mwqmSubsector.SubsectorHistoricKey) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SubsectorHistoricKey", "20"), new[] { nameof(mwqmSubsector.SubsectorHistoricKey) });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TideLocationSIDText", "20"), new[] { nameof(mwqmSubsector.TideLocationSIDText) });
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mwqmSubsector.LastUpdateDate_UTC) });
            }
            else
            {
                if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mwqmSubsector.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmSubsector.LastUpdateContactTVItemID.ToString()), new[] { nameof(mwqmSubsector.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mwqmSubsector.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
