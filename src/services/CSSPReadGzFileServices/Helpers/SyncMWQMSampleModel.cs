namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMWQMSampleModel(MWQMSampleModel mwqmSampleModelOriginal, MWQMSampleModel mwqmSampleModelLocal)
    {
        if (mwqmSampleModelLocal != null)
        {
            if (mwqmSampleModelLocal.MWQMSample != null)
            {
                mwqmSampleModelOriginal.MWQMSample = mwqmSampleModelLocal.MWQMSample;
            }
            if (mwqmSampleModelLocal.MWQMSampleLanguageList != null)
            {
                mwqmSampleModelOriginal.MWQMSampleLanguageList = mwqmSampleModelLocal.MWQMSampleLanguageList;
            }
        }
    }
}

