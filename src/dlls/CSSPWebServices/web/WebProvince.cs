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
        public async Task<ActionResult<WebProvince>> GetWebProvince(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Province;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             && c.TVType == TVTypeEnum.Province
                             select c).FirstOrDefault();

            if (tvItem == null)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Province }]");
            }

            WebProvince webProvince = new WebProvince();

            try
            {
                webProvince.TVItemList = (from c in db.TVItems
                                          where c.TVItemID == TVItemID
                                          && c.TVType == tvType
                                          select c).AsNoTracking().ToList();
                webProvince.TVItemLanguageList = (from c in db.TVItems
                                                  from cl in db.TVItemLanguages
                                                  where c.TVItemID == cl.TVItemID
                                                  && c.TVItemID == TVItemID
                                                  && c.TVType == tvType
                                                  select cl).AsNoTracking().ToList();
                webProvince.TVItemStatList = (from c in db.TVItems
                                              from cs in db.TVItemStats
                                              where c.TVItemID == cs.TVItemID
                                              && c.TVItemID == TVItemID
                                              && c.TVType == tvType
                                              select cs).AsNoTracking().ToList();
                webProvince.MapInfoList = (from c in db.TVItems
                                           from mi in db.MapInfos
                                           where c.TVItemID == mi.TVItemID
                                           && c.TVItemID == TVItemID
                                           && c.TVType == tvType
                                           select mi).AsNoTracking().ToList();
                webProvince.MapInfoPointList = (from c in db.TVItems
                                                from mi in db.MapInfos
                                                from mip in db.MapInfoPoints
                                                where c.TVItemID == mi.TVItemID
                                                && mi.MapInfoID == mip.MapInfoID
                                                && c.TVItemID == TVItemID
                                                && c.TVType == tvType
                                                select mip).AsNoTracking().ToList();
                webProvince.TVFileList = (from c in db.TVItems
                                          from cf in db.TVItems
                                          from f in db.TVFiles
                                          where c.TVItemID == cf.ParentID
                                          && cf.TVType == TVTypeEnum.File
                                          && f.TVFileTVItemID == cf.TVItemID
                                          && c.TVItemID == TVItemID
                                          && c.TVType == tvType
                                          select f).AsNoTracking().ToList();
                webProvince.TVFileLanguageList = (from c in db.TVItems
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
                webProvince.TVItemAreaList = (from c in db.TVItems
                                              where c.TVPath.Contains(tvItem.TVPath + "p")
                                              && c.ParentID == tvItem.TVItemID
                                              && c.TVType == TVTypeEnum.Area
                                              select c).AsNoTracking().ToList();
                webProvince.TVItemLanguageAreaList = (from c in db.TVItems
                                                      from cl in db.TVItemLanguages
                                                      where c.TVItemID == cl.TVItemID
                                                      && c.TVPath.Contains(tvItem.TVPath + "p")
                                                      && c.ParentID == tvItem.TVItemID
                                                      && c.TVType == TVTypeEnum.Area
                                                      select cl).AsNoTracking().ToList();
                webProvince.TVItemStatAreaList = (from c in db.TVItems
                                                  from cs in db.TVItemStats
                                                  where c.TVItemID == cs.TVItemID
                                                  && c.TVPath.Contains(tvItem.TVPath + "p")
                                                  && c.ParentID == tvItem.TVItemID
                                                  && c.TVType == TVTypeEnum.Area
                                                  select cs).AsNoTracking().ToList();
                webProvince.MapInfoAreaList = (from c in db.TVItems
                                               from mi in db.MapInfos
                                               where c.TVItemID == mi.TVItemID
                                               && c.TVPath.Contains(tvItem.TVPath + "p")
                                               && c.ParentID == tvItem.TVItemID
                                               && c.TVType == TVTypeEnum.Area
                                               select mi).AsNoTracking().ToList();
                webProvince.MapInfoPointAreaList = (from c in db.TVItems
                                                    from mi in db.MapInfos
                                                    from mip in db.MapInfoPoints
                                                    where c.TVItemID == mi.TVItemID
                                                    && mi.MapInfoID == mip.MapInfoID
                                                    && c.TVPath.Contains(tvItem.TVPath + "p")
                                                    && c.ParentID == tvItem.TVItemID
                                                    && c.TVType == TVTypeEnum.Area
                                                    select mip).AsNoTracking().ToList();
                webProvince.TVItemMunicipalityList = (from c in db.TVItems
                                                      where c.TVPath.Contains(tvItem.TVPath + "p")
                                                      && c.ParentID == tvItem.TVItemID
                                                      && c.TVType == TVTypeEnum.Municipality
                                                      select c).AsNoTracking().ToList();
                webProvince.TVItemLanguageMunicipalityList = (from c in db.TVItems
                                                              from cl in db.TVItemLanguages
                                                              where c.TVItemID == cl.TVItemID
                                                              && c.TVPath.Contains(tvItem.TVPath + "p")
                                                              && c.ParentID == tvItem.TVItemID
                                                              && c.TVType == TVTypeEnum.Municipality
                                                              select cl).AsNoTracking().ToList();
                webProvince.TVItemStatMunicipalityList = (from c in db.TVItems
                                                          from cs in db.TVItemStats
                                                          where c.TVItemID == cs.TVItemID
                                                          && c.TVPath.Contains(tvItem.TVPath + "p")
                                                          && c.ParentID == tvItem.TVItemID
                                                          && c.TVType == TVTypeEnum.Municipality
                                                          select cs).AsNoTracking().ToList();
                webProvince.MapInfoMunicipalityList = (from c in db.TVItems
                                                       from mi in db.MapInfos
                                                       where c.TVItemID == mi.TVItemID
                                                       && c.TVPath.Contains(tvItem.TVPath + "p")
                                                       && c.ParentID == tvItem.TVItemID
                                                       && c.TVType == TVTypeEnum.Municipality
                                                       select mi).AsNoTracking().ToList();
                webProvince.MapInfoPointMunicipalityList = (from c in db.TVItems
                                                            from mi in db.MapInfos
                                                            from mip in db.MapInfoPoints
                                                            where c.TVItemID == mi.TVItemID
                                                            && mi.MapInfoID == mip.MapInfoID
                                                            && c.TVPath.Contains(tvItem.TVPath + "p")
                                                            && c.ParentID == tvItem.TVItemID
                                                            && c.TVType == TVTypeEnum.Municipality
                                                            select mip).AsNoTracking().ToList();
                webProvince.SamplingPlanList = (from c in db.SamplingPlans
                                                where c.ProvinceTVItemID == tvItem.TVItemID
                                                select c).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webProvince));
        }
    }
}
