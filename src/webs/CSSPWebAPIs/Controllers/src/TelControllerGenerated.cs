using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITelController
    {
        Task<ActionResult<List<Tel>>> Get();
        Task<ActionResult<Tel>> Get(int TelID);
        Task<ActionResult<Tel>> Post(Tel tel);
        Task<ActionResult<Tel>> Put(Tel tel);
        Task<ActionResult<Tel>> Delete(Tel tel);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TelController : ControllerBase, ITelController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITelService telService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TelController(ITelService telService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.telService = telService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Tel>>> Get()
        {
            return await telService.GetTelList();
        }
        [HttpGet("{TelID}")]
        public async Task<ActionResult<Tel>> Get(int TelID)
        {
            return await telService.GetTelWithTelID(TelID);
        }
        [HttpPost]
        public async Task<ActionResult<Tel>> Post(Tel tel)
        {
            return await telService.Add(tel);
        }
        [HttpPut]
        public async Task<ActionResult<Tel>> Put(Tel tel)
        {
            return await telService.Update(tel);
        }
        [HttpDelete]
        public async Task<ActionResult<Tel>> Delete(Tel tel)
        {
            return await telService.Delete(tel);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
