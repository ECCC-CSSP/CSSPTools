namespace CSSPDBLocalServices;

public partial interface IClassificationLocalService
{
    Task<ActionResult<ClassificationModel>> AddClassificationLocalAsync(int SubsectorTVItemID, ClassificationTypeEnum classificationType, List<Coord> coordList);
    Task<ActionResult<ClassificationModel>> DeleteClassificationLocalAsync(int SubsectorTVItemID, int ClassificationTVItemID);
    Task<ActionResult<ClassificationModel>> ModifyClassificationLocalAsync(int SubsectorTVItemID, ClassificationModel classificationModel, List<Coord> coordList);
}
