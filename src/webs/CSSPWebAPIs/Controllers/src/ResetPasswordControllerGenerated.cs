using CSSPModels;
using CSSPServices;
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
        Task<ActionResult<ResetPassword>> Post(ResetPassword resetPassword);
        Task<ActionResult<ResetPassword>> Put(ResetPassword resetPassword);
        Task<ActionResult<ResetPassword>> Delete(ResetPassword resetPassword);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ResetPasswordController : ControllerBase, IResetPasswordController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IResetPasswordService resetPasswordService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ResetPasswordController(IResetPasswordService resetPasswordService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.resetPasswordService = resetPasswordService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ResetPassword>>> Get()
        {
            return await resetPasswordService.GetResetPasswordList();
        }
        [HttpGet("{ResetPasswordID}")]
        public async Task<ActionResult<ResetPassword>> Get(int ResetPasswordID)
        {
            return await resetPasswordService.GetResetPasswordWithResetPasswordID(ResetPasswordID);
        }
        [HttpPost]
        public async Task<ActionResult<ResetPassword>> Post(ResetPassword resetPassword)
        {
            return await resetPasswordService.Add(resetPassword);
        }
        [HttpPut]
        public async Task<ActionResult<ResetPassword>> Put(ResetPassword resetPassword)
        {
            return await resetPasswordService.Update(resetPassword);
        }
        [HttpDelete]
        public async Task<ActionResult<ResetPassword>> Delete(ResetPassword resetPassword)
        {
            return await resetPasswordService.Delete(resetPassword);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
