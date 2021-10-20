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
    public partial interface ITVItemController
    {
        Task<ActionResult<bool>> Delete(TVItemLocalModel postTVItemModel);
        Task<ActionResult<bool>> Add(TVItemLocalModel postTVItemModel);
        Task<ActionResult<bool>> Modify(TVItemLocalModel postTVItemModel);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TVItemController : ControllerBase, ITVItemController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ITVItemLocalService TVItemService { get; }
        #endregion Properties

        #region Constructors
        public TVItemController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
            ITVItemLocalService PostTVItemModelService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.TVItemService = PostTVItemModelService;
        }
        #endregion Constructors

        #region Functions public
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(TVItemLocalModel postTVItemModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await TVItemService.DeleteTVItemLocal(postTVItemModel);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Add(TVItemLocalModel postTVItemModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await TVItemService.AddTVItemLocal(postTVItemModel);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Modify(TVItemLocalModel postTVItemModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await TVItemService.ModifyTVItemLocal(postTVItemModel);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
