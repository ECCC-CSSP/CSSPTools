using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMikeSourceStartEndController
    {
        Task<ActionResult<List<MikeSourceStartEnd>>> Get();
        Task<ActionResult<MikeSourceStartEnd>> Get(int MikeSourceStartEndID);
        Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikeSourceStartEnd);
        Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikeSourceStartEnd);
        Task<ActionResult<MikeSourceStartEnd>> Delete(MikeSourceStartEnd mikeSourceStartEnd);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeSourceStartEndController : ControllerBase, IMikeSourceStartEndController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMikeSourceStartEndService mikeSourceStartEndService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndController(IMikeSourceStartEndService mikeSourceStartEndService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mikeSourceStartEndService = mikeSourceStartEndService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeSourceStartEnd>>> Get()
        {
            return await mikeSourceStartEndService.GetMikeSourceStartEndList();
        }
        [HttpGet("{MikeSourceStartEndID}")]
        public async Task<ActionResult<MikeSourceStartEnd>> Get(int MikeSourceStartEndID)
        {
            return await mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(MikeSourceStartEndID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd mikeSourceStartEnd)
        {
            return await mikeSourceStartEndService.Add(mikeSourceStartEnd);
        }
        [HttpPut]
        public async Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd mikeSourceStartEnd)
        {
            return await mikeSourceStartEndService.Update(mikeSourceStartEnd);
        }
        [HttpDelete]
        public async Task<ActionResult<MikeSourceStartEnd>> Delete(MikeSourceStartEnd mikeSourceStartEnd)
        {
            return await mikeSourceStartEndService.Delete(mikeSourceStartEnd);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
