using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMapInfoPointController
    {
        Task<ActionResult<List<MapInfoPoint>>> Get();
        Task<ActionResult<MapInfoPoint>> Get(int MapInfoPointID);
        Task<ActionResult<MapInfoPoint>> Post(MapInfoPoint mapInfoPoint);
        Task<ActionResult<MapInfoPoint>> Put(MapInfoPoint mapInfoPoint);
        Task<ActionResult<MapInfoPoint>> Delete(MapInfoPoint mapInfoPoint);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MapInfoPointController : ControllerBase, IMapInfoPointController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMapInfoPointService mapInfoPointService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MapInfoPointController(IMapInfoPointService mapInfoPointService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mapInfoPointService = mapInfoPointService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MapInfoPoint>>> Get()
        {
            return await mapInfoPointService.GetMapInfoPointList();
        }
        [HttpGet("{MapInfoPointID}")]
        public async Task<ActionResult<MapInfoPoint>> Get(int MapInfoPointID)
        {
            return await mapInfoPointService.GetMapInfoPointWithMapInfoPointID(MapInfoPointID);
        }
        [HttpPost]
        public async Task<ActionResult<MapInfoPoint>> Post(MapInfoPoint mapInfoPoint)
        {
            return await mapInfoPointService.Add(mapInfoPoint);
        }
        [HttpPut]
        public async Task<ActionResult<MapInfoPoint>> Put(MapInfoPoint mapInfoPoint)
        {
            return await mapInfoPointService.Update(mapInfoPoint);
        }
        [HttpDelete]
        public async Task<ActionResult<MapInfoPoint>> Delete(MapInfoPoint mapInfoPoint)
        {
            return await mapInfoPointService.Delete(mapInfoPoint);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
