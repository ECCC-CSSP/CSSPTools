/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class MapInfoLocalServiceTest
    {
        private async Task CheckDeletedMapInfoOfAdded(TVItem tvItemParent, TVItemModel tvItemModel, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType)
        {
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

            var actionMapInfoLocalModelPointNew = await MapInfoLocalService.AddMapInfoLocal(tvItemParent, tvItemModel.TVItem, tvType, mapInfoDrawType, coordList);
            Assert.Equal(200, ((ObjectResult)actionMapInfoLocalModelPointNew.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoLocalModelPointNew.Result).Value);
            MapInfoModel mapInfoModelPoint = (MapInfoModel)((OkObjectResult)actionMapInfoLocalModelPointNew.Result).Value;
            Assert.NotNull(mapInfoModelPoint);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPoint);

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemModel.TVItem.TVItemID);

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.DeleteMapInfoLocal(tvItemParent, tvItemModel.TVItem, tvType, mapInfoDrawType);
            Assert.Equal(200, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            bool boolRetPoint = (bool)((OkObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.True(boolRetPoint);

            MapInfoModel mapInfoModel = (from c in tvItemModel.MapInfoModelList
                                         where c.MapInfo.TVItemID == tvItemModel.TVItem.TVItemID
                                         && c.MapInfo.TVType == tvType
                                         && c.MapInfo.MapInfoDrawType == mapInfoDrawType
                                         select c).FirstOrDefault();

            Assert.NotNull(mapInfoModel);

            MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                                 where c.TVItemID == tvItemModel.TVItem.TVItemID
                                 && c.TVType == tvType
                                 && c.MapInfoDrawType == mapInfoDrawType
                                 select c).FirstOrDefault();
            Assert.NotNull(mapInfoDB);

            Assert.Equal(DBCommandEnum.Deleted, mapInfoDB.DBCommand);
            Assert.Equal(mapInfoModel.MapInfo.LatMax, mapInfoDB.LatMax);
            Assert.Equal(mapInfoModel.MapInfo.LatMin, mapInfoDB.LatMin);
            Assert.Equal(mapInfoModel.MapInfo.LngMax, mapInfoDB.LngMax);
            Assert.Equal(mapInfoModel.MapInfo.LngMin, mapInfoDB.LngMin);
            Assert.Equal(mapInfoModel.MapInfo.MapInfoDrawType, mapInfoDB.MapInfoDrawType);
            Assert.Equal(mapInfoModel.MapInfo.MapInfoID, mapInfoDB.MapInfoID);
            Assert.Equal(mapInfoModel.MapInfo.TVItemID, mapInfoDB.TVItemID);
            Assert.Equal(mapInfoModel.MapInfo.TVType, mapInfoDB.TVType);
            Assert.Equal(mapInfoModel.MapInfo.MapInfoDrawType, mapInfoDB.MapInfoDrawType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoDB.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoDB.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoDB.LastUpdateDate_UTC);

            List<MapInfoPoint> mapInfoPointListDB = (from c in dbLocal.MapInfoPoints
                                                     where c.MapInfoID == mapInfoModel.MapInfo.MapInfoID
                                                     orderby c.Ordinal
                                                     select c).ToList();
            Assert.NotNull(mapInfoPointListDB);
            Assert.NotEmpty(mapInfoPointListDB);

            int index = 0;
            foreach (MapInfoPoint mapInfoPointDB in mapInfoPointListDB)
            {
                Assert.Equal(DBCommandEnum.Deleted, mapInfoPointDB.DBCommand);
                Assert.Equal(mapInfoModel.MapInfoPointList[index].Lat, mapInfoPointDB.Lat);
                Assert.Equal(mapInfoModel.MapInfoPointList[index].Lng, mapInfoPointDB.Lng);
                Assert.Equal(mapInfoModel.MapInfoPointList[index].MapInfoID, mapInfoPointDB.MapInfoID);
                Assert.Equal(mapInfoModel.MapInfoPointList[index].MapInfoPointID, mapInfoPointDB.MapInfoPointID);
                Assert.Equal(mapInfoModel.MapInfoPointList[index].Ordinal, mapInfoPointDB.Ordinal);
                Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoDB.LastUpdateContactTVItemID);
                Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoDB.LastUpdateDate_UTC);
                Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoDB.LastUpdateDate_UTC);

                index += 1;
            }
        }
    }
}