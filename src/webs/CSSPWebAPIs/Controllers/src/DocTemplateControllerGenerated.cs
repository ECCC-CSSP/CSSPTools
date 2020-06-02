using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IDocTemplateController
    {
        Task<ActionResult<List<DocTemplate>>> Get();
        Task<ActionResult<DocTemplate>> Get(int DocTemplateID);
        Task<ActionResult<DocTemplate>> Post(DocTemplate docTemplate);
        Task<ActionResult<DocTemplate>> Put(DocTemplate docTemplate);
        Task<ActionResult<DocTemplate>> Delete(DocTemplate docTemplate);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DocTemplateController : ControllerBase, IDocTemplateController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDocTemplateService docTemplateService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public DocTemplateController(IDocTemplateService docTemplateService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.docTemplateService = docTemplateService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DocTemplate>>> Get()
        {
            return await docTemplateService.GetDocTemplateList();
        }
        [HttpGet("{DocTemplateID}")]
        public async Task<ActionResult<DocTemplate>> Get(int DocTemplateID)
        {
            return await docTemplateService.GetDocTemplateWithDocTemplateID(DocTemplateID);
        }
        [HttpPost]
        public async Task<ActionResult<DocTemplate>> Post(DocTemplate docTemplate)
        {
            return await docTemplateService.Add(docTemplate);
        }
        [HttpPut]
        public async Task<ActionResult<DocTemplate>> Put(DocTemplate docTemplate)
        {
            return await docTemplateService.Update(docTemplate);
        }
        [HttpDelete]
        public async Task<ActionResult<DocTemplate>> Delete(DocTemplate docTemplate)
        {
            return await docTemplateService.Delete(docTemplate);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
