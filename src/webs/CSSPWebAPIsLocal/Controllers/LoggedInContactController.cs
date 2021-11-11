/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPReadGzFileServices;
using System.Linq;
using System.Threading;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPScrambleServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ILoggedInContactController
    {
        Task<ActionResult<Contact>> Get();
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LoggedInContactController : ControllerBase, ILoggedInContactController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        #endregion Properties

        #region Constructors
        public LoggedInContactController(ICSSPCultureService CSSPCultureService, ICSSPScrambleService CSSPScrambleService, 
            ICSSPLogService CSSPLogService, ICSSPLocalLoggedInService CSSPLocalLoggedInService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLogService = CSSPLogService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<Contact>> Get()
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.PasswordHash = "";
            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash = CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash);
            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash = CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash);
            return await Task.FromResult(Ok(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
