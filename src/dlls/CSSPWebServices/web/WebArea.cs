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
        public async Task<ActionResult<WebArea>> GetWebArea(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Area;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == TVTypeEnum.Area
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Area }]");
            }

            WebArea webArea = new WebArea();

            try
            {
                webArea.TVItemList = (from c in db.TVItems
                                      where c.TVItemID == TVItemID
                                      && c.TVType == tvType
                                      select c).AsNoTracking().ToList();
                webArea.TVItemLanguageList = (from c in db.TVItems
                                              from cl in db.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && c.TVItemID == TVItemID
                                              && c.TVType == tvType
                                              select cl).AsNoTracking().ToList();
                webArea.TVItemStatList = (from c in db.TVItems
                                          from cs in db.TVItemStats
                                          where c.TVItemID == cs.TVItemID
                                          && c.TVItemID == TVItemID
                                          && c.TVType == tvType
                                          select cs).AsNoTracking().ToList();
                webArea.MapInfoList = (from c in db.TVItems
                                       from mi in db.MapInfos
                                       where c.TVItemID == mi.TVItemID
                                       && c.TVItemID == TVItemID
                                       && c.TVType == tvType
                                       select mi).AsNoTracking().ToList();
                webArea.MapInfoPointList = (from c in db.TVItems
                                            from mi in db.MapInfos
                                            from mip in db.MapInfoPoints
                                            where c.TVItemID == mi.TVItemID
                                            && mi.MapInfoID == mip.MapInfoID
                                            && c.TVItemID == TVItemID
                                            && c.TVType == tvType
                                            select mip).AsNoTracking().ToList();
                webArea.TVFileList = (from c in db.TVItems
                                      from cf in db.TVItems
                                      from f in db.TVFiles
                                      where c.TVItemID == cf.ParentID
                                      && cf.TVType == TVTypeEnum.File
                                      && f.TVFileTVItemID == cf.TVItemID
                                      && c.TVItemID == TVItemID
                                      && c.TVType == tvType
                                      select f).AsNoTracking().ToList();
                webArea.TVFileLanguageList = (from c in db.TVItems
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
                webArea.TVItemSectorList = (from c in db.TVItems
                                            where c.TVPath.Contains(tvItem.TVPath + "p")
                                            && c.ParentID == tvItem.TVItemID
                                            && c.TVType == TVTypeEnum.Sector
                                            select c).AsNoTracking().ToList();
                webArea.TVItemLanguageSectorList = (from c in db.TVItems
                                                    from cl in db.TVItemLanguages
                                                    where c.TVItemID == cl.TVItemID
                                                    && c.TVPath.Contains(tvItem.TVPath + "p")
                                                    && c.ParentID == tvItem.TVItemID
                                                    && c.TVType == TVTypeEnum.Sector
                                                    select cl).AsNoTracking().ToList();
                webArea.TVItemStatSectorList = (from c in db.TVItems
                                                from cs in db.TVItemStats
                                                where c.TVItemID == cs.TVItemID
                                                && c.TVPath.Contains(tvItem.TVPath + "p")
                                                && c.ParentID == tvItem.TVItemID
                                                && c.TVType == TVTypeEnum.Sector
                                                select cs).AsNoTracking().ToList();
                webArea.MapInfoSectorList = (from c in db.TVItems
                                             from mi in db.MapInfos
                                             where c.TVItemID == mi.TVItemID
                                             && c.TVPath.Contains(tvItem.TVPath + "p")
                                             && c.ParentID == tvItem.TVItemID
                                             && c.TVType == TVTypeEnum.Sector
                                             select mi).AsNoTracking().ToList();
                webArea.MapInfoPointSectorList = (from c in db.TVItems
                                                  from mi in db.MapInfos
                                                  from mip in db.MapInfoPoints
                                                  where c.TVItemID == mi.TVItemID
                                                  && mi.MapInfoID == mip.MapInfoID
                                                  && c.TVPath.Contains(tvItem.TVPath + "p")
                                                  && c.ParentID == tvItem.TVItemID
                                                  && c.TVType == TVTypeEnum.Sector
                                                  select mip).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webArea));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
