namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncTVModel(TVItemModel tvItemModelOriginal, TVItemModel tvItemModelLocal)
    {
        if (tvItemModelLocal != null)
        {
            if (tvItemModelLocal.TVItem != null)
            {
                tvItemModelOriginal.TVItem = tvItemModelLocal.TVItem;
            }
            if (tvItemModelLocal.TVItemLanguageList != null)
            {
                tvItemModelOriginal.TVItemLanguageList = tvItemModelLocal.TVItemLanguageList;
            }
        }
    }
}

