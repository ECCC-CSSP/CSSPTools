/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        private async Task<ActionResult<WebSector>> DoGetWebSector(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Sector)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Sector }]");
            }

            WebSector webSector = new WebSector();

            try
            {
                webSector.TVItem = tvItem;

                webSector.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webSector.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webSector.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webSector.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webSector.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webSector.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webSector.TVItemSubsectorList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);

                webSector.TVItemLanguageSubsectorList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);

                webSector.TVItemStatSubsectorList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);

                webSector.MapInfoSubsectorList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);

                webSector.MapInfoPointSubsectorList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.Subsector);

                webSector.TVItemMikeScenarioList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webSector.TVItemLanguageMikeScenarioList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webSector.TVItemStatMikeScenarioList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webSector.MapInfoMikeScenarioList = GetMapInfoChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webSector.MapInfoPointMikeScenarioList = GetMapInfoPointChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSector));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
