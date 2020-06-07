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
    public partial interface IDrogueRunPositionController
    {
        Task<ActionResult<List<DrogueRunPosition>>> Get();
        Task<ActionResult<DrogueRunPosition>> Get(int DrogueRunPositionID);
        Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition drogueRunPosition);
        Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition drogueRunPosition);
        Task<ActionResult<bool>> Delete(int DrogueRunPositionID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DrogueRunPositionController : ControllerBase, IDrogueRunPositionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDrogueRunPositionService drogueRunPositionService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController(IDrogueRunPositionService drogueRunPositionService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.drogueRunPositionService = drogueRunPositionService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DrogueRunPosition>>> Get()
        {
            return await drogueRunPositionService.GetDrogueRunPositionList();
        }
        [HttpGet("{DrogueRunPositionID}")]
        public async Task<ActionResult<DrogueRunPosition>> Get(int DrogueRunPositionID)
        {
            return await drogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);
        }
        [HttpPost]
        public async Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition drogueRunPosition)
        {
            return await drogueRunPositionService.Add(drogueRunPosition);
        }
        [HttpPut]
        public async Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition drogueRunPosition)
        {
            return await drogueRunPositionService.Update(drogueRunPosition);
        }
        [HttpDelete("{DrogueRunPositionID}")]
        public async Task<ActionResult<bool>> Delete(int DrogueRunPositionID)
        {
            return await drogueRunPositionService.Delete(DrogueRunPositionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}