/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CSSPLocalTaskRunnerServices
{

    public partial interface ICSSPLocalTaskRunnerService
    {
        Task<ActionResult<bool>> Junk();
    }
    public partial class LocalTaskRunnerService : ControllerBase, ICSSPLocalTaskRunnerService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTaskRunnerService(ICSSPCultureService CSSPCultureService, IEnums enums, 
            ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        /*
         * This local task runner should hold all the functions to run the local task that can be run locally
         * creation of reports, html, csv, Excel, kml, etc... almost everything other than running MIKE scenarios
         */
        public async Task<ActionResult<bool>> Junk()
        {
            if (CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateJunk())
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoJunk())
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}