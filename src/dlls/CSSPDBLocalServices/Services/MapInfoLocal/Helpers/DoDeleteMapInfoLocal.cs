/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        private async Task<bool> DoDeleteMapInfoLocal(MapInfoLocalModel mapInfoLocalModel)
        {
            //GzObjectList gzObjectList = FillPostLists(mapInfoLocalModel);

            if (CSSPLogService.ErrRes.ErrList.Count() > 0)
            {
                return false;
            }

            //// filling all parent TVItem in the DBLocal
            //foreach (WebBase webBaseToAdd in gzObjectList.tvItemParentList.OrderBy(c => c.TVItemModel.TVItem.TVLevel))
            //{
            //    if (!(from c in dbLocal.TVItems
            //          where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
            //          select c).Any())
            //    {
            //        try
            //        {
            //            dbLocal.TVItems.Add(webBaseToAdd.TVItemModel.TVItem);
            //            dbLocal.SaveChanges();
            //            AppendToRecreate(tvItemNew, TVTypeEnum.PolSourceSite);
            //        }
            //        catch (Exception ex)
            //        {
            //            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message), new[] { "" }));
            //            return false;
            //        }

            //        foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            //        {
            //            if (!(from c in dbLocal.TVItemLanguages
            //                  where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
            //                  && c.Language == lang
            //                  select c).Any())
            //            {

            //                try
            //                {
            //                    dbLocal.TVItemLanguages.Add(webBaseToAdd.TVItemModel.TVItemLanguageList[(int)lang - 1]);
            //                    dbLocal.SaveChanges();
            //                }
            //                catch (Exception ex)
            //                {
            //                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message), new[] { "TVItem" }));
            //                    return false;
            //                }
            //            }
            //        }
            //    }
            //}

            //double LatMin = 91.0;
            //double LatMax = -91.0;
            //double LngMin = 181.0;
            //double LngMax = -181.0;
            //if (mapInfoLocalModel.MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
            //{
            //    // might need to change the +/- 0.001 for different TVType or MapInfoDrawType
            //    LatMin = (from c in mapInfoLocalModel.MapInfoPointList select c.Lat).Min() - 0.001;
            //    LatMax = (from c in mapInfoLocalModel.MapInfoPointList select c.Lat).Max() + 0.001;
            //    LngMin = (from c in mapInfoLocalModel.MapInfoPointList select c.Lng).Min() - 0.001;
            //    LngMax = (from c in mapInfoLocalModel.MapInfoPointList select c.Lng).Max() + 0.001;
            //}
            //else
            //{
            //    // might need to change the +/- 0.001 for different TVType or MapInfoDrawType
            //    LatMin = (from c in mapInfoLocalModel.MapInfoPointList select c.Lat).Min() - 0.001;
            //    LatMax = (from c in mapInfoLocalModel.MapInfoPointList select c.Lat).Max() + 0.001;
            //    LngMin = (from c in mapInfoLocalModel.MapInfoPointList select c.Lng).Min() - 0.001;
            //    LngMax = (from c in mapInfoLocalModel.MapInfoPointList select c.Lng).Max() + 0.001;
            //}

            //int MapInfoIDNew = (from c in dbLocal.MapInfos
            //                    where c.MapInfoID < 0
            //                    orderby c.MapInfoID descending
            //                    select c.MapInfoID).FirstOrDefault() - 1;

            //if (mapInfoLocalModel.MapInfo.MapInfoID == 0)
            //{
            //    // trying to add a new MapInfo
            //    MapInfo mapInfo = (from c in dbLocal.MapInfos
            //                       where c.TVItemID == mapInfoLocalModel.TVItem.TVItemID
            //                       && c.TVType == mapInfoLocalModel.MapInfo.TVType
            //                       && c.MapInfoDrawType == mapInfoLocalModel.MapInfo.MapInfoDrawType
            //                       select c).FirstOrDefault();

            //    if (mapInfo != null)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "mapInfoLocalModel.MapInfo"), new[] { "MapInfo" }));
            //        return false;
            //    }

            //    MapInfo mapInfoNew = new MapInfo()
            //    {
            //        MapInfoID = MapInfoIDNew,
            //        DBCommand = DBCommandEnum.Created,
            //        TVItemID = mapInfoLocalModel.MapInfo.TVItemID,
            //        TVType = mapInfoLocalModel.MapInfo.TVType,
            //        MapInfoDrawType = mapInfoLocalModel.MapInfo.MapInfoDrawType,
            //        LatMin = LatMin,
            //        LatMax = LatMax,
            //        LngMin = LngMin,
            //        LngMax = LngMax,
            //        LastUpdateDate_UTC = DateTime.UtcNow,
            //        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
            //    };

            //    try
            //    {
            //        dbLocal.MapInfos.Add(mapInfoNew);
            //        dbLocal.SaveChanges();
            //        AppendToRecreate(ToRecreateList, mapInfoLocalModel.TVItem, 1982);
            //    }
            //    catch (Exception ex)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message), new[] { "MapInfo" }));
            //        return false;
            //    }

            //    int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
            //                             where c.MapInfoPointID < 0
            //                             orderby c.MapInfoPointID descending
            //                             select c.MapInfoPointID).FirstOrDefault() - 1;

            //    int countOrdinal = 0;
            //    foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
            //    {
            //        MapInfoPoint mapInfoPointNew = new MapInfoPoint()
            //        {
            //            MapInfoPointID = MapInfoPointIDNew,
            //            DBCommand = DBCommandEnum.Created,
            //            MapInfoID = mapInfoNew.MapInfoID,
            //            Ordinal = countOrdinal,
            //            Lat = mapInfoPoint.Lat,
            //            Lng = mapInfoPoint.Lng,
            //            LastUpdateDate_UTC = DateTime.UtcNow,
            //            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
            //        };

            //        dbLocal.MapInfoPoints.Add(mapInfoPointNew);

            //        countOrdinal += 1;
            //        MapInfoPointIDNew -= 1;
            //    }


            //    try
            //    {
            //        dbLocal.SaveChanges();
            //        AppendToRecreate(ToRecreateList, mapInfoLocalModel.TVItem, 1982);
            //    }
            //    catch (Exception ex)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message), new[] { "MapInfoPoint" }));
            //        return false;
            //    }
            //}
            //else
            //{
            //    MapInfo mapInfo = (from c in dbLocal.MapInfos
            //                       where c.MapInfoID == mapInfoLocalModel.MapInfo.MapInfoID
            //                       select c).FirstOrDefault();

            //    MapInfo mapInfoNew = new MapInfo()
            //    {
            //        MapInfoID = mapInfoLocalModel.MapInfo.MapInfoID,
            //        DBCommand = DBCommandEnum.Modified,
            //        TVItemID = mapInfoLocalModel.MapInfo.TVItemID,
            //        TVType = mapInfoLocalModel.MapInfo.TVType,
            //        MapInfoDrawType = mapInfoLocalModel.MapInfo.MapInfoDrawType,
            //        LatMin = LatMin,
            //        LatMax = LatMax,
            //        LngMin = LngMin,
            //        LngMax = LngMax,
            //        LastUpdateDate_UTC = DateTime.UtcNow,
            //        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
            //    };

            //    if (mapInfo == null)
            //    {
            //        dbLocal.MapInfos.Add(mapInfoNew);
            //    }

            //    try
            //    {
            //        dbLocal.SaveChanges();
            //        AppendToRecreate(ToRecreateList, mapInfoLocalModel.TVItem, 1982);
            //    }
            //    catch (Exception ex)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message), new[] { "" }));
            //        return false;
            //    }

            //    // delete all MapInfoPoints associated with the mapInfoNew.MapInfoID
            //    List<MapInfoPoint> mapInfoPointInLocal = (from c in dbLocal.MapInfoPoints
            //                                              where c.MapInfoID == mapInfoNew.MapInfoID
            //                                              orderby c.Ordinal
            //                                              select c).ToList();
            //    if (mapInfoPointInLocal.Count > 0)
            //    {
            //        dbLocal.RemoveRange(mapInfoPointInLocal);
            //    }

            //    try
            //    {
            //        dbLocal.SaveChanges();
            //        AppendToRecreate(ToRecreateList, mapInfoLocalModel.TVItem, 1982);
            //    }
            //    catch (Exception ex)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "MapInfoPoint", ex.Message), new[] { "" }));
            //        return false;
            //    }

            //    // adding all MapInfoPoints 
            //    int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
            //                             where c.MapInfoPointID < 0
            //                             orderby c.MapInfoPointID descending
            //                             select c.MapInfoPointID).FirstOrDefault() - 1;

            //    int countOrdinal = 0;
            //    foreach (MapInfoPoint mapInfoPoint in mapInfoLocalModel.MapInfoPointList)
            //    {
            //        MapInfoPoint mapInfoPointNew = new MapInfoPoint()
            //        {
            //            MapInfoPointID = MapInfoPointIDNew,
            //            DBCommand = DBCommandEnum.Modified,
            //            MapInfoID = mapInfoNew.MapInfoID,
            //            Ordinal = countOrdinal,
            //            Lat = mapInfoPoint.Lat,
            //            Lng = mapInfoPoint.Lng,
            //            LastUpdateDate_UTC = DateTime.UtcNow,
            //            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
            //        };

            //        dbLocal.MapInfoPoints.Add(mapInfoPointNew);

            //        countOrdinal += 1;
            //        MapInfoPointIDNew -= 1;
            //    }

            //    try
            //    {
            //        dbLocal.SaveChanges();
            //        AppendToRecreate(ToRecreateList, mapInfoLocalModel.TVItem, 1982);
            //    }
            //    catch (Exception ex)
            //    {
            //        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message), new[] { "" }));
            //        return false;
            //    }
            //}

            //foreach (ToRecreate toRecreate in ToRecreateList)
            //{
            //    CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
            //}

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}
