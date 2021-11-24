namespace CSSPDBLocalServices;

public partial interface IClassificationLocalService
{
    Task<ActionResult<ClassificationModel>> AddClassificationLocalAsync(int SubsectorTVItemID, ClassificationTypeEnum classificationType, List<Coord> coordList);
}
