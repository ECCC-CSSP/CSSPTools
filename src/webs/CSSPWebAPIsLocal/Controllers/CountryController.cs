/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPReadGzFileServices;
using System.Threading;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using CSSPDBLocalServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ICountryController
    {
        Task<ActionResult<TVItemModel>> AddCountryLocal(int ParentTVItemID);
        Task<ActionResult<TVItemModel>> DeleteCountryLocal(int TVItemID);
        Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocal(int TVItemID, string TVTextEN, string TVTextFR);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class CountryLocalController : ControllerBase, ICountryController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICountryLocalService CountryLocalService { get; }
        #endregion Properties

        #region Constructors
        public CountryLocalController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
            ICountryLocalService CountryLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.CountryLocalService = CountryLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpPost]
        public async Task<ActionResult<TVItemModel>> AddCountryLocal(int ParentTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await CountryLocalService.AddCountryLocalAsync(ParentTVItemID);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItemModel>> DeleteCountryLocal(int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocal(int TVItemID, string TVTextEN, string TVTextFR)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
