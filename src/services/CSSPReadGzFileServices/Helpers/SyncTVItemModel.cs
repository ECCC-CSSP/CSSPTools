namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncTVItemModel(TVItemModel tvItemModelOriginal, TVItemModel tvItemModelLocal)
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
            if (tvItemModelLocal.MapInfoModelList != null)
            {
                tvItemModelOriginal.MapInfoModelList = tvItemModelLocal.MapInfoModelList;
            }
            if (tvItemModelLocal.TVItemStatList != null)
            {
                tvItemModelOriginal.TVItemStatList = tvItemModelLocal.TVItemStatList;
            }
        }
    }
}

