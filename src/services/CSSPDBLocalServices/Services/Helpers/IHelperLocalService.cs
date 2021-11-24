namespace CSSPDBLocalServices;


public partial interface IHelperLocalService
{
    Task CheckIfChildExistAsync(TVItem tvItemParent, TVItem tvItem);
    Task CheckIfSiblingsExistWithSameTVTextAsync(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR, int TVItemIDOrTVFileID);
    void CheckTVTypeParentAndTVType(TVTypeEnum tvTypeParent, TVTypeEnum tvType);
    Task<List<TVItemModel>> GetTVItemModelParentListAsync(TVItem tvItemParent, TVTypeEnum tvType);
    List<TVTypeParentTVTypeRelation> GetTVTypeParentTVTypeRelationListAsync();
    //Task RecreateLocalGzFiles(List<TVItemModel> tvItemModelParentList);
    Task<double> GetPolygonSizeAsync(TVTypeEnum tvType);
    Task<string> GetUniqueTVTextAsync(List<TVItemModel> TVItemModelList, LanguageEnum language, string StartText);
}
