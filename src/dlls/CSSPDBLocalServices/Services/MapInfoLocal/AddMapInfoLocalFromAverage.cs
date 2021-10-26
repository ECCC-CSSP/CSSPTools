/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{
    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        public async Task<ActionResult<List<MapInfoLocalModel>>> AddMapInfoLocalFromAverage(TVItem tvItemParent, TVItem tvItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItem tvItemParent, TVItem tvItem, MapInfoDrawTypeEnum mapInfoDrawType) -- tvItemParent.TVItemID = { tvItemParent.TVItemID } tvItem.TVItemID = { tvItem.TVItemID }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (tvItemParent == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"));
            }

            if (tvItem == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItem"));
            }

            List<MapInfoLocalModel> mapInfoLocalModelList = await GetMapInfoLocalModel(tvItemParent, tvItem);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
                {
                    if (mapInfoPoint.MapInfoPointID != 0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "MapInfoPointID", "0"));
                    }

                    //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mapInfoLocalModel.MapInfoPoint.DBCommand);
                    //if (!string.IsNullOrWhiteSpace(retStr))
                    //{
                    //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
                    //}

                    if (mapInfoPoint.MapInfoID != 0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "MapInfoID", "0"));
                    }

                    if (mapInfoPoint.Ordinal < 0 || mapInfoPoint.Ordinal > 100000)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", 0, 10000));
                    }

                    if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90.0", "90.0"));
                    }

                    if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180.0", "180.0"));
                    }
                }

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

                #region MapInfo
                int MapInfoIDNew = (from c in dbLocal.MapInfos
                                    where c.MapInfoID < 0
                                    orderby c.MapInfoID descending
                                    select c.MapInfoID).FirstOrDefault() - 1;

                mapInfoLocalModel.MapInfo.MapInfoID = MapInfoIDNew;
                mapInfoLocalModel.MapInfo.DBCommand = DBCommandEnum.Created;
                mapInfoLocalModel.MapInfo.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                mapInfoLocalModel.MapInfo.LastUpdateDate_UTC = DateTime.UtcNow;

                try
                {
                    dbLocal.MapInfos.Add(mapInfoLocalModel.MapInfo);
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message));
                }
                #endregion MapInfo

                #region MapInfoPointList
                int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
                                         where c.MapInfoPointID < 0
                                         orderby c.MapInfoPointID descending
                                         select c.MapInfoPointID).FirstOrDefault() - 1;

                foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
                {
                    mapInfoPoint.MapInfoPointID = MapInfoPointIDNew;
                    mapInfoPoint.MapInfoID = mapInfoLocalModel.MapInfo.MapInfoID;
                    mapInfoPoint.DBCommand = DBCommandEnum.Created;
                    mapInfoPoint.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                    mapInfoPoint.LastUpdateDate_UTC = DateTime.UtcNow;

                    try
                    {
                        dbLocal.MapInfoPoints.Add(mapInfoPoint);
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message));
                    }

                    MapInfoPointIDNew -= 1;
                }
                #endregion MapInfoPointList

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(mapInfoLocalModelList));
        }
    }
}
