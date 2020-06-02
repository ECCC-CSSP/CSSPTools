using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IBoxModelLanguageController
    {
        Task<ActionResult<List<BoxModelLanguage>>> Get();
        Task<ActionResult<BoxModelLanguage>> Get(int BoxModelLanguageID);
        Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxModelLanguage);
        Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxModelLanguage);
        Task<ActionResult<BoxModelLanguage>> Delete(BoxModelLanguage boxModelLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class BoxModelLanguageController : ControllerBase, IBoxModelLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IBoxModelLanguageService boxModelLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageController(IBoxModelLanguageService boxModelLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.boxModelLanguageService = boxModelLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModelLanguage>>> Get()
        {
            return await boxModelLanguageService.GetBoxModelLanguageList();
        }
        [HttpGet("{BoxModelLanguageID}")]
        public async Task<ActionResult<BoxModelLanguage>> Get(int BoxModelLanguageID)
        {
            return await boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(BoxModelLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage boxModelLanguage)
        {
            return await boxModelLanguageService.Add(boxModelLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage boxModelLanguage)
        {
            return await boxModelLanguageService.Update(boxModelLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<BoxModelLanguage>> Delete(BoxModelLanguage boxModelLanguage)
        {
            return await boxModelLanguageService.Delete(boxModelLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
