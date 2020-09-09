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
    public partial interface IInfrastructureLanguageDBLocalService
    {
        Task<ActionResult<bool>> Delete(int InfrastructureLanguageID);
        Task<ActionResult<List<InfrastructureLanguage>>> GetInfrastructureLanguageList(int skip = 0, int take = 100);
        Task<ActionResult<InfrastructureLanguage>> GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID);
        Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructurelanguage);
        Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructurelanguage);
    }
    public partial class InfrastructureLanguageDBLocalService : ControllerBase, IInfrastructureLanguageDBLocalService
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
        public InfrastructureLanguageDBLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<InfrastructureLanguage>> GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            InfrastructureLanguage infrastructureLanguage = (from c in dbLocal.InfrastructureLanguages.AsNoTracking()
                    where c.InfrastructureLanguageID == InfrastructureLanguageID
                    select c).FirstOrDefault();

            if (infrastructureLanguage == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        public async Task<ActionResult<List<InfrastructureLanguage>>> GetInfrastructureLanguageList(int skip = 0, int take = 100)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<InfrastructureLanguage> infrastructureLanguageList = (from c in dbLocal.InfrastructureLanguages.AsNoTracking() orderby c.InfrastructureLanguageID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(infrastructureLanguageList));
        }
        public async Task<ActionResult<bool>> Delete(int InfrastructureLanguageID)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            InfrastructureLanguage infrastructureLanguage = (from c in dbLocal.InfrastructureLanguages.Local
                    where c.InfrastructureLanguageID == InfrastructureLanguageID
                    select c).FirstOrDefault();

            if (infrastructureLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", InfrastructureLanguageID.ToString())));
            }

            try
            {
                dbLocal.InfrastructureLanguages.Remove(infrastructureLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructureLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (infrastructureLanguage.InfrastructureLanguageID == 0)
            {
                int LastInfrastructureLanguageID = (from c in dbLocal.InfrastructureLanguages.AsNoTracking()
                          orderby c.InfrastructureLanguageID descending
                          select c.InfrastructureLanguageID).FirstOrDefault();

                infrastructureLanguage.InfrastructureLanguageID = LastInfrastructureLanguageID + 1;
            }

            try
            {
                dbLocal.InfrastructureLanguages.Add(infrastructureLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        public async Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructureLanguage)
        {
            if (LocalService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                dbLocal.InfrastructureLanguages.Update(infrastructureLanguage);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(infrastructureLanguage));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            InfrastructureLanguage infrastructureLanguage = validationContext.ObjectInstance as InfrastructureLanguage;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureLanguageID"), new[] { nameof(infrastructureLanguage.InfrastructureLanguageID) });
                }

                if (!(from c in dbLocal.InfrastructureLanguages.AsNoTracking() select c).Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString()), new[] { nameof(infrastructureLanguage.InfrastructureLanguageID) });
                }
            }

            Infrastructure InfrastructureInfrastructureID = null;
            InfrastructureInfrastructureID = (from c in dbLocal.Infrastructures.AsNoTracking() where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                InfrastructureInfrastructureID = (from c in dbLocalIM.Infrastructures.Local where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

                if (InfrastructureInfrastructureID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructureLanguage.InfrastructureID.ToString()), new[] { nameof(infrastructureLanguage.InfrastructureID) });
                }

            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)infrastructureLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { nameof(infrastructureLanguage.Language) });
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Comment"), new[] { nameof(infrastructureLanguage.Comment) });
            }

            //Comment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)infrastructureLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { nameof(infrastructureLanguage.TranslationStatus) });
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(infrastructureLanguage.LastUpdateDate_UTC) });
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(infrastructureLanguage.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems.AsNoTracking() where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocalIM.TVItems.Local where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { nameof(infrastructureLanguage.LastUpdateContactTVItemID) });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(infrastructureLanguage.LastUpdateContactTVItemID) });
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
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(infrastructureLanguage.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
