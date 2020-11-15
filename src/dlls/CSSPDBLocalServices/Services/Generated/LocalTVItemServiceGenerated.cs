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
    public partial interface ILocalTVItemDBService
    {
        Task<ActionResult<bool>> Delete(int LocalTVItemID);
        Task<ActionResult<List<LocalTVItem>>> GetLocalTVItemList(int skip = 0, int take = 100);
        Task<ActionResult<LocalTVItem>> GetLocalTVItemWithTVItemID(int TVItemID);
        Task<ActionResult<LocalTVItem>> Post(LocalTVItem localtvitem);
        Task<ActionResult<LocalTVItem>> Put(LocalTVItem localtvitem);
    }
    public partial class LocalTVItemDBService : ControllerBase, ILocalTVItemDBService
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
        public LocalTVItemDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<LocalTVItem>> GetLocalTVItemWithTVItemID(int TVItemID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            LocalTVItem localTVItem = (from c in db.LocalTVItems.AsNoTracking()
                    where c.TVItemID == TVItemID
                    select c).FirstOrDefault();

            if (localTVItem == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(localTVItem));
        }
        public async Task<ActionResult<List<LocalTVItem>>> GetLocalTVItemList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<LocalTVItem> localTVItemList = (from c in db.LocalTVItems.AsNoTracking() orderby c.TVItemID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(localTVItemList));
        }
        public async Task<ActionResult<bool>> Delete(int LocalTVItemID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LocalTVItem localTVItem = (from c in db.LocalTVItems
                    where c.TVItemID == LocalTVItemID
                    select c).FirstOrDefault();

            if (localTVItem == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "LocalTVItem", "LocalTVItemID", LocalTVItemID.ToString())));
            }

            try
            {
                db.LocalTVItems.Remove(localTVItem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<LocalTVItem>> Post(LocalTVItem localTVItem)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTVItem), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTVItems.Add(localTVItem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTVItem));
        }
        public async Task<ActionResult<LocalTVItem>> Put(LocalTVItem localTVItem)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(localTVItem), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.LocalTVItems.Update(localTVItem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(localTVItem));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            LocalTVItem localTVItem = validationContext.ObjectInstance as LocalTVItem;

            retStr = enums.EnumTypeOK(typeof(LocalDBCommandEnum), (int?)localTVItem.LocalDBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LocalDBCommand"), new[] { nameof(localTVItem.LocalDBCommand) });
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (localTVItem.TVItemID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { nameof(localTVItem.TVItemID) });
                }

                if (!(from c in db.LocalTVItems.AsNoTracking() select c).Where(c => c.TVItemID == localTVItem.TVItemID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", localTVItem.TVItemID.ToString()), new[] { nameof(localTVItem.TVItemID) });
                }
            }

            if (localTVItem.TVType == TVTypeEnum.Root)
            {

                if ((from c in db.LocalTVItems select c).Count() > 0)
                {
                    yield return new ValidationResult(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { "TVItemTVItemID" });
                }
            }

            if (localTVItem.TVLevel < 0 || localTVItem.TVLevel > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TVLevel", "0", "100"), new[] { nameof(localTVItem.TVLevel) });
            }

            if (string.IsNullOrWhiteSpace(localTVItem.TVPath))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), new[] { nameof(localTVItem.TVPath) });
            }

            if (!string.IsNullOrWhiteSpace(localTVItem.TVPath) && localTVItem.TVPath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVPath", "250"), new[] { nameof(localTVItem.TVPath) });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)localTVItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(localTVItem.TVType) });
            }

            if (localTVItem.TVType != TVTypeEnum.Root)
            {
                LocalTVItem localTVItemParentID = null;
                localTVItemParentID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTVItem.ParentID select c).FirstOrDefault();

                if (localTVItemParentID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentID", localTVItem.ParentID.ToString()), new[] { nameof(localTVItem.ParentID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.RainExceedance,
                        TVTypeEnum.Classification,
                    };
                    if (!AllowableTVTypes.Contains(localTVItemParentID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification"), new[] { nameof(localTVItem.ParentID) });
                    }
                }
            }

            if (localTVItem.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(localTVItem.LastUpdateDate_UTC) });
            }
            else
            {
                if (localTVItem.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(localTVItem.LastUpdateDate_UTC) });
                }
            }

            if (localTVItem.TVType != TVTypeEnum.Root)
            {
                LocalTVItem localTVItemLastUpdateContactTVItemID = null;
                localTVItemLastUpdateContactTVItemID = (from c in db.LocalTVItems.AsNoTracking() where c.TVItemID == localTVItem.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (localTVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", localTVItem.LastUpdateContactTVItemID.ToString()), new[] { nameof(localTVItem.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(localTVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(localTVItem.LastUpdateContactTVItemID) });
                    }
                }
            }

        }
        #endregion Functions private
    }

}