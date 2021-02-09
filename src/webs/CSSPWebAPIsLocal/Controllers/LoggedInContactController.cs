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
using LocalServices;
using ReadGzFileServices;
using System.Linq;
using System.Threading;

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
        private ILocalService LocalService { get; }
        #endregion Properties

        #region Constructors
        public LoggedInContactController(ICSSPCultureService CSSPCultureService, ILocalService LocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<Contact>> Get()
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await Task.FromResult(Ok(LocalService.LoggedInContactInfo.LoggedInContact));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
