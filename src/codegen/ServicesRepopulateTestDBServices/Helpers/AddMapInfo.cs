﻿using CSSPModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
    {
        private async Task<bool> AddMapInfo(TVItem NewTVItem, int OldTVItemID, int ContactTVItemID)
        {
            List<MapInfo> mapInfoList = (from c in dbCSSPDB.MapInfos.AsNoTracking()
                                         where c.TVItemID == OldTVItemID
                                         select c).ToList();
            int MapInfoID = 0;
            foreach (MapInfo mapInfo in mapInfoList)
            {
                MapInfoID = mapInfo.MapInfoID;

                mapInfo.TVItemID = NewTVItem.TVItemID;
                mapInfo.LastUpdateContactTVItemID = ContactTVItemID;

                mapInfo.MapInfoID = 0;
                if (mapInfo.ValidationResults.Count() > 0)
                {
                    ActionCommandDBService.ErrorText.AppendLine(mapInfo.ValidationResults.First().ErrorMessage);
                    return await Task.FromResult(false);
                }
                try
                {
                    dbTestDB.MapInfos.Add(mapInfo);
                    dbTestDB.SaveChanges();
                }
                catch (Exception ex)
                {
                    string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                    ActionCommandDBService.ErrorText.AppendLine($"{ ex.Message }{ InnerExceptiion }");
                    return await Task.FromResult(false);
                }

                List<MapInfoPoint> mapInfoPointList = (from c in dbCSSPDB.MapInfoPoints.AsNoTracking()
                                                       where c.MapInfoID == MapInfoID
                                                       select c).ToList();

                foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
                {
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPoint.MapInfoID = mapInfo.MapInfoID;
                    mapInfoPoint.LastUpdateContactTVItemID = ContactTVItemID;

                    if (mapInfoPoint.ValidationResults.Count() > 0)
                    {
                        ActionCommandDBService.ErrorText.AppendLine(mapInfoPoint.ValidationResults.First().ErrorMessage);
                        return await Task.FromResult(false);
                    }
                    try
                    {
                        dbTestDB.MapInfoPoints.Add(mapInfoPoint);
                        dbTestDB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                        ActionCommandDBService.ErrorText.AppendLine($"{ ex.Message }{ InnerExceptiion }");
                        return await Task.FromResult(false);
                    }
                }
            }
            return await Task.FromResult(true);
        }
    }
}
