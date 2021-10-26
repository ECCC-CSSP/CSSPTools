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
        private void CheckCreatedMapInfoAndMapInfoPointList(MapInfoLocalModel mapInfoLocalModel)
        {
            MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                                 where c.MapInfoID == mapInfoLocalModel.MapInfo.MapInfoID
                                 select c).FirstOrDefault();
            Assert.NotNull(mapInfoDB);

            Assert.Equal(DBCommandEnum.Created, mapInfoLocalModel.MapInfo.DBCommand);
            Assert.Equal(mapInfoDB.DBCommand, mapInfoLocalModel.MapInfo.DBCommand);
            Assert.Equal(mapInfoDB.LatMax, mapInfoLocalModel.MapInfo.LatMax);
            Assert.Equal(mapInfoDB.LatMin, mapInfoLocalModel.MapInfo.LatMin);
            Assert.Equal(mapInfoDB.LngMax, mapInfoLocalModel.MapInfo.LngMax);
            Assert.Equal(mapInfoDB.LngMin, mapInfoLocalModel.MapInfo.LngMin);
            Assert.Equal(mapInfoDB.MapInfoDrawType, mapInfoLocalModel.MapInfo.MapInfoDrawType);
            Assert.Equal(mapInfoDB.MapInfoID, mapInfoLocalModel.MapInfo.MapInfoID);
            Assert.Equal(mapInfoDB.TVItemID, mapInfoLocalModel.MapInfo.TVItemID);
            Assert.Equal(mapInfoDB.TVType, mapInfoLocalModel.MapInfo.TVType);
            Assert.Equal(mapInfoDB.MapInfoDrawType, mapInfoLocalModel.MapInfo.MapInfoDrawType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoLocalModel.MapInfo.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoLocalModel.MapInfo.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoLocalModel.MapInfo.LastUpdateDate_UTC);

            List<MapInfoPoint> mapInfoPointListDB = (from c in dbLocal.MapInfoPoints
                                                     where c.MapInfoID == mapInfoLocalModel.MapInfo.MapInfoID
                                                     orderby c.Ordinal
                                                     select c).ToList();
            Assert.NotNull(mapInfoPointListDB);
            Assert.NotEmpty(mapInfoPointListDB);

            int index = 0;
            foreach (MapInfoPoint mapInfoPoint in mapInfoPointListDB)
            {
                Assert.Equal(DBCommandEnum.Created, mapInfoLocalModel.MapInfoPointList[index].DBCommand);
                Assert.Equal(mapInfoPoint.DBCommand, mapInfoLocalModel.MapInfoPointList[index].DBCommand);
                Assert.Equal(mapInfoPoint.Lat, mapInfoLocalModel.MapInfoPointList[index].Lat);
                Assert.Equal(mapInfoPoint.Lng, mapInfoLocalModel.MapInfoPointList[index].Lng);
                Assert.Equal(mapInfoPoint.MapInfoID, mapInfoLocalModel.MapInfoPointList[index].MapInfoID);
                Assert.Equal(mapInfoPoint.MapInfoPointID, mapInfoLocalModel.MapInfoPointList[index].MapInfoPointID);
                Assert.Equal(mapInfoPoint.Ordinal, mapInfoLocalModel.MapInfoPointList[index].Ordinal);
                Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoLocalModel.MapInfoPointList[index].LastUpdateContactTVItemID);
                Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoLocalModel.MapInfoPointList[index].LastUpdateDate_UTC);
                Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoLocalModel.MapInfoPointList[index].LastUpdateDate_UTC);

                index += 1;
            }
        }
    }
}
