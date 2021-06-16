/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CSSPServerTaskRunnerServices
{

    public partial interface IServerTaskRunnerService
    {
        Task<ActionResult<bool>> Junk();
    }
    public partial class ServerTaskRunnerService : ControllerBase, IServerTaskRunnerService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public ServerTaskRunnerService(ICSSPCultureService CSSPCultureService, IEnums enums, 
            ILoggedInService LoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        /*
         * this server task runner should run all the functions to run server task which are all the task that need to be
         * running on the server. like MIKE scenarios, Import of users local db to Azure db, recreating gz files, 
         * recalculating TVItemStats, potentially importing precip data, hydrometric data and a few other things
         */
        public async Task<ActionResult<bool>> Junk()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
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