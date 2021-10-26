///*
// * Manually edited
// *
// */

//using CSSPCreateGzFileServices;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using CSSPDBModels;
//using CSSPEnums;
//using CSSPLogServices;
//using CSSPWebModels;
//using CSSPLocalLoggedInServices;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using CSSPReadGzFileServices;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace CSSPDBLocalServices
//{
//    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
//    {
//        public async Task<ActionResult<MapInfoLocalModel>> ModifyMapInfoLocal(MapInfoLocalModel mapInfoLocalModel)
//        {
//            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostMapInfoModel mapInfoLocalModel)";
//            CSSPLogService.FunctionLog(FunctionName);

//            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

//            if (mapInfoLocalModel.MapInfo.MapInfoID == 0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoID", "0"));
//            }

//            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mapInfoLocalModel.MapInfo.DBCommand);
//            //if (!string.IsNullOrWhiteSpace(retStr))
//            //{
//            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
//            //}

//            if (mapInfoLocalModel.MapInfo.TVItemID == 0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
//            }

//            string retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfoLocalModel.MapInfo.TVType);
//            if (!string.IsNullOrWhiteSpace(retStr))
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"));
//            }

//            CheckAllowableTVType(mapInfoLocalModel);

//            if (mapInfoLocalModel.MapInfo.LatMin < -90.0 || mapInfoLocalModel.MapInfo.LatMin > 90.0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LatMin", "-90.0", "90.0"));
//            }

//            if (mapInfoLocalModel.MapInfo.LatMax < -90.0 || mapInfoLocalModel.MapInfo.LatMax > 90.0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LatMax", "-90.0", "90.0"));
//            }

//            if (mapInfoLocalModel.MapInfo.LngMin < -90.0 || mapInfoLocalModel.MapInfo.LngMin > 90.0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LngMin", "-90.0", "90.0"));
//            }

//            if (mapInfoLocalModel.MapInfo.LngMax < -90.0 || mapInfoLocalModel.MapInfo.LngMax > 90.0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "LngMax", "-90.0", "90.0"));
//            }

//            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfoLocalModel.MapInfo.MapInfoDrawType);
//            if (!string.IsNullOrWhiteSpace(retStr))
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"));
//            }

//            if (mapInfoLocalModel.MapInfoPointList.Count == 0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoPointList"));
//            }

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
//            {
//                if (mapInfoPoint.MapInfoPointID == 0)
//                {
//                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoPointID", "0"));
//                }

//                //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)mapInfoLocalModel.MapInfoPoint.DBCommand);
//                //if (!string.IsNullOrWhiteSpace(retStr))
//                //{
//                //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
//                //}

//                if (mapInfoPoint.MapInfoID == 0)
//                {
//                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoID", "0"));
//                }

//                if (mapInfoPoint.Ordinal < 0 || mapInfoPoint.Ordinal > 100000)
//                {
//                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", 0, 10000));
//                }

//                if (mapInfoPoint.Lat < -90.0 || mapInfoPoint.Lng > 90.0)
//                {
//                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-90.0", "90.0"));
//                }

//                if (mapInfoPoint.Lat < -180.0 || mapInfoPoint.Lng > 180.0)
//                {
//                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-180.0", "180.0"));
//                }
//            }

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));



//            CSSPLogService.EndFunctionLog(FunctionName);

//            return await Task.FromResult(Ok(mapInfoLocalModel));
//        }
//    }
//}
