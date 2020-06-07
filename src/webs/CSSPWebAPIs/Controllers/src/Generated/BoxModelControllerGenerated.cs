/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IBoxModelController
    {
        Task<ActionResult<List<BoxModel>>> Get();
        Task<ActionResult<BoxModel>> Get(int BoxModelID);
        Task<ActionResult<BoxModel>> Post(BoxModel boxModel);
        Task<ActionResult<BoxModel>> Put(BoxModel boxModel);
        Task<ActionResult<bool>> Delete(int BoxModelID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class BoxModelController : ControllerBase, IBoxModelController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IBoxModelService boxModelService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelController(IBoxModelService boxModelService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.boxModelService = boxModelService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModel>>> Get()
        {
            return await boxModelService.GetBoxModelList();
        }
        [HttpGet("{BoxModelID}")]
        public async Task<ActionResult<BoxModel>> Get(int BoxModelID)
        {
            return await boxModelService.GetBoxModelWithBoxModelID(BoxModelID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModel>> Post(BoxModel boxModel)
        {
            return await boxModelService.Add(boxModel);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModel>> Put(BoxModel boxModel)
        {
            return await boxModelService.Update(boxModel);
        }
        [HttpDelete("{BoxModelID}")]
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            return await boxModelService.Delete(BoxModelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}