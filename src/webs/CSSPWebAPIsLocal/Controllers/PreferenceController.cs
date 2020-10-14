/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using LocalServices;
using ReadGzFileServices;
using System.Linq;
using System.Threading;
using CSSPDBLoginServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IPreferenceController
    {
        Task<ActionResult<List<Preference>>> Get();
        Task<ActionResult<Preference>> AddOrChange(VarNameAndValue varNameAndValue);
        Task<ActionResult<bool>> Delete(int PreferenceID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class PreferenceController : ControllerBase, IPreferenceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IPreferenceService PreferenceService { get; }
        #endregion Properties

        #region Constructors
        public PreferenceController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPreferenceService PreferenceService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PreferenceService = PreferenceService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Preference>>> Get()
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PreferenceService.GetPreferenceList();
        }
        [HttpPost]
        public async Task<ActionResult<Preference>> AddOrChange(VarNameAndValue varNameAndValue)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PreferenceService.AddOrChange(varNameAndValue.VariableName, varNameAndValue.VariableValue);
        }
        [Route("{PreferenceID:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int PreferenceID)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PreferenceService.Delete(PreferenceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
