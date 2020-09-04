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
    public partial interface IMikeBoundaryConditionDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID);
        Task<ActionResult<List<MikeBoundaryCondition>>> GetMikeBoundaryConditionList(int skip = 0, int take = 100);
        Task<ActionResult<MikeBoundaryCondition>> GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID);
        Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeboundarycondition);
        Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeboundarycondition);
    }
    public partial class MikeBoundaryConditionDBLocalService : ControllerBase, IMikeBoundaryConditionDBLocalService
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
        public MikeBoundaryConditionDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MikeBoundaryCondition>> GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MikeBoundaryCondition mikeBoundaryCondition = (from c in dbLocal.MikeBoundaryConditions.AsNoTracking()
                    where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                    select c).FirstOrDefault();

            if (mikeBoundaryCondition == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeBoundaryCondition));
        }
        public async Task<ActionResult<List<MikeBoundaryCondition>>> GetMikeBoundaryConditionList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MikeBoundaryCondition> mikeBoundaryConditionList = (from c in dbLocal.MikeBoundaryConditions.AsNoTracking() orderby c.MikeBoundaryConditionID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeBoundaryConditionList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MikeBoundaryCondition mikeBoundaryCondition = (from c in dbLocal.MikeBoundaryConditions
                    where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                    select c).FirstOrDefault();

            if (mikeBoundaryCondition == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", MikeBoundaryConditionID.ToString())));
            }

            try
            {
                dbLocal.MikeBoundaryConditions.Remove(mikeBoundaryCondition);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeBoundaryCondition)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mikeBoundaryCondition.MikeBoundaryConditionID == 0)
            {
                int LastMikeBoundaryConditionID = (from c in dbLocal.MikeBoundaryConditions
                          orderby c.MikeBoundaryConditionID descending
                          select c.MikeBoundaryConditionID).FirstOrDefault();

                mikeBoundaryCondition.MikeBoundaryConditionID = LastMikeBoundaryConditionID + 1;
            }

            try
            {
                dbLocal.MikeBoundaryConditions.Add(mikeBoundaryCondition);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeBoundaryCondition));
        }
        public async Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeBoundaryCondition)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MikeBoundaryConditions.Update(mikeBoundaryCondition);
                dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeBoundaryCondition));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MikeBoundaryCondition mikeBoundaryCondition = validationContext.ObjectInstance as MikeBoundaryCondition;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeBoundaryCondition.MikeBoundaryConditionID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeBoundaryConditionID"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionID) });
                }

                if (!(from c in dbLocal.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionID) });
                }
            }

            TVItem TVItemMikeBoundaryConditionTVItemID = null;
            TVItemMikeBoundaryConditionTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();

            if (TVItemMikeBoundaryConditionTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionTVItemID", mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeBoundaryConditionTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeBoundaryConditionTVItemID", "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionTVItemID) });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeBoundaryConditionCode"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionCode) });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionCode", "100"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionCode) });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeBoundaryConditionName"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionName) });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionName", "100"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionName) });
            }

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionLength_m", "1", "100000"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionLength_m) });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeBoundaryConditionFormat"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionFormat) });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MikeBoundaryConditionFormat", "100"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionFormat) });
            }

            retStr = enums.EnumTypeOK(typeof(MikeBoundaryConditionLevelOrVelocityEnum), (int?)mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeBoundaryConditionLevelOrVelocity"), new[] { nameof(mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity) });
            }

            retStr = enums.EnumTypeOK(typeof(WebTideDataSetEnum), (int?)mikeBoundaryCondition.WebTideDataSet);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "WebTideDataSet"), new[] { nameof(mikeBoundaryCondition.WebTideDataSet) });
            }

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "NumberOfWebTideNodes", "0", "1000"), new[] { nameof(mikeBoundaryCondition.NumberOfWebTideNodes) });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "WebTideDataFromStartToEndDate"), new[] { nameof(mikeBoundaryCondition.WebTideDataFromStartToEndDate) });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mikeBoundaryCondition.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { nameof(mikeBoundaryCondition.TVType) });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeBoundaryCondition.LastUpdateDate_UTC) });
            }
            else
            {
                if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeBoundaryCondition.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeBoundaryCondition.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeBoundaryCondition.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
