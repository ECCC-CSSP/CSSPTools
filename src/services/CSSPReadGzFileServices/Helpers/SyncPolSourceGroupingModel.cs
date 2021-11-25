namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncPolSourceGroupingModel(PolSourceGroupingModel polSourceGroupingModelOriginal, PolSourceGroupingModel polSourceGroupingModelLocal)
    {
        if (polSourceGroupingModelLocal.PolSourceGrouping != null)
        {
            polSourceGroupingModelOriginal.PolSourceGrouping = polSourceGroupingModelLocal.PolSourceGrouping;
        }
        if (polSourceGroupingModelLocal.PolSourceGroupingLanguageList != null)
        {
            polSourceGroupingModelOriginal.PolSourceGroupingLanguageList = polSourceGroupingModelLocal.PolSourceGroupingLanguageList;
        }
    }
}

