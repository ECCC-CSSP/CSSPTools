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
    public partial interface IMikeScenarioResultDBLocalService
    {
        Task<ActionResult<bool>> Delete(int MikeScenarioResultID);
        Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList(int skip = 0, int take = 100);
        Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID);
        Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikescenarioresult);
        Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikescenarioresult);
    }
    public partial class MikeScenarioResultDBLocalService : ControllerBase, IMikeScenarioResultDBLocalService
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
        public MikeScenarioResultDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<MikeScenarioResult>> GetMikeScenarioResultWithMikeScenarioResultID(int MikeScenarioResultID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            MikeScenarioResult mikeScenarioResult = (from c in dbLocal.MikeScenarioResults.AsNoTracking()
                    where c.MikeScenarioResultID == MikeScenarioResultID
                    select c).FirstOrDefault();

            if (mikeScenarioResult == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<List<MikeScenarioResult>>> GetMikeScenarioResultList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<MikeScenarioResult> mikeScenarioResultList = (from c in dbLocal.MikeScenarioResults.AsNoTracking() orderby c.MikeScenarioResultID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(mikeScenarioResultList));
        }
        public async Task<ActionResult<bool>> Delete(int MikeScenarioResultID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            MikeScenarioResult mikeScenarioResult = (from c in dbLocal.MikeScenarioResults
                    where c.MikeScenarioResultID == MikeScenarioResultID
                    select c).FirstOrDefault();

            if (mikeScenarioResult == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", MikeScenarioResultID.ToString())));
            }

            try
            {
                dbLocal.MikeScenarioResults.Remove(mikeScenarioResult);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikeScenarioResult)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (mikeScenarioResult.MikeScenarioResultID == 0)
            {
                int LastMikeScenarioResultID = (from c in dbLocal.MikeScenarioResults.AsNoTracking()
                          orderby c.MikeScenarioResultID descending
                          select c.MikeScenarioResultID).FirstOrDefault();

                mikeScenarioResult.MikeScenarioResultID = LastMikeScenarioResultID + 1;
            }

            try
            {
                dbLocal.MikeScenarioResults.Add(mikeScenarioResult);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        public async Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikeScenarioResult)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(mikeScenarioResult), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.MikeScenarioResults.Update(mikeScenarioResult);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mikeScenarioResult));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MikeScenarioResult mikeScenarioResult = validationContext.ObjectInstance as MikeScenarioResult;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenarioResult.MikeScenarioResultID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MikeScenarioResultID"), new[] { nameof(mikeScenarioResult.MikeScenarioResultID) });
                }

                if (!(from c in dbLocal.MikeScenarioResults.AsNoTracking() select c).Where(c => c.MikeScenarioResultID == mikeScenarioResult.MikeScenarioResultID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", mikeScenarioResult.MikeScenarioResultID.ToString()), new[] { nameof(mikeScenarioResult.MikeScenarioResultID) });
                }
            }

            TVItem TVItemMikeScenarioTVItemID = null;
            TVItemMikeScenarioTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mikeScenarioResult.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                TVItemMikeScenarioTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mikeScenarioResult.MikeScenarioTVItemID select c).FirstOrDefault();

                if (TVItemMikeScenarioTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenarioResult.MikeScenarioTVItemID.ToString()), new[] { nameof(mikeScenarioResult.MikeScenarioTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MikeScenario,
                    };
                    if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { nameof(mikeScenarioResult.MikeScenarioTVItemID) });
                    }
                }

            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), new[] { nameof(mikeScenarioResult.MikeScenarioTVItemID) });
                }
            }

            //MikeResultsJSON has no StringLength Attribute

            if (mikeScenarioResult.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(mikeScenarioResult.LastUpdateDate_UTC) });
            }
            else
            {
                if (mikeScenarioResult.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(mikeScenarioResult.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == mikeScenarioResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == mikeScenarioResult.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenarioResult.LastUpdateContactTVItemID.ToString()), new[] { nameof(mikeScenarioResult.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeScenarioResult.LastUpdateContactTVItemID) });
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(mikeScenarioResult.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
