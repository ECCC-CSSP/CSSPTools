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
    public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
    {
        private async Task CheckAddedMapInfo(TVItem tvItemParent, TVTypeEnum tvType)
        {
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

            var actionMapInfoModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModelPoint.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModelPoint.Result).Value);
            MapInfoModel mapInfoModelPoint = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPoint);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPoint);

            var actionMapInfoLocalModelPolygon = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Polygon, coordList);
            Assert.Equal(200, ((ObjectResult)actionMapInfoLocalModelPolygon.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoLocalModelPolygon.Result).Value);
            MapInfoModel mapInfoModelPolygon = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPolygon);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPolygon);

            var actionMapInfoLocalModelPolyline = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Polyline, coordList);
            Assert.Equal(200, ((ObjectResult)actionMapInfoLocalModelPolyline.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoLocalModelPolyline.Result).Value);
            MapInfoModel mapInfoModelPolyline = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPolyline);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPolyline);
        }
    }
}
