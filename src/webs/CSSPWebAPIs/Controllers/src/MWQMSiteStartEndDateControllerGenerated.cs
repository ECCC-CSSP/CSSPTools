using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMSiteStartEndDateController
    {
        Task<ActionResult<List<MWQMSiteStartEndDate>>> Get();
        Task<ActionResult<MWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID);
        Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate mwqmSiteStartEndDate);
        Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate mwqmSiteStartEndDate);
        Task<ActionResult<MWQMSiteStartEndDate>> Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSiteStartEndDateController : ControllerBase, IMWQMSiteStartEndDateController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateController(IMWQMSiteStartEndDateService mwqmSiteStartEndDateService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSiteStartEndDateService = mwqmSiteStartEndDateService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSiteStartEndDate>>> Get()
        {
            return await mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList();
        }
        [HttpGet("{MWQMSiteStartEndDateID}")]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID)
        {
            return await mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(MWQMSiteStartEndDateID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            return await mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            return await mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            return await mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
