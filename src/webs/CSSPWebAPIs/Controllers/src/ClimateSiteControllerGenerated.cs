using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IClimateSiteController
    {
        Task<ActionResult<List<ClimateSite>>> Get();
        Task<ActionResult<ClimateSite>> Get(int ClimateSiteID);
        Task<ActionResult<ClimateSite>> Post(ClimateSite climateSite);
        Task<ActionResult<ClimateSite>> Put(ClimateSite climateSite);
        Task<ActionResult<ClimateSite>> Delete(ClimateSite climateSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ClimateSiteController : ControllerBase, IClimateSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IClimateSiteService climateSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ClimateSiteController(IClimateSiteService climateSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.climateSiteService = climateSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ClimateSite>>> Get()
        {
            return await climateSiteService.GetClimateSiteList();
        }
        [HttpGet("{ClimateSiteID}")]
        public async Task<ActionResult<ClimateSite>> Get(int ClimateSiteID)
        {
            return await climateSiteService.GetClimateSiteWithClimateSiteID(ClimateSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<ClimateSite>> Post(ClimateSite climateSite)
        {
            return await climateSiteService.Add(climateSite);
        }
        [HttpPut]
        public async Task<ActionResult<ClimateSite>> Put(ClimateSite climateSite)
        {
            return await climateSiteService.Update(climateSite);
        }
        [HttpDelete]
        public async Task<ActionResult<ClimateSite>> Delete(ClimateSite climateSite)
        {
            return await climateSiteService.Delete(climateSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
