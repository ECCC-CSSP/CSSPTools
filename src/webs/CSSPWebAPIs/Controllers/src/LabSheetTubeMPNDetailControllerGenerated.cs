using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ILabSheetTubeMPNDetailController
    {
        Task<ActionResult<List<LabSheetTubeMPNDetail>>> Get();
        Task<ActionResult<LabSheetTubeMPNDetail>> Get(int LabSheetTubeMPNDetailID);
        Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail labSheetTubeMPNDetail);
        Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail labSheetTubeMPNDetail);
        Task<ActionResult<LabSheetTubeMPNDetail>> Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetTubeMPNDetailController : ControllerBase, ILabSheetTubeMPNDetailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ILabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailController(ILabSheetTubeMPNDetailService labSheetTubeMPNDetailService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.labSheetTubeMPNDetailService = labSheetTubeMPNDetailService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetTubeMPNDetail>>> Get()
        {
            return await labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList();
        }
        [HttpGet("{LabSheetTubeMPNDetailID}")]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Get(int LabSheetTubeMPNDetailID)
        {
            return await labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            return await labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            return await labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
        }
        [HttpDelete]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            return await labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
