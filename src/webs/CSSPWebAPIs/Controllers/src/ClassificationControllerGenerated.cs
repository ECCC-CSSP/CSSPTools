using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IClassificationController
    {
        Task<ActionResult<List<Classification>>> Get();
        Task<ActionResult<Classification>> Get(int ClassificationID);
        Task<ActionResult<Classification>> Post(Classification classification);
        Task<ActionResult<Classification>> Put(Classification classification);
        Task<ActionResult<Classification>> Delete(Classification classification);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ClassificationController : ControllerBase, IClassificationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IClassificationService classificationService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ClassificationController(IClassificationService classificationService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.classificationService = classificationService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Classification>>> Get()
        {
            return await classificationService.GetClassificationList();
        }
        [HttpGet("{ClassificationID}")]
        public async Task<ActionResult<Classification>> Get(int ClassificationID)
        {
            return await classificationService.GetClassificationWithClassificationID(ClassificationID);
        }
        [HttpPost]
        public async Task<ActionResult<Classification>> Post(Classification classification)
        {
            return await classificationService.Add(classification);
        }
        [HttpPut]
        public async Task<ActionResult<Classification>> Put(Classification classification)
        {
            return await classificationService.Update(classification);
        }
        [HttpDelete]
        public async Task<ActionResult<Classification>> Delete(Classification classification)
        {
            return await classificationService.Delete(classification);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
