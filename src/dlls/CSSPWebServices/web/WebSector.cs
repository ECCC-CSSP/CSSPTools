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

namespace CSSPWebServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        public async Task<ActionResult<WebSector>> GetWebSector(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Sector;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == TVTypeEnum.Sector
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Sector }]");
            }

            WebSector webSector = new WebSector();

            try
            {
                webSector.TVItemList = (from c in db.TVItems
                                        where c.TVItemID == TVItemID
                                        && c.TVType == tvType
                                        select c).AsNoTracking().ToList();
                webSector.TVItemLanguageList = (from c in db.TVItems
                                                from cl in db.TVItemLanguages
                                                where c.TVItemID == cl.TVItemID
                                                && c.TVItemID == TVItemID
                                                && c.TVType == tvType
                                                select cl).AsNoTracking().ToList();
                webSector.TVItemStatList = (from c in db.TVItems
                                            from cs in db.TVItemStats
                                            where c.TVItemID == cs.TVItemID
                                            && c.TVItemID == TVItemID
                                            && c.TVType == tvType
                                            select cs).AsNoTracking().ToList();
                webSector.MapInfoList = (from c in db.TVItems
                                         from mi in db.MapInfos
                                         where c.TVItemID == mi.TVItemID
                                         && c.TVItemID == TVItemID
                                         && c.TVType == tvType
                                         select mi).AsNoTracking().ToList();
                webSector.MapInfoPointList = (from c in db.TVItems
                                              from mi in db.MapInfos
                                              from mip in db.MapInfoPoints
                                              where c.TVItemID == mi.TVItemID
                                              && mi.MapInfoID == mip.MapInfoID
                                              && c.TVItemID == TVItemID
                                              && c.TVType == tvType
                                              select mip).AsNoTracking().ToList();
                webSector.TVFileList = (from c in db.TVItems
                                        from cf in db.TVItems
                                        from f in db.TVFiles
                                        where c.TVItemID == cf.ParentID
                                        && cf.TVType == TVTypeEnum.File
                                        && f.TVFileTVItemID == cf.TVItemID
                                        && c.TVItemID == TVItemID
                                        && c.TVType == tvType
                                        select f).AsNoTracking().ToList();
                webSector.TVFileLanguageList = (from c in db.TVItems
                                                from cf in db.TVItems
                                                from f in db.TVFiles
                                                from fl in db.TVFileLanguages
                                                where c.TVItemID == cf.ParentID
                                                && cf.TVType == TVTypeEnum.File
                                                && f.TVFileTVItemID == cf.TVItemID
                                                && f.TVFileID == fl.TVFileID
                                                && c.TVItemID == TVItemID
                                                && c.TVType == tvType
                                                select fl).AsNoTracking().ToList();
                webSector.TVItemSubsectorList = (from c in db.TVItems
                                                 where c.TVPath.Contains(tvItem.TVPath + "p")
                                                 && c.ParentID == tvItem.TVItemID
                                                 && c.TVType == TVTypeEnum.Subsector
                                                 select c).AsNoTracking().ToList();
                webSector.TVItemLanguageSubsectorList = (from c in db.TVItems
                                                         from cl in db.TVItemLanguages
                                                         where c.TVItemID == cl.TVItemID
                                                         && c.TVPath.Contains(tvItem.TVPath + "p")
                                                         && c.ParentID == tvItem.TVItemID
                                                         && c.TVType == TVTypeEnum.Subsector
                                                         select cl).AsNoTracking().ToList();
                webSector.TVItemStatSubsectorList = (from c in db.TVItems
                                                     from cs in db.TVItemStats
                                                     where c.TVItemID == cs.TVItemID
                                                     && c.TVPath.Contains(tvItem.TVPath + "p")
                                                     && c.ParentID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.Subsector
                                                     select cs).AsNoTracking().ToList();
                webSector.MapInfoSubsectorList = (from c in db.TVItems
                                                  from mi in db.MapInfos
                                                  where c.TVItemID == mi.TVItemID
                                                  && c.TVPath.Contains(tvItem.TVPath + "p")
                                                  && c.ParentID == tvItem.TVItemID
                                                  && c.TVType == TVTypeEnum.Subsector
                                                  select mi).AsNoTracking().ToList();
                webSector.MapInfoPointSubsectorList = (from c in db.TVItems
                                                       from mi in db.MapInfos
                                                       from mip in db.MapInfoPoints
                                                       where c.TVItemID == mi.TVItemID
                                                       && mi.MapInfoID == mip.MapInfoID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.Subsector
                                                       select mip).AsNoTracking().ToList();
                webSector.TVItemMikeScenarioList = (from c in db.TVItems
                                                    where c.TVPath.Contains(tvItem.TVPath + "p")
                                                    && c.ParentID == tvItem.TVItemID
                                                    && c.TVType == TVTypeEnum.MikeScenario
                                                    select c).AsNoTracking().ToList();
                webSector.TVItemLanguageMikeScenarioList = (from c in db.TVItems
                                                            from cl in db.TVItemLanguages
                                                            where c.TVItemID == cl.TVItemID
                                                            && c.TVPath.Contains(tvItem.TVPath + "p")
                                                            && c.ParentID == tvItem.TVItemID
                                                            && c.TVType == TVTypeEnum.MikeScenario
                                                            select cl).AsNoTracking().ToList();
                webSector.TVItemStatMikeScenarioList = (from c in db.TVItems
                                                        from cs in db.TVItemStats
                                                        where c.TVItemID == cs.TVItemID
                                                        && c.TVPath.Contains(tvItem.TVPath + "p")
                                                        && c.ParentID == tvItem.TVItemID
                                                        && c.TVType == TVTypeEnum.MikeScenario
                                                        select cs).AsNoTracking().ToList();
                webSector.MapInfoMikeScenarioList = (from c in db.TVItems
                                                     from mi in db.MapInfos
                                                     where c.TVItemID == mi.TVItemID
                                                     && c.TVPath.Contains(tvItem.TVPath + "p")
                                                     && c.ParentID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.MikeScenario
                                                     select mi).AsNoTracking().ToList();
                webSector.MapInfoPointMikeScenarioList = (from c in db.TVItems
                                                          from mi in db.MapInfos
                                                          from mip in db.MapInfoPoints
                                                          where c.TVItemID == mi.TVItemID
                                                          && mi.MapInfoID == mip.MapInfoID
                                                          && c.TVPath.Contains(tvItem.TVPath + "p")
                                                          && c.ParentID == tvItem.TVItemID
                                                          && c.TVType == TVTypeEnum.MikeScenario
                                                          select mip).AsNoTracking().ToList();
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
