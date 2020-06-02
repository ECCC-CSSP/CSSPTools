using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IHydrometricSiteController
    {
        Task<ActionResult<List<HydrometricSite>>> Get();
        Task<ActionResult<HydrometricSite>> Get(int HydrometricSiteID);
        Task<ActionResult<HydrometricSite>> Post(HydrometricSite hydrometricSite);
        Task<ActionResult<HydrometricSite>> Put(HydrometricSite hydrometricSite);
        Task<ActionResult<HydrometricSite>> Delete(HydrometricSite hydrometricSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class HydrometricSiteController : ControllerBase, IHydrometricSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IHydrometricSiteService hydrometricSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteController(IHydrometricSiteService hydrometricSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.hydrometricSiteService = hydrometricSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HydrometricSite>>> Get()
        {
            return await hydrometricSiteService.GetHydrometricSiteList();
        }
        [HttpGet("{HydrometricSiteID}")]
        public async Task<ActionResult<HydrometricSite>> Get(int HydrometricSiteID)
        {
            return await hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(HydrometricSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<HydrometricSite>> Post(HydrometricSite hydrometricSite)
        {
            return await hydrometricSiteService.Add(hydrometricSite);
        }
        [HttpPut]
        public async Task<ActionResult<HydrometricSite>> Put(HydrometricSite hydrometricSite)
        {
            return await hydrometricSiteService.Update(hydrometricSite);
        }
        [HttpDelete]
        public async Task<ActionResult<HydrometricSite>> Delete(HydrometricSite hydrometricSite)
        {
            return await hydrometricSiteService.Delete(hydrometricSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
