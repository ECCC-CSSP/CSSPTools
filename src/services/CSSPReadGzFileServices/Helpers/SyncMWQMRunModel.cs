namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMWQMRunModel(MWQMRunModel mwqmRunModelOriginal, MWQMRunModel mwqmRunModelLocal)
    {
        if (mwqmRunModelLocal != null)
        {
            if (mwqmRunModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(mwqmRunModelOriginal.TVItemModel, mwqmRunModelLocal.TVItemModel);
            }
            if (mwqmRunModelLocal.MWQMRun != null)
            {
                mwqmRunModelOriginal.MWQMRun = mwqmRunModelLocal.MWQMRun;
            }
            if (mwqmRunModelLocal.MWQMRunLanguageList != null)
            {
                mwqmRunModelOriginal.MWQMRunLanguageList = mwqmRunModelLocal.MWQMRunLanguageList;
            }
        }
    }
}

