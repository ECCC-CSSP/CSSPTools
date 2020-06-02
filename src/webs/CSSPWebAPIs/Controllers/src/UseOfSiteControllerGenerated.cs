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
        Task<ActionResult<UseOfSite>> Delete(UseOfSite useOfSite);
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
        [HttpDelete]
        public async Task<ActionResult<UseOfSite>> Delete(UseOfSite useOfSite)
        {
            return await useOfSiteService.Delete(useOfSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
