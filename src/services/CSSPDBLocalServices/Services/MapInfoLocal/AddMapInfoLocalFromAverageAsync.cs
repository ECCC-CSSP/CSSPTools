namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    public async Task<ActionResult<MapInfoModel>> AddMapInfoLocalFromAverageAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType)
    {
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

        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType) { parameters }";
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

        MapInfoModel mapInfoModel = await GetMapInfoModelFromAverageSiblingListAsync(mapInfoModelSiblingList, tvItem, tvType, mapInfoDrawType, await HelperLocalService.GetPolygonSizeAsync(tvType));

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if ((from c in mapInfoModelSiblingList
             where c.MapInfo.TVItemID == mapInfoModel.MapInfo.TVItemID
             && c.MapInfo.MapInfoDrawType == mapInfoModel.MapInfo.MapInfoDrawType
             select c).Any())
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "MapInfo"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region MapInfo
        int MapInfoIDNew = (from c in dbLocal.MapInfos
                            where c.MapInfoID < 0
                            orderby c.MapInfoID ascending
                            select c.MapInfoID).FirstOrDefault() - 1;

        mapInfoModel.MapInfo.MapInfoID = MapInfoIDNew;
        mapInfoModel.MapInfo.DBCommand = DBCommandEnum.Created;
        mapInfoModel.MapInfo.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
        mapInfoModel.MapInfo.LastUpdateDate_UTC = DateTime.UtcNow;

        try
        {
            dbLocal.MapInfos.Add(mapInfoModel.MapInfo);
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
                                 orderby c.MapInfoPointID ascending
                                 select c.MapInfoPointID).FirstOrDefault() - 1;

        foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
        {
            mapInfoPoint.MapInfoPointID = MapInfoPointIDNew;
            mapInfoPoint.MapInfoID = mapInfoModel.MapInfo.MapInfoID;
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

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(mapInfoModel));
    }
}

