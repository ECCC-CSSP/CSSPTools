//using CSSPDBModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> AddMapInfo(TVItem NewTVItem, int OldTVItemID, int ContactTVItemID)
//        {
//            List<MapInfo> mapInfoList = (from c in dbCSSPDB.MapInfos.AsNoTracking()
//                                         where c.TVItemID == OldTVItemID
//                                         select c).ToList();
//            int MapInfoID = 0;
//            foreach (MapInfo mapInfo in mapInfoList)
//            {
//                MapInfoID = mapInfo.MapInfoID;

//                mapInfo.TVItemID = NewTVItem.TVItemID;
//                mapInfo.LastUpdateContactTVItemID = ContactTVItemID;

//                mapInfo.MapInfoID = 0;

//                try
//                {
//                    dbTestDB.MapInfos.Add(mapInfo);
//                    dbTestDB.SaveChanges();
//                }
//                catch (Exception ex)
//                {
//                    string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                    Console.WriteLine($"{ ex.Message }{ InnerExceptiion }");
//                    return await Task.FromResult(false);
//                }

//                List<MapInfoPoint> mapInfoPointList = (from c in dbCSSPDB.MapInfoPoints.AsNoTracking()
//                                                       where c.MapInfoID == MapInfoID
//                                                       select c).ToList();

//                foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
//                {
//                    mapInfoPoint.MapInfoPointID = 0;
//                    mapInfoPoint.MapInfoID = mapInfo.MapInfoID;
//                    mapInfoPoint.LastUpdateContactTVItemID = ContactTVItemID;

//                    try
//                    {
//                        dbTestDB.MapInfoPoints.Add(mapInfoPoint);
//                        dbTestDB.SaveChanges();
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerExceptiion }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            return await Task.FromResult(true);
//        }
//    }
//}
