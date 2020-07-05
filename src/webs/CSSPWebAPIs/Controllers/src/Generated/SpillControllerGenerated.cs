/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ISpillService SpillService { get; }
        #endregion Properties

        #region Constructors
        public SpillController(ICultureService CultureService, ILoggedInService LoggedInService, ISpillService SpillService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.SpillService = SpillService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Spill>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.GetSpillList();
        }
        [HttpGet("{SpillID}")]
        public async Task<ActionResult<Spill>> Get(int SpillID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.GetSpillWithSpillID(SpillID);
        }
        [HttpPost]
        public async Task<ActionResult<Spill>> Post(Spill Spill)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Post(Spill);
        }
        [HttpPut]
        public async Task<ActionResult<Spill>> Put(Spill Spill)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Put(Spill);
        }
        [HttpDelete("{SpillID}")]
        public async Task<ActionResult<bool>> Delete(int SpillID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SpillService.Delete(SpillID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
