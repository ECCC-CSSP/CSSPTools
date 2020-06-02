using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVFileController
    {
        Task<ActionResult<List<TVFile>>> Get();
        Task<ActionResult<TVFile>> Get(int TVFileID);
        Task<ActionResult<TVFile>> Post(TVFile tvFile);
        Task<ActionResult<TVFile>> Put(TVFile tvFile);
        Task<ActionResult<TVFile>> Delete(TVFile tvFile);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVFileController : ControllerBase, ITVFileController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVFileService tvFileService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVFileController(ITVFileService tvFileService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvFileService = tvFileService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVFile>>> Get()
        {
            return await tvFileService.GetTVFileList();
        }
        [HttpGet("{TVFileID}")]
        public async Task<ActionResult<TVFile>> Get(int TVFileID)
        {
            return await tvFileService.GetTVFileWithTVFileID(TVFileID);
        }
        [HttpPost]
        public async Task<ActionResult<TVFile>> Post(TVFile tvFile)
        {
            return await tvFileService.Add(tvFile);
        }
        [HttpPut]
        public async Task<ActionResult<TVFile>> Put(TVFile tvFile)
        {
            return await tvFileService.Update(tvFile);
        }
        [HttpDelete]
        public async Task<ActionResult<TVFile>> Delete(TVFile tvFile)
        {
            return await tvFileService.Delete(tvFile);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
