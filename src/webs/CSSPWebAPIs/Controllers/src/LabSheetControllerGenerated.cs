using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ILabSheetController
    {
        Task<ActionResult<List<LabSheet>>> Get();
        Task<ActionResult<LabSheet>> Get(int LabSheetID);
        Task<ActionResult<LabSheet>> Post(LabSheet labSheet);
        Task<ActionResult<LabSheet>> Put(LabSheet labSheet);
        Task<ActionResult<LabSheet>> Delete(LabSheet labSheet);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetController : ControllerBase, ILabSheetController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ILabSheetService labSheetService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetController(ILabSheetService labSheetService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.labSheetService = labSheetService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheet>>> Get()
        {
            return await labSheetService.GetLabSheetList();
        }
        [HttpGet("{LabSheetID}")]
        public async Task<ActionResult<LabSheet>> Get(int LabSheetID)
        {
            return await labSheetService.GetLabSheetWithLabSheetID(LabSheetID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheet>> Post(LabSheet labSheet)
        {
            return await labSheetService.Add(labSheet);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheet>> Put(LabSheet labSheet)
        {
            return await labSheetService.Update(labSheet);
        }
        [HttpDelete]
        public async Task<ActionResult<LabSheet>> Delete(LabSheet labSheet)
        {
            return await labSheetService.Delete(labSheet);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
