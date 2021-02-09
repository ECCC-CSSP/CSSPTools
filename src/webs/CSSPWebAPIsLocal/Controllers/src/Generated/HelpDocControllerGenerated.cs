/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IHelpDocController
    {
        Task<ActionResult<List<HelpDoc>>> Get();
        Task<ActionResult<HelpDoc>> Get(int HelpDocID);
        Task<ActionResult<HelpDoc>> Post(HelpDoc HelpDoc);
        Task<ActionResult<HelpDoc>> Put(HelpDoc HelpDoc);
        Task<ActionResult<bool>> Delete(int HelpDocID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class HelpDocController : ControllerBase, IHelpDocController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IHelpDocDBService HelpDocDBService { get; }
        #endregion Properties

        #region Constructors
        public HelpDocController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IHelpDocDBService HelpDocDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.HelpDocDBService = HelpDocDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HelpDoc>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await HelpDocDBService.GetHelpDocList();
        }
        [HttpGet("{HelpDocID}")]
        public async Task<ActionResult<HelpDoc>> Get(int HelpDocID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await HelpDocDBService.GetHelpDocWithHelpDocID(HelpDocID);
        }
        [HttpPost]
        public async Task<ActionResult<HelpDoc>> Post(HelpDoc HelpDoc)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await HelpDocDBService.Post(HelpDoc);
        }
        [HttpPut]
        public async Task<ActionResult<HelpDoc>> Put(HelpDoc HelpDoc)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await HelpDocDBService.Put(HelpDoc);
        }
        [HttpDelete("{HelpDocID}")]
        public async Task<ActionResult<bool>> Delete(int HelpDocID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await HelpDocDBService.Delete(HelpDocID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}