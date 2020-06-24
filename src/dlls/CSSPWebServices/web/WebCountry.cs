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
        public async Task<ActionResult<WebCountry>> GetWebCountry(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Country;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == TVTypeEnum.Country
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Country }]");
            }

            WebCountry webCountry = new WebCountry();

            try
            {
                webCountry.TVItemList = (from c in db.TVItems
                                         where c.TVItemID == TVItemID
                                         && c.TVType == tvType
                                         select c).AsNoTracking().ToList();
                webCountry.TVItemLanguageList = (from c in db.TVItems
                                                 from cl in db.TVItemLanguages
                                                 where c.TVItemID == cl.TVItemID
                                                 && c.TVItemID == TVItemID
                                                 && c.TVType == tvType
                                                 select cl).AsNoTracking().ToList();
                webCountry.TVItemStatList = (from c in db.TVItems
                                             from cs in db.TVItemStats
                                             where c.TVItemID == cs.TVItemID
                                             && c.TVItemID == TVItemID
                                             && c.TVType == tvType
                                             select cs).AsNoTracking().ToList();
                webCountry.MapInfoList = (from c in db.TVItems
                                          from mi in db.MapInfos
                                          where c.TVItemID == mi.TVItemID
                                          && c.TVItemID == TVItemID
                                          && c.TVType == tvType
                                          select mi).AsNoTracking().ToList();
                webCountry.MapInfoPointList = (from c in db.TVItems
                                               from mi in db.MapInfos
                                               from mip in db.MapInfoPoints
                                               where c.TVItemID == mi.TVItemID
                                               && mi.MapInfoID == mip.MapInfoID
                                               && c.TVItemID == TVItemID
                                               && c.TVType == tvType
                                               select mip).AsNoTracking().ToList();
                webCountry.TVFileList = (from c in db.TVItems
                                         from cf in db.TVItems
                                         from f in db.TVFiles
                                         where c.TVItemID == cf.ParentID
                                         && cf.TVType == TVTypeEnum.File
                                         && f.TVFileTVItemID == cf.TVItemID
                                         && c.TVItemID == TVItemID
                                         && c.TVType == tvType
                                         select f).AsNoTracking().ToList();
                webCountry.TVFileLanguageList = (from c in db.TVItems
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
                webCountry.TVItemProvinceList = (from c in db.TVItems
                                                 where c.TVPath.Contains(tvItem.TVPath + "p")
                                                 && c.ParentID == tvItem.TVItemID
                                                 && c.TVType == TVTypeEnum.Province
                                                 select c).AsNoTracking().ToList();
                webCountry.TVItemLanguageProvinceList = (from c in db.TVItems
                                                         from cl in db.TVItemLanguages
                                                         where c.TVItemID == cl.TVItemID
                                                         && c.TVPath.Contains(tvItem.TVPath + "p")
                                                         && c.ParentID == tvItem.TVItemID
                                                         && c.TVType == TVTypeEnum.Province
                                                         select cl).AsNoTracking().ToList();
                webCountry.TVItemStatProvinceList = (from c in db.TVItems
                                                     from cs in db.TVItemStats
                                                     where c.TVItemID == cs.TVItemID
                                                     && c.TVPath.Contains(tvItem.TVPath + "p")
                                                     && c.ParentID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.Province
                                                     select cs).AsNoTracking().ToList();
                webCountry.MapInfoProvinceList = (from c in db.TVItems
                                                  from mi in db.MapInfos
                                                  where c.TVItemID == mi.TVItemID
                                                  && c.TVPath.Contains(tvItem.TVPath + "p")
                                                  && c.ParentID == tvItem.TVItemID
                                                  && c.TVType == TVTypeEnum.Province
                                                  select mi).AsNoTracking().ToList();
                webCountry.MapInfoPointProvinceList = (from c in db.TVItems
                                                       from mi in db.MapInfos
                                                       from mip in db.MapInfoPoints
                                                       where c.TVItemID == mi.TVItemID
                                                       && mi.MapInfoID == mip.MapInfoID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.Province
                                                       select mip).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webCountry));
        }
    }
}
