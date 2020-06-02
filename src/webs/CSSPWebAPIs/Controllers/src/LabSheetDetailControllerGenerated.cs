using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ILabSheetDetailController
    {
        Task<ActionResult<List<LabSheetDetail>>> Get();
        Task<ActionResult<LabSheetDetail>> Get(int LabSheetDetailID);
        Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail labSheetDetail);
        Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail labSheetDetail);
        Task<ActionResult<LabSheetDetail>> Delete(LabSheetDetail labSheetDetail);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetDetailController : ControllerBase, ILabSheetDetailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ILabSheetDetailService labSheetDetailService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailController(ILabSheetDetailService labSheetDetailService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.labSheetDetailService = labSheetDetailService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetDetail>>> Get()
        {
            return await labSheetDetailService.GetLabSheetDetailList();
        }
        [HttpGet("{LabSheetDetailID}")]
        public async Task<ActionResult<LabSheetDetail>> Get(int LabSheetDetailID)
        {
            return await labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(LabSheetDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail labSheetDetail)
        {
            return await labSheetDetailService.Add(labSheetDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail labSheetDetail)
        {
            return await labSheetDetailService.Update(labSheetDetail);
        }
        [HttpDelete]
        public async Task<ActionResult<LabSheetDetail>> Delete(LabSheetDetail labSheetDetail)
        {
            return await labSheetDetailService.Delete(labSheetDetail);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
