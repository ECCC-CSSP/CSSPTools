/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ISpillController
    {
        Task<ActionResult<List<Spill>>> Get();
        Task<ActionResult<Spill>> Get(int SpillID);
        Task<ActionResult<Spill>> Post(Spill Spill);
        Task<ActionResult<Spill>> Put(Spill Spill);
        Task<ActionResult<bool>> Delete(int SpillID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SpillController : ControllerBase, ISpillController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ISpillService SpillService { get; }
        #endregion Properties

        #region Constructors
        public SpillController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ISpillService SpillService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.SpillService = SpillService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Spill>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.GetSpillList();
        }
        [HttpGet("{SpillID}")]
        public async Task<ActionResult<Spill>> Get(int SpillID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.GetSpillWithSpillID(SpillID);
        }
        [HttpPost]
        public async Task<ActionResult<Spill>> Post(Spill Spill)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Post(Spill);
        }
        [HttpPut]
        public async Task<ActionResult<Spill>> Put(Spill Spill)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Put(Spill);
        }
        [HttpDelete("{SpillID}")]
        public async Task<ActionResult<bool>> Delete(int SpillID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Delete(SpillID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
