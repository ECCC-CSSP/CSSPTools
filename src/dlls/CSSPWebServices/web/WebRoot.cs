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
        public async Task<ActionResult<WebRoot>> GetWebRoot()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Root;

            TVItem tvItemRoot = (from c in db.TVItems
                                 where c.TVLevel == 0
                                 && c.TVType == TVTypeEnum.Root
                                 select c).FirstOrDefault();

            if (tvItemRoot == null)
            {
                return BadRequest("TVItemRoot could not be found");
            }
            
            WebRoot webRoot = new WebRoot();

            try
            {
                webRoot.TVItemList = (from c in db.TVItems
                                      where c.TVType == tvType
                                      select c).AsNoTracking().ToList();
                webRoot.TVItemLanguageList = (from c in db.TVItems
                                              from cl in db.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && c.TVType == tvType
                                              select cl).AsNoTracking().ToList();
                webRoot.TVItemStatList = (from c in db.TVItems
                                          from cs in db.TVItemStats
                                          where c.TVItemID == cs.TVItemID
                                          && c.TVType == tvType
                                          select cs).AsNoTracking().ToList();
                webRoot.MapInfoList = (from c in db.TVItems
                                       from mi in db.MapInfos
                                       where c.TVItemID == mi.TVItemID
                                       && c.TVType == tvType
                                       select mi).AsNoTracking().ToList();
                webRoot.MapInfoPointList = (from c in db.TVItems
                                            from mi in db.MapInfos
                                            from mip in db.MapInfoPoints
                                            where c.TVItemID == mi.TVItemID
                                            && mi.MapInfoID == mip.MapInfoID
                                            && c.TVType == tvType
                                            select mip).AsNoTracking().ToList();
                webRoot.TVFileList = (from c in db.TVItems
                                      from cf in db.TVItems
                                      from f in db.TVFiles
                                      where c.TVItemID == cf.ParentID
                                      && cf.TVType == TVTypeEnum.File
                                      && f.TVFileTVItemID == cf.TVItemID
                                      && c.TVType == tvType
                                      select f).AsNoTracking().ToList();
                webRoot.TVFileLanguageList = (from c in db.TVItems
                                              from cf in db.TVItems
                                              from f in db.TVFiles
                                              from fl in db.TVFileLanguages
                                              where c.TVItemID == cf.ParentID
                                              && cf.TVType == TVTypeEnum.File
                                              && f.TVFileTVItemID == cf.TVItemID
                                              && f.TVFileID == fl.TVFileID
                                              && c.TVType == tvType
                                              select fl).AsNoTracking().ToList();
                webRoot.TVItemCountryList = (from c in db.TVItems
                                             where c.TVPath.Contains(tvItemRoot.TVPath + "p")
                                             && c.ParentID == tvItemRoot.TVItemID
                                             && c.TVType == TVTypeEnum.Country
                                             select c).AsNoTracking().ToList();
                webRoot.TVItemLanguageCountryList = (from c in db.TVItems
                                                     from cl in db.TVItemLanguages
                                                     where c.TVItemID == cl.TVItemID
                                                     && c.TVPath.Contains(tvItemRoot.TVPath + "p")
                                                     && c.ParentID == tvItemRoot.TVItemID
                                                     && c.TVType == TVTypeEnum.Country
                                                     select cl).AsNoTracking().ToList();
                webRoot.TVItemStatCountryList = (from c in db.TVItems
                                                 from cs in db.TVItemStats
                                                 where c.TVItemID == cs.TVItemID
                                                 && c.TVPath.Contains(tvItemRoot.TVPath + "p")
                                                 && c.ParentID == tvItemRoot.TVItemID
                                                 && c.TVType == TVTypeEnum.Country
                                                 select cs).AsNoTracking().ToList();
                webRoot.MapInfoCountryList = (from c in db.TVItems
                                              from mi in db.MapInfos
                                              where c.TVItemID == mi.TVItemID
                                              && c.TVPath.Contains(tvItemRoot.TVPath + "p")
                                              && c.ParentID == tvItemRoot.TVItemID
                                              && c.TVType == TVTypeEnum.Country
                                              select mi).AsNoTracking().ToList();
                webRoot.MapInfoPointCountryList = (from c in db.TVItems
                                                   from mi in db.MapInfos
                                                   from mip in db.MapInfoPoints
                                                   where c.TVItemID == mi.TVItemID
                                                   && mi.MapInfoID == mip.MapInfoID
                                                   && c.TVPath.Contains(tvItemRoot.TVPath + "p")
                                                   && c.ParentID == tvItemRoot.TVItemID
                                                   && c.TVType == TVTypeEnum.Country
                                                   select mip).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webRoot));
        }
    }
}
