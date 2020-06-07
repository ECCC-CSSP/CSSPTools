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
    public partial interface IMWQMLookupMPNController
    {
        Task<ActionResult<List<MWQMLookupMPN>>> Get();
        Task<ActionResult<MWQMLookupMPN>> Get(int MWQMLookupMPNID);
        Task<ActionResult<MWQMLookupMPN>> Post(MWQMLookupMPN mwqmLookupMPN);
        Task<ActionResult<MWQMLookupMPN>> Put(MWQMLookupMPN mwqmLookupMPN);
        Task<ActionResult<bool>> Delete(int MWQMLookupMPNID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMLookupMPNController : ControllerBase, IMWQMLookupMPNController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMLookupMPNService mwqmLookupMPNService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNController(IMWQMLookupMPNService mwqmLookupMPNService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmLookupMPNService = mwqmLookupMPNService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMLookupMPN>>> Get()
        {
            return await mwqmLookupMPNService.GetMWQMLookupMPNList();
        }
        [HttpGet("{MWQMLookupMPNID}")]
        public async Task<ActionResult<MWQMLookupMPN>> Get(int MWQMLookupMPNID)
        {
            return await mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(MWQMLookupMPNID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMLookupMPN>> Post(MWQMLookupMPN mwqmLookupMPN)
        {
            return await mwqmLookupMPNService.Add(mwqmLookupMPN);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMLookupMPN>> Put(MWQMLookupMPN mwqmLookupMPN)
        {
            return await mwqmLookupMPNService.Update(mwqmLookupMPN);
        }
        [HttpDelete("{MWQMLookupMPNID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMLookupMPNID)
        {
            return await mwqmLookupMPNService.Delete(MWQMLookupMPNID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}