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
    public partial interface ILocalDrogueRunPositionDBService
    {
        Task<ActionResult<bool>> Delete(int LocalDrogueRunPositionID);
        Task<ActionResult<List<LocalDrogueRunPosition>>> GetLocalDrogueRunPositionList(int skip = 0, int take = 100);
        Task<ActionResult<LocalDrogueRunPosition>> GetLocalDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID);
        Task<ActionResult<LocalDrogueRunPosition>> Post(LocalDrogueRunPosition localdroguerunposition);
        Task<ActionResult<LocalDrogueRunPosition>> Put(LocalDrogueRunPosition localdroguerunposition);
    }
    public partial class LocalDrogueRunPositionDBService : ControllerBase, ILocalDrogueRunPositionDBService
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
        public LocalDrogueRunPositionDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalDrogueRunPosition>> GetLocalDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalDrogueRunPosition localDrogueRunPosition = (from c in db.LocalDrogueRunPositions.AsNoTracking()
                    where c.DrogueRunPositionID == DrogueRunPositionID
                    select c).FirstOrDefault();

            if (localDrogueRunPosition == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localDrogueRunPosition));
        }
        public async Task<ActionResult<List<LocalDrogueRunPosition>>> GetLocalDrogueRunPositionList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalDrogueRunPosition> localDrogueRunPositionList = (from c in db.LocalDrogueRunPositions.AsNoTracking() orderby c.DrogueRunPositionID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localDrogueRunPositionList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalDrogueRunPositionID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalDrogueRunPosition localDrogueRunPosition = (from c in db.LocalDrogueRunPositions
                    where c.DrogueRunPositionID == LocalDrogueRunPositionID
                    select c).FirstOrDefault();

            if (localDrogueRunPosition == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalDrogueRunPosition", "LocalDrogueRunPositionID", LocalDrogueRunPositionID.ToString())));
            }

            try
            {
                db.LocalDrogueRunPositions.Remove(localDrogueRunPosition);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalDrogueRunPosition>> Post(LocalDrogueRunPosition localDrogueRunPosition)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localDrogueRunPosition), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalDrogueRunPositions.Add(localDrogueRunPosition);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localDrogueRunPosition));
        }
        public async Task<ActionResult<LocalDrogueRunPosition>> Put(LocalDrogueRunPosition localDrogueRunPosition)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localDrogueRunPosition), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalDrogueRunPositions.Update(localDrogueRunPosition);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localDrogueRunPosition));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalDrogueRunPosition localDrogueRunPosition = validationContext.ObjectInstance as LocalDrogueRunPosition;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localDrogueRunPosition.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localDrogueRunPosition.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localDrogueRunPosition.DrogueRunPositionID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueRunPositionID"), new[] { nameof(localDrogueRunPosition.DrogueRunPositionID) });
                }

                if (!(from c in db.LocalDrogueRunPositions.AsNoTracking() select c).Where(c => c.DrogueRunPositionID == localDrogueRunPosition.DrogueRunPositionID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", localDrogueRunPosition.DrogueRunPositionID.ToString()), new[] { nameof(localDrogueRunPosition.DrogueRunPositionID) });
                }
            }

            LocalDrogueRun localDrogueRunDrogueRunID = null;
            localDrogueRunDrogueRunID = (from c in db.LocalDrogueRuns.AsNoTracking() where c.DrogueRunID == localDrogueRunPosition.DrogueRunID select c).FirstOrDefault();

            if (localDrogueRunDrogueRunID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalDrogueRun", "DrogueRunID", localDrogueRunPosition.DrogueRunID.ToString()), new[] { nameof(localDrogueRunPosition.DrogueRunID) });
            }

            if (localDrogueRunPosition.Ordinal < 0 || localDrogueRunPosition.Ordinal > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "100000"), new[] { nameof(localDrogueRunPosition.Ordinal) });
            }

            if (localDrogueRunPosition.StepLat < -180 || localDrogueRunPosition.StepLat > 180)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StepLat", "-180", "180"), new[] { nameof(localDrogueRunPosition.StepLat) });
            }

            if (localDrogueRunPosition.StepLng < -90 || localDrogueRunPosition.StepLng > 90)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "StepLng", "-90", "90"), new[] { nameof(localDrogueRunPosition.StepLng) });
            }

            if (localDrogueRunPosition.StepDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StepDateTime_Local"), new[] { nameof(localDrogueRunPosition.StepDateTime_Local) });
            }
            else
            {
                if (localDrogueRunPosition.StepDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StepDateTime_Local", "1980"), new[] { nameof(localDrogueRunPosition.StepDateTime_Local) });
                }
            }

            if (localDrogueRunPosition.CalculatedSpeed_m_s < 0 || localDrogueRunPosition.CalculatedSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CalculatedSpeed_m_s", "0", "10"), new[] { nameof(localDrogueRunPosition.CalculatedSpeed_m_s) });
            }

            if (localDrogueRunPosition.CalculatedDirection_deg < 0 || localDrogueRunPosition.CalculatedDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CalculatedDirection_deg", "0", "360"), new[] { nameof(localDrogueRunPosition.CalculatedDirection_deg) });
            }

            if (localDrogueRunPosition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localDrogueRunPosition.LastUpdateDate_UTC) });
            }
            else
            {
                if (localDrogueRunPosition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localDrogueRunPosition.LastUpdateDate_UTC) });
                }
            }

            LocalTVItem localTVItemLastUpdateContactTVItemID = null;
            localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localDrogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (localTVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LastUpdateContactTVItemID", localDrogueRunPosition.LastUpdateContactTVItemID.ToString()), new[] { nameof(localDrogueRunPosition.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localDrogueRunPosition.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
