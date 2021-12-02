namespace CSSPDBLocalServices;

public partial class ClassificationLocalService : ControllerBase, IClassificationLocalService
{
    public async Task<ActionResult<ClassificationModel>> ModifyClassificationLocalAsync(int SubsectorTVItemID, ClassificationModel classificationModel, List<Coord> coordList)
    {
        //string parameters = $" --  SubsectorTVItemID = { SubsectorTVItemID } " +
        //    $"classificationType = { ClassificationType }";

        //string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int SubsectorTVItemID, ClassificationTypeEnum classificationType, List<Coord> coordList) { parameters }";
        //CSSPLogService.FunctionLog(FunctionName);

        //if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        //#region Check Classification
        //if (SubsectorTVItemID == 0)
        //{
        //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"));
        //}

        //string retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)ClassificationType);
        //if (!string.IsNullOrWhiteSpace(retStr))
        //{
        //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationType"));
        //}

        //if (coordList == null)
        //{
        //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "coordList"));
        //}
        //else
        //{
        //    if (coordList.Count < 2)
        //    {
        //        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._NeedsAtLeast2Points, "coordList"));
        //    }
        //}

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //foreach (Coord coord in coordList)
        //{
        //    if (coord.Lat < -90)
        //    {
        //        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MinValueIs_, "Lat", "-90"));
        //        break;
        //    }
        //    if (coord.Lat > 90)
        //    {
        //        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxValueIs_, "Lat", "90"));
        //        break;
        //    }
        //    if (coord.Lng < -180)
        //    {
        //        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MinValueIs_, "Lng", "-180"));
        //        break;
        //    }
        //    if (coord.Lng > 180)
        //    {
        //        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxValueIs_, "Lng", "180"));
        //        break;
        //    }
        //}

        //#endregion Check Classification

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

        //int LastOrdinal = (from c in webSubsector.ClassificationModelList
        //                   orderby c.Classification.Ordinal descending
        //                   select c.Classification.Ordinal).FirstOrDefault();

        //string TVText = "ERROR";
        //switch (ClassificationType)
        //{
        //    case ClassificationTypeEnum.Approved:
        //        {
        //            TVText = "A " + LastOrdinal;
        //        }
        //        break;
        //    case ClassificationTypeEnum.ConditionallyApproved:
        //        {
        //            TVText = "CA " + LastOrdinal;
        //        }
        //        break;
        //    case ClassificationTypeEnum.ConditionallyRestricted:
        //        {
        //            TVText = "CR " + LastOrdinal;
        //        }
        //        break;
        //    case ClassificationTypeEnum.Prohibited:
        //        {
        //            TVText = "P " + LastOrdinal;
        //        }
        //        break;
        //    case ClassificationTypeEnum.Restricted:
        //        {
        //            TVText = "R " + LastOrdinal;
        //        }
        //        break;
        //    default:
        //        break;
        //}

        //var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(webSubsector.TVItemModel.TVItem, TVTypeEnum.Classification, TVText, TVText);

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //var actionMapInfo = await MapInfoLocalService.AddMapInfoLocalAsync(webSubsector.TVItemModel.TVItem, tvItemModel.TVItem, TVTypeEnum.Classification, MapInfoDrawTypeEnum.Polyline, coordList);

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //MapInfoModel mapInfoModel = (MapInfoModel)((OkObjectResult)actionMapInfo.Result).Value;

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //int ClassificationIDNew = (from c in dbLocal.Classifications
        //                           where c.ClassificationID < 0
        //                           orderby c.ClassificationID ascending
        //                           select c.ClassificationID).FirstOrDefault() - 1;

        //Classification classification = new Classification()
        //{
        //    ClassificationID = ClassificationIDNew,
        //    ClassificationTVItemID = tvItemModel.TVItem.TVItemID,
        //    ClassificationType = ClassificationType,
        //    Ordinal = LastOrdinal + 1,
        //    DBCommand = DBCommandEnum.Created,
        //    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        //    LastUpdateDate_UTC = DateTime.UtcNow,
        //};

        //try
        //{
        //    dbLocal.Classifications.Add(classification);
        //    dbLocal.SaveChanges();
        //}
        //catch (Exception ex)
        //{
        //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Classification", ex.Message));
        //}

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //await CSSPCreateGzFileService.SetLocal(true);

        //var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebSubsector, SubsectorTVItemID);
        //if (400 == ((ObjectResult)actionRes.Result).StatusCode)
        //{
        //    ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        //    CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
        //}

        //if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        //CSSPLogService.EndFunctionLog(FunctionName);

        //ClassificationLocalModel classificationLocalModel = new ClassificationLocalModel()
        //{
        //    TVItemParent = webSubsector.TVItemModel.TVItem,
        //    TVItemModel = tvItemModel,
        //    Classification = classification,
        //};

        //return await Task.FromResult(Ok(classificationLocalModel));

        return await Task.FromResult(Ok(new ClassificationLocalModel()));
    }

}
