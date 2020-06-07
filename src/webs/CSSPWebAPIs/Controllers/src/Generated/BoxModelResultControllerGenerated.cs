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
    public partial interface IBoxModelResultController
    {
        Task<ActionResult<List<BoxModelResult>>> Get();
        Task<ActionResult<BoxModelResult>> Get(int BoxModelResultID);
        Task<ActionResult<BoxModelResult>> Post(BoxModelResult boxModelResult);
        Task<ActionResult<BoxModelResult>> Put(BoxModelResult boxModelResult);
        Task<ActionResult<bool>> Delete(int BoxModelResultID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class BoxModelResultController : ControllerBase, IBoxModelResultController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IBoxModelResultService boxModelResultService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelResultController(IBoxModelResultService boxModelResultService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.boxModelResultService = boxModelResultService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModelResult>>> Get()
        {
            return await boxModelResultService.GetBoxModelResultList();
        }
        [HttpGet("{BoxModelResultID}")]
        public async Task<ActionResult<BoxModelResult>> Get(int BoxModelResultID)
        {
            return await boxModelResultService.GetBoxModelResultWithBoxModelResultID(BoxModelResultID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModelResult>> Post(BoxModelResult boxModelResult)
        {
            return await boxModelResultService.Add(boxModelResult);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModelResult>> Put(BoxModelResult boxModelResult)
        {
            return await boxModelResultService.Update(boxModelResult);
        }
        [HttpDelete("{BoxModelResultID}")]
        public async Task<ActionResult<bool>> Delete(int BoxModelResultID)
        {
            return await boxModelResultService.Delete(BoxModelResultID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
