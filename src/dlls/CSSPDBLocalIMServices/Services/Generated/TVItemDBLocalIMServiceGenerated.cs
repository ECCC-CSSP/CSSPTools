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
    public partial interface ITVItemDBLocalIMService
    {
        Task<ActionResult<bool>> Delete(int TVItemID);
        Task<ActionResult<List<TVItem>>> GetTVItemList(int skip = 0, int take = 100);
        Task<ActionResult<TVItem>> GetTVItemWithTVItemID(int TVItemID);
        Task<ActionResult<TVItem>> Post(TVItem tvitem);
        Task<ActionResult<TVItem>> Put(TVItem tvitem);
    }
    public partial class TVItemDBLocalIMService : ControllerBase, ITVItemDBLocalIMService
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
        public TVItemDBLocalIMService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<TVItem>> GetTVItemWithTVItemID(int TVItemID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            TVItem tvItem = (from c in dbLocalIM.TVItems.AsNoTracking()
                    where c.TVItemID == TVItemID
                    select c).FirstOrDefault();

            if (tvItem == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(tvItem));
        }
        public async Task<ActionResult<List<TVItem>>> GetTVItemList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<TVItem> tvItemList = (from c in dbLocalIM.TVItems.AsNoTracking() orderby c.TVItemID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(tvItemList));
        }
        public async Task<ActionResult<bool>> Delete(int TVItemID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = (from c in dbLocalIM.TVItems
                    where c.TVItemID == TVItemID
                    select c).FirstOrDefault();

            if (tvItem == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", TVItemID.ToString())));
            }

            try
            {
                dbLocalIM.TVItems.Remove(tvItem);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<TVItem>> Post(TVItem tvItem)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.TVItems.Add(tvItem);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItem));
        }
        public async Task<ActionResult<TVItem>> Put(TVItem tvItem)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocalIM.TVItems.Update(tvItem);
                dbLocalIM.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(tvItem));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            TVItem tvItem = validationContext.ObjectInstance as TVItem;

            if (actionDBType == ActionDBTypeEnum.Create)
            {
                if (tvItem.TVItemID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { nameof(tvItem.TVItemID) });
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItem.TVItemID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { nameof(tvItem.TVItemID) });
                }

                if (!(from c in dbLocalIM.TVItems select c).Where(c => c.TVItemID == tvItem.TVItemID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItem.TVItemID.ToString()), new[] { nameof(tvItem.TVItemID) });
                }
            }

            if (tvItem.TVType == TVTypeEnum.Root)
            {

                if ((from c in dbLocalIM.TVItems select c).Count() > 0)
                {
                    yield return new ValidationResult(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { "TVItemTVItemID" });
                }
            }

            if (tvItem.TVLevel < 0 || tvItem.TVLevel > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "TVLevel", "0", "100"), new[] { nameof(tvItem.TVLevel) });
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), new[] { nameof(tvItem.TVPath) });
            }

            if (!string.IsNullOrWhiteSpace(tvItem.TVPath) && tvItem.TVPath.Length > 250)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVPath", "250"), new[] { nameof(tvItem.TVPath) });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(tvItem.TVType) });
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemParentID = null;
                TVItemParentID = (from c in dbLocalIM.TVItems where c.TVItemID == tvItem.ParentID select c).FirstOrDefault();

                if (TVItemParentID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentID", tvItem.ParentID.ToString()), new[] { nameof(tvItem.ParentID) });
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
                    if (!AllowableTVTypes.Contains(TVItemParentID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification"), new[] { nameof(tvItem.ParentID) });
                    }
                }
            }

            if (tvItem.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(tvItem.LastUpdateDate_UTC) });
            }
            else
            {
                if (tvItem.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(tvItem.LastUpdateDate_UTC) });
                }
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemLastUpdateContactTVItemID = null;
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems where c.TVItemID == tvItem.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItem.LastUpdateContactTVItemID.ToString()), new[] { nameof(tvItem.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(tvItem.LastUpdateContactTVItemID) });
                    }
                }
            }

        }
        #endregion Functions private
    }

}
