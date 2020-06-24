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
        public async Task<ActionResult<WebSubsector>> GetWebSubsector(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Subsector;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == TVTypeEnum.Subsector
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Subsector }]");
            }

            WebSubsector webSubsector = new WebSubsector();

            try
            {
                webSubsector.TVItemList = (from c in db.TVItems
                                           where c.TVItemID == TVItemID
                                           && c.TVType == tvType
                                           select c).AsNoTracking().ToList();
                webSubsector.TVItemLanguageList = (from c in db.TVItems
                                                   from cl in db.TVItemLanguages
                                                   where c.TVItemID == cl.TVItemID
                                                   && c.TVItemID == TVItemID
                                                   && c.TVType == tvType
                                                   select cl).AsNoTracking().ToList();
                webSubsector.TVItemStatList = (from c in db.TVItems
                                               from cs in db.TVItemStats
                                               where c.TVItemID == cs.TVItemID
                                               && c.TVItemID == TVItemID
                                               && c.TVType == tvType
                                               select cs).AsNoTracking().ToList();
                webSubsector.MapInfoList = (from c in db.TVItems
                                            from mi in db.MapInfos
                                            where c.TVItemID == mi.TVItemID
                                            && c.TVItemID == TVItemID
                                            && c.TVType == tvType
                                            select mi).AsNoTracking().ToList();
                webSubsector.MapInfoPointList = (from c in db.TVItems
                                                 from mi in db.MapInfos
                                                 from mip in db.MapInfoPoints
                                                 where c.TVItemID == mi.TVItemID
                                                 && mi.MapInfoID == mip.MapInfoID
                                                 && c.TVItemID == TVItemID
                                                 && c.TVType == tvType
                                                 select mip).AsNoTracking().ToList();
                webSubsector.TVFileList = (from c in db.TVItems
                                           from cf in db.TVItems
                                           from f in db.TVFiles
                                           where c.TVItemID == cf.ParentID
                                           && cf.TVType == TVTypeEnum.File
                                           && f.TVFileTVItemID == cf.TVItemID
                                           && c.TVItemID == TVItemID
                                           && c.TVType == tvType
                                           select f).AsNoTracking().ToList();
                webSubsector.TVFileLanguageList = (from c in db.TVItems
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
                webSubsector.TVItemMWQMSiteList = (from c in db.TVItems
                                                 where c.TVPath.Contains(tvItem.TVPath + "p")
                                                 && c.ParentID == tvItem.TVItemID
                                                 && c.TVType == TVTypeEnum.MWQMSite
                                                   select c).AsNoTracking().ToList();
                webSubsector.TVItemLanguageMWQMSiteList = (from c in db.TVItems
                                                         from cl in db.TVItemLanguages
                                                         where c.TVItemID == cl.TVItemID
                                                         && c.TVPath.Contains(tvItem.TVPath + "p")
                                                         && c.ParentID == tvItem.TVItemID
                                                         && c.TVType == TVTypeEnum.MWQMSite
                                                           select cl).AsNoTracking().ToList();
                webSubsector.TVItemStatMWQMSiteList = (from c in db.TVItems
                                                     from cs in db.TVItemStats
                                                     where c.TVItemID == cs.TVItemID
                                                     && c.TVPath.Contains(tvItem.TVPath + "p")
                                                     && c.ParentID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.MWQMSite
                                                       select cs).AsNoTracking().ToList();
                webSubsector.MapInfoMWQMSiteList = (from c in db.TVItems
                                                  from mi in db.MapInfos
                                                  where c.TVItemID == mi.TVItemID
                                                  && c.TVPath.Contains(tvItem.TVPath + "p")
                                                  && c.ParentID == tvItem.TVItemID
                                                  && c.TVType == TVTypeEnum.MWQMSite
                                                    select mi).AsNoTracking().ToList();
                webSubsector.MapInfoPointMWQMSiteList = (from c in db.TVItems
                                                       from mi in db.MapInfos
                                                       from mip in db.MapInfoPoints
                                                       where c.TVItemID == mi.TVItemID
                                                       && mi.MapInfoID == mip.MapInfoID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.MWQMSite
                                                         select mip).AsNoTracking().ToList();
                webSubsector.TVItemMWQMRunList = (from c in db.TVItems
                                                   where c.TVPath.Contains(tvItem.TVPath + "p")
                                                   && c.ParentID == tvItem.TVItemID
                                                   && c.TVType == TVTypeEnum.MWQMRun
                                                   select c).AsNoTracking().ToList();
                webSubsector.TVItemLanguageMWQMRunList = (from c in db.TVItems
                                                           from cl in db.TVItemLanguages
                                                           where c.TVItemID == cl.TVItemID
                                                           && c.TVPath.Contains(tvItem.TVPath + "p")
                                                           && c.ParentID == tvItem.TVItemID
                                                           && c.TVType == TVTypeEnum.MWQMRun
                                                           select cl).AsNoTracking().ToList();
                webSubsector.TVItemStatMWQMRunList = (from c in db.TVItems
                                                       from cs in db.TVItemStats
                                                       where c.TVItemID == cs.TVItemID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.MWQMRun
                                                       select cs).AsNoTracking().ToList();
                webSubsector.TVItemPolSourceSiteList = (from c in db.TVItems
                                                   where c.TVPath.Contains(tvItem.TVPath + "p")
                                                   && c.ParentID == tvItem.TVItemID
                                                   && c.TVType == TVTypeEnum.PolSourceSite
                                                        select c).AsNoTracking().ToList();
                webSubsector.TVItemLanguagePolSourceSiteList = (from c in db.TVItems
                                                           from cl in db.TVItemLanguages
                                                           where c.TVItemID == cl.TVItemID
                                                           && c.TVPath.Contains(tvItem.TVPath + "p")
                                                           && c.ParentID == tvItem.TVItemID
                                                           && c.TVType == TVTypeEnum.PolSourceSite
                                                                select cl).AsNoTracking().ToList();
                webSubsector.TVItemStatPolSourceSiteList = (from c in db.TVItems
                                                       from cs in db.TVItemStats
                                                       where c.TVItemID == cs.TVItemID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.PolSourceSite
                                                            select cs).AsNoTracking().ToList();
                webSubsector.MapInfoPolSourceSiteList = (from c in db.TVItems
                                                    from mi in db.MapInfos
                                                    where c.TVItemID == mi.TVItemID
                                                    && c.TVPath.Contains(tvItem.TVPath + "p")
                                                    && c.ParentID == tvItem.TVItemID
                                                    && c.TVType == TVTypeEnum.PolSourceSite
                                                         select mi).AsNoTracking().ToList();
                webSubsector.MapInfoPointPolSourceSiteList = (from c in db.TVItems
                                                         from mi in db.MapInfos
                                                         from mip in db.MapInfoPoints
                                                         where c.TVItemID == mi.TVItemID
                                                         && mi.MapInfoID == mip.MapInfoID
                                                         && c.TVPath.Contains(tvItem.TVPath + "p")
                                                         && c.ParentID == tvItem.TVItemID
                                                         && c.TVType == TVTypeEnum.PolSourceSite
                                                              select mip).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSubsector));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
