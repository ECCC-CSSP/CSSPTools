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
        private async Task CheckAddedMapInfoFromAverage(TVItem tvItemParent, TVTypeEnum tvType)
        {
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverageAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModelPoint.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModelPoint.Result).Value);
            MapInfoModel mapInfoModelPoint = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPoint);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPoint);

            var actionMapInfoModelPolygon = await MapInfoLocalService.AddMapInfoLocalFromAverageAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Polygon);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModelPolygon.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModelPolygon.Result).Value);
            MapInfoModel mapInfoModelPolygon = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPolygon);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPolygon);

            var actionMapInfoModelPolyline = await MapInfoLocalService.AddMapInfoLocalFromAverageAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Polyline);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModelPolyline.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModelPolyline.Result).Value);
            MapInfoModel mapInfoModelPolyline = (MapInfoModel)((OkObjectResult)actionMapInfoModelPoint.Result).Value;
            Assert.NotNull(mapInfoModelPolyline);

            CheckCreatedMapInfoAndMapInfoPointList(mapInfoModelPolyline);
        }
    }
}
