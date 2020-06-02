using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMSampleController
    {
        Task<ActionResult<List<MWQMSample>>> Get();
        Task<ActionResult<MWQMSample>> Get(int MWQMSampleID);
        Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmSample);
        Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmSample);
        Task<ActionResult<MWQMSample>> Delete(MWQMSample mwqmSample);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSampleController : ControllerBase, IMWQMSampleController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSampleService mwqmSampleService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSampleController(IMWQMSampleService mwqmSampleService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSampleService = mwqmSampleService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSample>>> Get()
        {
            return await mwqmSampleService.GetMWQMSampleList();
        }
        [HttpGet("{MWQMSampleID}")]
        public async Task<ActionResult<MWQMSample>> Get(int MWQMSampleID)
        {
            return await mwqmSampleService.GetMWQMSampleWithMWQMSampleID(MWQMSampleID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSample>> Post(MWQMSample mwqmSample)
        {
            return await mwqmSampleService.Add(mwqmSample);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSample>> Put(MWQMSample mwqmSample)
        {
            return await mwqmSampleService.Update(mwqmSample);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMSample>> Delete(MWQMSample mwqmSample)
        {
            return await mwqmSampleService.Delete(mwqmSample);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
