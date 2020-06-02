using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMapInfoController
    {
        Task<ActionResult<List<MapInfo>>> Get();
        Task<ActionResult<MapInfo>> Get(int MapInfoID);
        Task<ActionResult<MapInfo>> Post(MapInfo mapInfo);
        Task<ActionResult<MapInfo>> Put(MapInfo mapInfo);
        Task<ActionResult<MapInfo>> Delete(MapInfo mapInfo);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MapInfoController : ControllerBase, IMapInfoController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMapInfoService mapInfoService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MapInfoController(IMapInfoService mapInfoService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mapInfoService = mapInfoService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MapInfo>>> Get()
        {
            return await mapInfoService.GetMapInfoList();
        }
        [HttpGet("{MapInfoID}")]
        public async Task<ActionResult<MapInfo>> Get(int MapInfoID)
        {
            return await mapInfoService.GetMapInfoWithMapInfoID(MapInfoID);
        }
        [HttpPost]
        public async Task<ActionResult<MapInfo>> Post(MapInfo mapInfo)
        {
            return await mapInfoService.Add(mapInfo);
        }
        [HttpPut]
        public async Task<ActionResult<MapInfo>> Put(MapInfo mapInfo)
        {
            return await mapInfoService.Update(mapInfo);
        }
        [HttpDelete]
        public async Task<ActionResult<MapInfo>> Delete(MapInfo mapInfo)
        {
            return await mapInfoService.Delete(mapInfo);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
