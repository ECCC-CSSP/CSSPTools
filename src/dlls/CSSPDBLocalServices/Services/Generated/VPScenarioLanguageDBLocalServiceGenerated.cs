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
    public partial interface IVPScenarioLanguageDBLocalService
    {
        Task<ActionResult<bool>> Delete(int VPScenarioLanguageID);
        Task<ActionResult<List<VPScenarioLanguage>>> GetVPScenarioLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<VPScenarioLanguage>> GetVPScenarioLanguageWithVPScenarioLanguageID(int VPScenarioLanguageID);
        Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage vpscenariolanguage);
        Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage vpscenariolanguage);
    }
    public partial class VPScenarioLanguageDBLocalService : ControllerBase, IVPScenarioLanguageDBLocalService
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
        public VPScenarioLanguageDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<VPScenarioLanguage>> GetVPScenarioLanguageWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            VPScenarioLanguage vpScenarioLanguage = (from c in dbLocal.VPScenarioLanguages.AsNoTracking()
                    where c.VPScenarioLanguageID == VPScenarioLanguageID
                    select c).FirstOrDefault();

            if (vpScenarioLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(vpScenarioLanguage));
        }
        public async Task<ActionResult<List<VPScenarioLanguage>>> GetVPScenarioLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<VPScenarioLanguage> vpScenarioLanguageList = (from c in dbLocal.VPScenarioLanguages.AsNoTracking() orderby c.VPScenarioLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(vpScenarioLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int VPScenarioLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            VPScenarioLanguage vpScenarioLanguage = (from c in dbLocal.VPScenarioLanguages
                    where c.VPScenarioLanguageID == VPScenarioLanguageID
                    select c).FirstOrDefault();

            if (vpScenarioLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageID", VPScenarioLanguageID.ToString())));
            }

            try
            {
                dbLocal.VPScenarioLanguages.Remove(vpScenarioLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage vpScenarioLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (vpScenarioLanguage.VPScenarioLanguageID == 0)
            {
                int LastVPScenarioLanguageID = (from c in dbLocal.VPScenarioLanguages.AsNoTracking()
                          orderby c.VPScenarioLanguageID descending
                          select c.VPScenarioLanguageID).FirstOrDefault();

                vpScenarioLanguage.VPScenarioLanguageID = LastVPScenarioLanguageID + 1;
            }

            try
            {
                dbLocal.VPScenarioLanguages.Add(vpScenarioLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpScenarioLanguage));
        }
        public async Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage vpScenarioLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.VPScenarioLanguages.Update(vpScenarioLanguage);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(vpScenarioLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            VPScenarioLanguage vpScenarioLanguage = validationContext.ObjectInstance as VPScenarioLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpScenarioLanguage.VPScenarioLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VPScenarioLanguageID"), new[] { nameof(vpScenarioLanguage.VPScenarioLanguageID) });
                }

                if (!(from c in dbLocal.VPScenarioLanguages.AsNoTracking() select c).Where(c => c.VPScenarioLanguageID == vpScenarioLanguage.VPScenarioLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString()), new[] { nameof(vpScenarioLanguage.VPScenarioLanguageID) });
                }
            }

            VPScenario VPScenarioVPScenarioID = null;
            VPScenarioVPScenarioID = (from c in dbLocal.VPScenarios.AsNoTracking() where c.VPScenarioID == vpScenarioLanguage.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                VPScenarioVPScenarioID = (from c in dbLocalIM.VPScenarios.Local where c.VPScenarioID == vpScenarioLanguage.VPScenarioID select c).FirstOrDefault();

                if (VPScenarioVPScenarioID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenarioLanguage.VPScenarioID.ToString()), new[] { nameof(vpScenarioLanguage.VPScenarioID) });
                }

            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)vpScenarioLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(vpScenarioLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "VPScenarioName"), new[] { nameof(vpScenarioLanguage.VPScenarioName) });
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName) && vpScenarioLanguage.VPScenarioName.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VPScenarioName", "100"), new[] { nameof(vpScenarioLanguage.VPScenarioName) });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)vpScenarioLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(vpScenarioLanguage.TranslationStatus) });
            }

            if (vpScenarioLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(vpScenarioLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (vpScenarioLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(vpScenarioLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(vpScenarioLanguage.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(vpScenarioLanguage.LastUpdateContactTVItemID) });
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(vpScenarioLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}