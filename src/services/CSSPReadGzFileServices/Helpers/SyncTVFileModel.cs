namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncTVFileModel(TVFileModel tvFileModelOriginal, TVFileModel tvFileModelLocal)
    {
        if (tvFileModelLocal != null)
        {
            if (tvFileModelLocal.TVFile != null)
            {
                tvFileModelOriginal.TVFile = tvFileModelLocal.TVFile;
            }
            if (tvFileModelLocal.TVFileLanguageList != null)
            {
                tvFileModelOriginal.TVFileLanguageList = tvFileModelLocal.TVFileLanguageList;
            }

            if (tvFileModelOriginal.TVItemModel == null)
            {
                tvFileModelOriginal.TVItemModel = tvFileModelLocal.TVItemModel;
            }
            else
            {
                SyncTVItemModel(tvFileModelOriginal.TVItemModel, tvFileModelLocal.TVItemModel);
            }
        }
    }
}

