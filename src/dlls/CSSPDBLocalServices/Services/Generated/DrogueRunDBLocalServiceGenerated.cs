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
    public partial interface IDrogueRunDBLocalService
    {
        Task<ActionResult<bool>> Delete(int DrogueRunID);
        Task<ActionResult<List<DrogueRun>>> GetDrogueRunList(int skip = 0, int take = 100);
        Task<ActionResult<DrogueRun>> GetDrogueRunWithDrogueRunID(int DrogueRunID);
        Task<ActionResult<DrogueRun>> Post(DrogueRun droguerun);
        Task<ActionResult<DrogueRun>> Put(DrogueRun droguerun);
    }
    public partial class DrogueRunDBLocalService : ControllerBase, IDrogueRunDBLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbLocalIM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILocalService LocalService,
           CSSPDBLocalContext dbLocal,
           CSSPDBInMemoryContext dbLocalIM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLocalIM = dbLocalIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<DrogueRun>> GetDrogueRunWithDrogueRunID(int DrogueRunID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            DrogueRun drogueRun = (from c in dbLocal.DrogueRuns.AsNoTracking()
                    where c.DrogueRunID == DrogueRunID
                    select c).FirstOrDefault();

            if (drogueRun == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(drogueRun));
        }
        public async Task<ActionResult<List<DrogueRun>>> GetDrogueRunList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<DrogueRun> drogueRunList = (from c in dbLocal.DrogueRuns.AsNoTracking() orderby c.DrogueRunID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(drogueRunList));
        }
        public async Task<ActionResult<bool>> Delete(int DrogueRunID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            DrogueRun drogueRun = (from c in dbLocal.DrogueRuns.Local
                    where c.DrogueRunID == DrogueRunID
                    select c).FirstOrDefault();

            if (drogueRun == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", DrogueRunID.ToString())));
            }

            try
            {
                dbLocal.DrogueRuns.Remove(drogueRun);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<DrogueRun>> Post(DrogueRun drogueRun)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (drogueRun.DrogueRunID == 0)
            {
                int LastDrogueRunID = (from c in dbLocal.DrogueRuns.AsNoTracking()
                          orderby c.DrogueRunID descending
                          select c.DrogueRunID).FirstOrDefault();

                drogueRun.DrogueRunID = LastDrogueRunID + 1;
            }

            try
            {
                dbLocal.DrogueRuns.Add(drogueRun);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRun));
        }
        public async Task<ActionResult<DrogueRun>> Put(DrogueRun drogueRun)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.DrogueRuns.Update(drogueRun);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(drogueRun));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            DrogueRun drogueRun = validationContext.ObjectInstance as DrogueRun;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (drogueRun.DrogueRunID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueRunID"), new[] { nameof(drogueRun.DrogueRunID) });
                }

                if (!(from c in dbLocal.DrogueRuns.AsNoTracking() select c).Where(c => c.DrogueRunID == drogueRun.DrogueRunID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRun.DrogueRunID.ToString()), new[] { nameof(drogueRun.DrogueRunID) });
                }
            }

            TVItem TVItemSubsectorTVItemID = null;
            TVItemSubsectorTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                TVItemSubsectorTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();

                if (TVItemSubsectorTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", drogueRun.SubsectorTVItemID.ToString()), new[] { nameof(drogueRun.SubsectorTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Subsector,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(drogueRun.SubsectorTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { nameof(drogueRun.SubsectorTVItemID) });
                }
            }

            if (drogueRun.DrogueNumber < 0 || drogueRun.DrogueNumber > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DrogueNumber", "0", "100"), new[] { nameof(drogueRun.DrogueNumber) });
            }

            retStr = enums.EnumTypeOK(typeof(DrogueTypeEnum), (int?)drogueRun.DrogueType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DrogueType"), new[] { nameof(drogueRun.DrogueType) });
            }

            if (drogueRun.RunStartDateTime.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "RunStartDateTime"), new[] { nameof(drogueRun.RunStartDateTime) });
            }
            else
            {
                if (drogueRun.RunStartDateTime.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "RunStartDateTime", "1980"), new[] { nameof(drogueRun.RunStartDateTime) });
                }
            }

            if (drogueRun.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(drogueRun.LastUpdateDate_UTC) });
            }
            else
            {
                if (drogueRun.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(drogueRun.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRun.LastUpdateContactTVItemID.ToString()), new[] { nameof(drogueRun.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(drogueRun.LastUpdateContactTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(drogueRun.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
