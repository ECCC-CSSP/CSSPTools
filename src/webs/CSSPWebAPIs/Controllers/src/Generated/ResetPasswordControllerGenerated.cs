/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IResetPasswordController
    {
        Task<ActionResult<List<ResetPassword>>> Get();
        Task<ActionResult<ResetPassword>> Get(int ResetPasswordID);
        Task<ActionResult<ResetPassword>> Post(ResetPassword ResetPassword);
        Task<ActionResult<ResetPassword>> Put(ResetPassword ResetPassword);
        Task<ActionResult<bool>> Delete(int ResetPasswordID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ResetPasswordController : ControllerBase, IResetPasswordController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IResetPasswordService ResetPasswordService { get; }
        #endregion Properties

        #region Constructors
        public ResetPasswordController(ICultureService CultureService, ILoggedInService LoggedInService, IResetPasswordService ResetPasswordService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.ResetPasswordService = ResetPasswordService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ResetPassword>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ResetPasswordService.GetResetPasswordList();
        }
        [HttpGet("{ResetPasswordID}")]
        public async Task<ActionResult<ResetPassword>> Get(int ResetPasswordID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ResetPasswordService.GetResetPasswordWithResetPasswordID(ResetPasswordID);
        }
        [HttpPost]
        public async Task<ActionResult<ResetPassword>> Post(ResetPassword ResetPassword)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ResetPasswordService.Post(ResetPassword);
        }
        [HttpPut]
        public async Task<ActionResult<ResetPassword>> Put(ResetPassword ResetPassword)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ResetPasswordService.Put(ResetPassword);
        }
        [HttpDelete("{ResetPasswordID}")]
        public async Task<ActionResult<bool>> Delete(int ResetPasswordID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ResetPasswordService.Delete(ResetPasswordID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
