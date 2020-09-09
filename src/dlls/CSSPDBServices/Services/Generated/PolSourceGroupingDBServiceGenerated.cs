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
    public partial interface IPolSourceGroupingDBService
    {
        Task<ActionResult<bool>> Delete(int PolSourceGroupingID);
        Task<ActionResult<List<PolSourceGrouping>>> GetPolSourceGroupingList(int skip = 0, int take = 100);
        Task<ActionResult<PolSourceGrouping>> GetPolSourceGroupingWithPolSourceGroupingID(int PolSourceGroupingID);
        Task<ActionResult<PolSourceGrouping>> Post(PolSourceGrouping polsourcegrouping);
        Task<ActionResult<PolSourceGrouping>> Put(PolSourceGrouping polsourcegrouping);
    }
    public partial class PolSourceGroupingDBService : ControllerBase, IPolSourceGroupingDBService
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
        public PolSourceGroupingDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
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
        public async Task<ActionResult<PolSourceGrouping>> GetPolSourceGroupingWithPolSourceGroupingID(int PolSourceGroupingID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            PolSourceGrouping polSourceGrouping = (from c in db.PolSourceGroupings.AsNoTracking()
                    where c.PolSourceGroupingID == PolSourceGroupingID
                    select c).FirstOrDefault();

            if (polSourceGrouping == null)
            {
                return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(polSourceGrouping));
        }
        public async Task<ActionResult<List<PolSourceGrouping>>> GetPolSourceGroupingList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<PolSourceGrouping> polSourceGroupingList = (from c in db.PolSourceGroupings.AsNoTracking() orderby c.PolSourceGroupingID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(polSourceGroupingList));
        }
        public async Task<ActionResult<bool>> Delete(int PolSourceGroupingID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            PolSourceGrouping polSourceGrouping = (from c in db.PolSourceGroupings.Local
                    where c.PolSourceGroupingID == PolSourceGroupingID
                    select c).FirstOrDefault();

            if (polSourceGrouping == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", PolSourceGroupingID.ToString())));
            }

            try
            {
                db.PolSourceGroupings.Remove(polSourceGrouping);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<PolSourceGrouping>> Post(PolSourceGrouping polSourceGrouping)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGrouping), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.PolSourceGroupings.Add(polSourceGrouping);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGrouping));
        }
        public async Task<ActionResult<PolSourceGrouping>> Put(PolSourceGrouping polSourceGrouping)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(polSourceGrouping), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
                db.PolSourceGroupings.Update(polSourceGrouping);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(polSourceGrouping));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceGrouping polSourceGrouping = validationContext.ObjectInstance as PolSourceGrouping;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceGrouping.PolSourceGroupingID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PolSourceGroupingID"), new[] { nameof(polSourceGrouping.PolSourceGroupingID) });
                }

                if (!(from c in db.PolSourceGroupings.AsNoTracking() select c).Where(c => c.PolSourceGroupingID == polSourceGrouping.PolSourceGroupingID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", polSourceGrouping.PolSourceGroupingID.ToString()), new[] { nameof(polSourceGrouping.PolSourceGroupingID) });
                }
            }

            if (polSourceGrouping.CSSPID < 10000 || polSourceGrouping.CSSPID > 100000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "CSSPID", "10000", "100000"), new[] { nameof(polSourceGrouping.CSSPID) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGrouping.GroupName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GroupName"), new[] { nameof(polSourceGrouping.GroupName) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGrouping.GroupName) && polSourceGrouping.GroupName.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "GroupName", "500"), new[] { nameof(polSourceGrouping.GroupName) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGrouping.Child))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Child"), new[] { nameof(polSourceGrouping.Child) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGrouping.Child) && polSourceGrouping.Child.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Child", "500"), new[] { nameof(polSourceGrouping.Child) });
            }

            if (string.IsNullOrWhiteSpace(polSourceGrouping.Hide))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Hide"), new[] { nameof(polSourceGrouping.Hide) });
            }

            if (!string.IsNullOrWhiteSpace(polSourceGrouping.Hide) && polSourceGrouping.Hide.Length > 500)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Hide", "500"), new[] { nameof(polSourceGrouping.Hide) });
            }

            if (polSourceGrouping.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(polSourceGrouping.LastUpdateDate_UTC) });
            }
            else
            {
                if (polSourceGrouping.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(polSourceGrouping.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == polSourceGrouping.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceGrouping.LastUpdateContactTVItemID.ToString()), new[] { nameof(polSourceGrouping.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(polSourceGrouping.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private
    }

}
