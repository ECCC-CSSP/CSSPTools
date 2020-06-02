using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMikeSourceController
    {
        Task<ActionResult<List<MikeSource>>> Get();
        Task<ActionResult<MikeSource>> Get(int MikeSourceID);
        Task<ActionResult<MikeSource>> Post(MikeSource mikeSource);
        Task<ActionResult<MikeSource>> Put(MikeSource mikeSource);
        Task<ActionResult<MikeSource>> Delete(MikeSource mikeSource);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeSourceController : ControllerBase, IMikeSourceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMikeSourceService mikeSourceService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceController(IMikeSourceService mikeSourceService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mikeSourceService = mikeSourceService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeSource>>> Get()
        {
            return await mikeSourceService.GetMikeSourceList();
        }
        [HttpGet("{MikeSourceID}")]
        public async Task<ActionResult<MikeSource>> Get(int MikeSourceID)
        {
            return await mikeSourceService.GetMikeSourceWithMikeSourceID(MikeSourceID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeSource>> Post(MikeSource mikeSource)
        {
            return await mikeSourceService.Add(mikeSource);
        }
        [HttpPut]
        public async Task<ActionResult<MikeSource>> Put(MikeSource mikeSource)
        {
            return await mikeSourceService.Update(mikeSource);
        }
        [HttpDelete]
        public async Task<ActionResult<MikeSource>> Delete(MikeSource mikeSource)
        {
            return await mikeSourceService.Delete(mikeSource);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
