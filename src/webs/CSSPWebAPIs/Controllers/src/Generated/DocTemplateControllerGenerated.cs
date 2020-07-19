/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IDocTemplateController
    {
        Task<ActionResult<List<DocTemplate>>> Get();
        Task<ActionResult<DocTemplate>> Get(int DocTemplateID);
        Task<ActionResult<DocTemplate>> Post(DocTemplate DocTemplate);
        Task<ActionResult<DocTemplate>> Put(DocTemplate DocTemplate);
        Task<ActionResult<bool>> Delete(int DocTemplateID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DocTemplateController : ControllerBase, IDocTemplateController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IDocTemplateService DocTemplateService { get; }
        #endregion Properties

        #region Constructors
        public DocTemplateController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IDocTemplateService DocTemplateService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.DocTemplateService = DocTemplateService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DocTemplate>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DocTemplateService.GetDocTemplateList();
        }
        [HttpGet("{DocTemplateID}")]
        public async Task<ActionResult<DocTemplate>> Get(int DocTemplateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DocTemplateService.GetDocTemplateWithDocTemplateID(DocTemplateID);
        }
        [HttpPost]
        public async Task<ActionResult<DocTemplate>> Post(DocTemplate DocTemplate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DocTemplateService.Post(DocTemplate);
        }
        [HttpPut]
        public async Task<ActionResult<DocTemplate>> Put(DocTemplate DocTemplate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DocTemplateService.Put(DocTemplate);
        }
        [HttpDelete("{DocTemplateID}")]
        public async Task<ActionResult<bool>> Delete(int DocTemplateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DocTemplateService.Delete(DocTemplateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
