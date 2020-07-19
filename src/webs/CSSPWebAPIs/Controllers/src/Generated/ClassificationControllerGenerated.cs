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
    public partial interface IClassificationController
    {
        Task<ActionResult<List<Classification>>> Get();
        Task<ActionResult<Classification>> Get(int ClassificationID);
        Task<ActionResult<Classification>> Post(Classification Classification);
        Task<ActionResult<Classification>> Put(Classification Classification);
        Task<ActionResult<bool>> Delete(int ClassificationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ClassificationController : ControllerBase, IClassificationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IClassificationService ClassificationService { get; }
        #endregion Properties

        #region Constructors
        public ClassificationController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IClassificationService ClassificationService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ClassificationService = ClassificationService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Classification>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ClassificationService.GetClassificationList();
        }
        [HttpGet("{ClassificationID}")]
        public async Task<ActionResult<Classification>> Get(int ClassificationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ClassificationService.GetClassificationWithClassificationID(ClassificationID);
        }
        [HttpPost]
        public async Task<ActionResult<Classification>> Post(Classification Classification)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ClassificationService.Post(Classification);
        }
        [HttpPut]
        public async Task<ActionResult<Classification>> Put(Classification Classification)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ClassificationService.Put(Classification);
        }
        [HttpDelete("{ClassificationID}")]
        public async Task<ActionResult<bool>> Delete(int ClassificationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ClassificationService.Delete(ClassificationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
