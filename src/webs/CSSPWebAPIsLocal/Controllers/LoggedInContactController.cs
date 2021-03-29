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
using ReadGzFileServices;
using System.Linq;
using System.Threading;
using LoggedInServices;
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
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        #endregion Properties

        #region Constructors
        public LoggedInContactController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IScrambleService ScrambleService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<Contact>> Get()
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            LoggedInService.LoggedInContactInfo.LoggedInContact.PasswordHash = "";
            LoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash = ScrambleService.Descramble(LoggedInService.LoggedInContactInfo.LoggedInContact.GoogleMapKeyHash);
            return await Task.FromResult(Ok(LoggedInService.LoggedInContactInfo.LoggedInContact));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
