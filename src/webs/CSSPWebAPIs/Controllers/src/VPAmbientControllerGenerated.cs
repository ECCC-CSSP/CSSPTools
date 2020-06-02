using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IVPAmbientController
    {
        Task<ActionResult<List<VPAmbient>>> Get();
        Task<ActionResult<VPAmbient>> Get(int VPAmbientID);
        Task<ActionResult<VPAmbient>> Post(VPAmbient vpAmbient);
        Task<ActionResult<VPAmbient>> Put(VPAmbient vpAmbient);
        Task<ActionResult<VPAmbient>> Delete(VPAmbient vpAmbient);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPAmbientController : ControllerBase, IVPAmbientController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IVPAmbientService vpAmbientService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public VPAmbientController(IVPAmbientService vpAmbientService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.vpAmbientService = vpAmbientService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPAmbient>>> Get()
        {
            return await vpAmbientService.GetVPAmbientList();
        }
        [HttpGet("{VPAmbientID}")]
        public async Task<ActionResult<VPAmbient>> Get(int VPAmbientID)
        {
            return await vpAmbientService.GetVPAmbientWithVPAmbientID(VPAmbientID);
        }
        [HttpPost]
        public async Task<ActionResult<VPAmbient>> Post(VPAmbient vpAmbient)
        {
            return await vpAmbientService.Add(vpAmbient);
        }
        [HttpPut]
        public async Task<ActionResult<VPAmbient>> Put(VPAmbient vpAmbient)
        {
            return await vpAmbientService.Update(vpAmbient);
        }
        [HttpDelete]
        public async Task<ActionResult<VPAmbient>> Delete(VPAmbient vpAmbient)
        {
            return await vpAmbientService.Delete(vpAmbient);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
