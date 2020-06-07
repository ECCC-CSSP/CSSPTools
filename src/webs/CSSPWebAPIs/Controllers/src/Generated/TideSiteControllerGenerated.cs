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
    public partial interface ITideSiteController
    {
        Task<ActionResult<List<TideSite>>> Get();
        Task<ActionResult<TideSite>> Get(int TideSiteID);
        Task<ActionResult<TideSite>> Post(TideSite tideSite);
        Task<ActionResult<TideSite>> Put(TideSite tideSite);
        Task<ActionResult<bool>> Delete(int TideSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TideSiteController : ControllerBase, ITideSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITideSiteService tideSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TideSiteController(ITideSiteService tideSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tideSiteService = tideSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideSite>>> Get()
        {
            return await tideSiteService.GetTideSiteList();
        }
        [HttpGet("{TideSiteID}")]
        public async Task<ActionResult<TideSite>> Get(int TideSiteID)
        {
            return await tideSiteService.GetTideSiteWithTideSiteID(TideSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<TideSite>> Post(TideSite tideSite)
        {
            return await tideSiteService.Add(tideSite);
        }
        [HttpPut]
        public async Task<ActionResult<TideSite>> Put(TideSite tideSite)
        {
            return await tideSiteService.Update(tideSite);
        }
        [HttpDelete("{TideSiteID}")]
        public async Task<ActionResult<bool>> Delete(int TideSiteID)
        {
            return await tideSiteService.Delete(TideSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}