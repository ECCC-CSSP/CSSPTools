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
    public partial interface IUseOfSiteController
    {
        Task<ActionResult<List<UseOfSite>>> Get();
        Task<ActionResult<UseOfSite>> Get(int UseOfSiteID);
        Task<ActionResult<UseOfSite>> Post(UseOfSite useOfSite);
        Task<ActionResult<UseOfSite>> Put(UseOfSite useOfSite);
        Task<ActionResult<bool>> Delete(int UseOfSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class UseOfSiteController : ControllerBase, IUseOfSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IUseOfSiteService useOfSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public UseOfSiteController(IUseOfSiteService useOfSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.useOfSiteService = useOfSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<UseOfSite>>> Get()
        {
            return await useOfSiteService.GetUseOfSiteList();
        }
        [HttpGet("{UseOfSiteID}")]
        public async Task<ActionResult<UseOfSite>> Get(int UseOfSiteID)
        {
            return await useOfSiteService.GetUseOfSiteWithUseOfSiteID(UseOfSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<UseOfSite>> Post(UseOfSite useOfSite)
        {
            return await useOfSiteService.Add(useOfSite);
        }
        [HttpPut]
        public async Task<ActionResult<UseOfSite>> Put(UseOfSite useOfSite)
        {
            return await useOfSiteService.Update(useOfSite);
        }
        [HttpDelete("{UseOfSiteID}")]
        public async Task<ActionResult<bool>> Delete(int UseOfSiteID)
        {
            return await useOfSiteService.Delete(UseOfSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
