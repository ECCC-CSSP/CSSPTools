namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    public async Task<ActionResult<MapInfoModel>> AddMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType, List<Coord> coordList)
    {
        // if coordList is empty then the function will still try to create an MapInfo
        // with the average of siblings coordinates

        string parameters = "";
        if (tvItemParent != null)
        {
            parameters += $" --  tvItemParent.TVItemID = { tvItemParent.TVItemID } " +
                $"tvItemParent.TVType = { tvItemParent.TVType }";
        }
        if (tvItem != null)
        {
            parameters += $" --  tvItem.TVItemID = { tvItem.TVItemID } " +
                $"tvItem.TVType = { tvItem.TVType }";
        }

        parameters += $"tvType = { tvType } " +
        $"mapInfoDrawType = { mapInfoDrawType }";

        if (coordList != null)
        {
            parameters += $"coordList.Count = { coordList.Count }";
        }
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType, List<Coord> coordList) { parameters }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Checking Input Parameters
        // Checking tvItemParent
        if (tvItemParent == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (tvItem == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItem"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (tvItemParent.TVItemID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"));
        }

        if (tvItemParent.ParentID == null || tvItemParent.ParentID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.ParentID"));
        }

        string retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemParent.TVType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType"));
        }

        // Checking tvItem
        if (tvItem.TVItemID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"));
        }

        if (tvItem.ParentID == null || tvItem.ParentID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.ParentID"));
        }

        retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVType"));
        }

        // Checking tvType
        retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"));
        }

        // Checking mapInfoDrawType
        retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfoDrawType);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoDrawType"));
        }

        // not checking coordList as it could be null or empty
        #endregion Checking Input Parameters

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        HelperLocalService.CheckTVTypeParentAndTVType(tvItemParent.TVType, tvType);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        List<MapInfoModel> mapInfoModelSiblingList = await GetMapInfoModelSiblingListAsync(tvItemParent, tvItem);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModelExist = (from c in mapInfoModelSiblingList
                                          where c.MapInfo.TVItemID == tvItem.TVItemID
                                          && c.MapInfo.TVType == tvType
                                          && c.MapInfo.MapInfoDrawType == mapInfoDrawType
                                          select c).FirstOrDefault();

        if (mapInfoModelExist != null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "MapInfo"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (coordList == null || coordList.Count == 0)
        {
            coordList = await GetCoordListFromAverageSiblingListAsync(mapInfoModelSiblingList, tvItem, tvType, mapInfoDrawType);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        #region MapInfo
        double PolygonSize = await HelperLocalService.GetPolygonSizeAsync(tvType);

        int MapInfoIDNew = (from c in dbLocal.MapInfos
                            where c.MapInfoID < 0
                            orderby c.MapInfoID ascending
                            select c.MapInfoID).FirstOrDefault() - 1;

        MapInfo mapInfoNew = new MapInfo()
        {
            DBCommand = DBCommandEnum.Created,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            LastUpdateDate_UTC = DateTime.UtcNow,
            LatMax = (from c in coordList select c.Lat).Max() + PolygonSize,
            LatMin = (from c in coordList select c.Lat).Min() - PolygonSize,
            LngMax = (from c in coordList select c.Lng).Max() + PolygonSize,
            LngMin = (from c in coordList select c.Lng).Min() - PolygonSize,
            MapInfoDrawType = mapInfoDrawType,
            MapInfoID = MapInfoIDNew,
            TVItemID = tvItem.TVItemID,
            TVType = tvType,
        };

        try
        {
            dbLocal.MapInfos.Add(mapInfoNew);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfo", ex.Message));
        }
        #endregion MapInfo

        #region MapInfoPointList

        List<MapInfoPoint> MapInfoPointList = new List<MapInfoPoint>();

        int MapInfoPointIDNew = (from c in dbLocal.MapInfoPoints
                                 where c.MapInfoPointID < 0
                                 orderby c.MapInfoPointID ascending
                                 select c.MapInfoPointID).FirstOrDefault() - 1;

        int ordinal = 0;
        foreach (Coord coord in coordList)
        {
            MapInfoPoint mapInfoPointNew = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = coord.Lat,
                Lng = coord.Lng,
                MapInfoID = mapInfoNew.MapInfoID,
                MapInfoPointID = MapInfoPointIDNew,
                Ordinal = ordinal,
            };

            try
            {
                dbLocal.MapInfoPoints.Add(mapInfoPointNew);
                dbLocal.SaveChanges();

                MapInfoPointList.Add(mapInfoPointNew);
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPoint", ex.Message));
            }

            ordinal += 1;
            MapInfoPointIDNew -= 1;
        }
        #endregion MapInfoPointList

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModel = new MapInfoModel()
        {
            MapInfo = mapInfoNew,
            MapInfoPointList = MapInfoPointList,
        };

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(mapInfoModel));
    }
}

