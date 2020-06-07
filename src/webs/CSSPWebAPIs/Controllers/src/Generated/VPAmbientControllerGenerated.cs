/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

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
        Task<ActionResult<bool>> Delete(int VPAmbientID);
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
        [HttpDelete("{VPAmbientID}")]
        public async Task<ActionResult<bool>> Delete(int VPAmbientID)
        {
            return await vpAmbientService.Delete(VPAmbientID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
