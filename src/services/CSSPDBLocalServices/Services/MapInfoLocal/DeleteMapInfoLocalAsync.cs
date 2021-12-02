namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    public async Task<ActionResult<MapInfoModel>> DeleteMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType)
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

        if (mapInfoModelExist == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MapInfo", "TVItemID,TVType,MapInfoDrawType", tvItem.TVItemID.ToString() + "," + tvType.ToString() + "," + mapInfoDrawType.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        MapInfoModel mapInfoModel = new MapInfoModel();

        #region MapInfo
        MapInfo mapInfoLocal = (from c in dbLocal.MapInfos
                                where c.TVItemID == tvItem.TVItemID
                                && c.TVType == tvType
                                && c.MapInfoDrawType == mapInfoDrawType
                                select c).FirstOrDefault();

        if (mapInfoLocal == null)
        {
            mapInfoLocal = mapInfoModelExist.MapInfo;
            mapInfoLocal.DBCommand = DBCommandEnum.Deleted;
            mapInfoLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            mapInfoLocal.LastUpdateDate_UTC = DateTime.UtcNow;

            dbLocal.MapInfos.Add(mapInfoLocal);
        }
        else
        {
            mapInfoLocal.DBCommand = DBCommandEnum.Deleted;
            mapInfoLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            mapInfoLocal.LastUpdateDate_UTC = DateTime.UtcNow;
        }

        try
        {
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPointList", ex.Message));
        }

        mapInfoModel.MapInfo = mapInfoLocal;

        #endregion MapInfo

        #region MapInfoPoints List
        foreach (MapInfoPoint mapInfoPoint in mapInfoModelExist.MapInfoPointList)
        {
            MapInfoPoint mapInfoPointLocal = (from c in dbLocal.MapInfoPoints
                                              where c.MapInfoID == mapInfoLocal.MapInfoID
                                              && c.Ordinal == mapInfoPoint.Ordinal
                                              select c).FirstOrDefault();

            if (mapInfoPointLocal == null)
            {
                mapInfoPointLocal = mapInfoPoint;
                mapInfoPointLocal.DBCommand = DBCommandEnum.Deleted;
                mapInfoPointLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                mapInfoPointLocal.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.MapInfoPoints.Add(mapInfoPointLocal);
            }
            else
            {
                mapInfoPointLocal.DBCommand = DBCommandEnum.Deleted;
                mapInfoPointLocal.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                mapInfoPointLocal.LastUpdateDate_UTC = DateTime.UtcNow;
            }

            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "MapInfoPointList", ex.Message));
            }

            mapInfoModel.MapInfoPointList.Add(mapInfoPointLocal);
        }
        #endregion MapInfoPoints List

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(mapInfoModel));
    }
}

