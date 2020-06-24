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
    public interface IWebService
    {
        Task<ActionResult<WebRoot>> GetWebRoot();
        Task<ActionResult<WebCountry>> GetWebCountry();
        Task<ActionResult<WebArea>> GetWebArea();
        Task<ActionResult<WebSector>> GetWebSector();
        Task<ActionResult<WebSubsector>> GetWebSubsector();
    }
    public partial class WebService : ControllerBase, IWebService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public WebService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<WebRoot>> GetWebRoot()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Root;

            WebRoot webRoot = new WebRoot();

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

            return await Task.FromResult(Ok(webRoot));
        }
        public async Task<ActionResult<WebCountry>> GetWebCountry()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Country;

            WebCountry webCountry = new WebCountry();

            webCountry.TVItemList = (from c in db.TVItems
                                  where c.TVType == tvType
                                  select c).AsNoTracking().ToList();
            webCountry.TVItemLanguageList = (from c in db.TVItems
                                          from cl in db.TVItemLanguages
                                          where c.TVItemID == cl.TVItemID
                                          && c.TVType == tvType
                                          select cl).AsNoTracking().ToList();
            webCountry.TVItemStatList = (from c in db.TVItems
                                      from cs in db.TVItemStats
                                      where c.TVItemID == cs.TVItemID
                                      && c.TVType == tvType
                                      select cs).AsNoTracking().ToList();
            webCountry.MapInfoList = (from c in db.TVItems
                                   from mi in db.MapInfos
                                   where c.TVItemID == mi.TVItemID
                                   && c.TVType == tvType
                                   select mi).AsNoTracking().ToList();
            webCountry.MapInfoPointList = (from c in db.TVItems
                                        from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where c.TVItemID == mi.TVItemID
                                        && mi.MapInfoID == mip.MapInfoID
                                        && c.TVType == tvType
                                        select mip).AsNoTracking().ToList();

            return await Task.FromResult(Ok(webCountry));
        }
        public async Task<ActionResult<WebArea>> GetWebArea()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Area;

            WebArea webArea = new WebArea();

            webArea.TVItemList = (from c in db.TVItems
                                  where c.TVType == tvType
                                  select c).AsNoTracking().ToList();
            webArea.TVItemLanguageList = (from c in db.TVItems
                                          from cl in db.TVItemLanguages
                                          where c.TVItemID == cl.TVItemID
                                          && c.TVType == tvType
                                          select cl).AsNoTracking().ToList();
            webArea.TVItemStatList = (from c in db.TVItems
                                      from cs in db.TVItemStats
                                      where c.TVItemID == cs.TVItemID
                                      && c.TVType == tvType
                                      select cs).AsNoTracking().ToList();
            webArea.MapInfoList = (from c in db.TVItems
                                   from mi in db.MapInfos
                                   where c.TVItemID == mi.TVItemID
                                   && c.TVType == tvType
                                   select mi).AsNoTracking().ToList();
            webArea.MapInfoPointList = (from c in db.TVItems
                                        from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where c.TVItemID == mi.TVItemID
                                        && mi.MapInfoID == mip.MapInfoID
                                        && c.TVType == tvType
                                        select mip).AsNoTracking().ToList();

            return await Task.FromResult(Ok(webArea));
        }
        public async Task<ActionResult<WebSector>> GetWebSector()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Sector;

            WebSector webSector = new WebSector();

            webSector.TVItemList = (from c in db.TVItems
                                  where c.TVType == tvType
                                  select c).AsNoTracking().ToList();
            webSector.TVItemLanguageList = (from c in db.TVItems
                                          from cl in db.TVItemLanguages
                                          where c.TVItemID == cl.TVItemID
                                          && c.TVType == tvType
                                          select cl).AsNoTracking().ToList();
            webSector.TVItemStatList = (from c in db.TVItems
                                      from cs in db.TVItemStats
                                      where c.TVItemID == cs.TVItemID
                                      && c.TVType == tvType
                                      select cs).AsNoTracking().ToList();
            webSector.MapInfoList = (from c in db.TVItems
                                   from mi in db.MapInfos
                                   where c.TVItemID == mi.TVItemID
                                   && c.TVType == tvType
                                   select mi).AsNoTracking().ToList();
            webSector.MapInfoPointList = (from c in db.TVItems
                                        from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where c.TVItemID == mi.TVItemID
                                        && mi.MapInfoID == mip.MapInfoID
                                        && c.TVType == tvType
                                        select mip).AsNoTracking().ToList();

            return await Task.FromResult(Ok(webSector));
        }
        public async Task<ActionResult<WebSubsector>> GetWebSubsector()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVTypeEnum tvType = TVTypeEnum.Subsector;

            WebSubsector webSubsector = new WebSubsector();

            webSubsector.TVItemList = (from c in db.TVItems
                                  where c.TVType == tvType
                                  select c).AsNoTracking().ToList();
            webSubsector.TVItemLanguageList = (from c in db.TVItems
                                          from cl in db.TVItemLanguages
                                          where c.TVItemID == cl.TVItemID
                                          && c.TVType == tvType
                                          select cl).AsNoTracking().ToList();
            webSubsector.TVItemStatList = (from c in db.TVItems
                                      from cs in db.TVItemStats
                                      where c.TVItemID == cs.TVItemID
                                      && c.TVType == tvType
                                      select cs).AsNoTracking().ToList();
            webSubsector.MapInfoList = (from c in db.TVItems
                                   from mi in db.MapInfos
                                   where c.TVItemID == mi.TVItemID
                                   && c.TVType == tvType
                                   select mi).AsNoTracking().ToList();
            webSubsector.MapInfoPointList = (from c in db.TVItems
                                        from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where c.TVItemID == mi.TVItemID
                                        && mi.MapInfoID == mip.MapInfoID
                                        && c.TVType == tvType
                                        select mip).AsNoTracking().ToList();

            return await Task.FromResult(Ok(webSubsector));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
