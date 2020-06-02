using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IHelpDocController
    {
        Task<ActionResult<List<HelpDoc>>> Get();
        Task<ActionResult<HelpDoc>> Get(int HelpDocID);
        Task<ActionResult<HelpDoc>> Post(HelpDoc helpDoc);
        Task<ActionResult<HelpDoc>> Put(HelpDoc helpDoc);
        Task<ActionResult<HelpDoc>> Delete(HelpDoc helpDoc);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class HelpDocController : ControllerBase, IHelpDocController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IHelpDocService helpDocService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public HelpDocController(IHelpDocService helpDocService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.helpDocService = helpDocService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HelpDoc>>> Get()
        {
            return await helpDocService.GetHelpDocList();
        }
        [HttpGet("{HelpDocID}")]
        public async Task<ActionResult<HelpDoc>> Get(int HelpDocID)
        {
            return await helpDocService.GetHelpDocWithHelpDocID(HelpDocID);
        }
        [HttpPost]
        public async Task<ActionResult<HelpDoc>> Post(HelpDoc helpDoc)
        {
            return await helpDocService.Add(helpDoc);
        }
        [HttpPut]
        public async Task<ActionResult<HelpDoc>> Put(HelpDoc helpDoc)
        {
            return await helpDocService.Update(helpDoc);
        }
        [HttpDelete]
        public async Task<ActionResult<HelpDoc>> Delete(HelpDoc helpDoc)
        {
            return await helpDocService.Delete(helpDoc);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
