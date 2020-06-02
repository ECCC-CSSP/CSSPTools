using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IVPResultController
    {
        Task<ActionResult<List<VPResult>>> Get();
        Task<ActionResult<VPResult>> Get(int VPResultID);
        Task<ActionResult<VPResult>> Post(VPResult vpResult);
        Task<ActionResult<VPResult>> Put(VPResult vpResult);
        Task<ActionResult<VPResult>> Delete(VPResult vpResult);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPResultController : ControllerBase, IVPResultController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IVPResultService vpResultService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public VPResultController(IVPResultService vpResultService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.vpResultService = vpResultService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPResult>>> Get()
        {
            return await vpResultService.GetVPResultList();
        }
        [HttpGet("{VPResultID}")]
        public async Task<ActionResult<VPResult>> Get(int VPResultID)
        {
            return await vpResultService.GetVPResultWithVPResultID(VPResultID);
        }
        [HttpPost]
        public async Task<ActionResult<VPResult>> Post(VPResult vpResult)
        {
            return await vpResultService.Add(vpResult);
        }
        [HttpPut]
        public async Task<ActionResult<VPResult>> Put(VPResult vpResult)
        {
            return await vpResultService.Update(vpResult);
        }
        [HttpDelete]
        public async Task<ActionResult<VPResult>> Delete(VPResult vpResult)
        {
            return await vpResultService.Delete(vpResult);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
