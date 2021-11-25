namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncTideSiteModel(TideSiteModel tideSiteModelOriginal, TideSiteModel tideSiteModelLocal)
    {
        if (tideSiteModelLocal != null)
        {
            if (tideSiteModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(tideSiteModelOriginal.TVItemModel, tideSiteModelLocal.TVItemModel);
            }
            if (tideSiteModelLocal.TideSite != null)
            {
                tideSiteModelOriginal.TideSite = tideSiteModelLocal.TideSite;
            }
            foreach (TideDataValue tideDataValueLocal in tideSiteModelLocal.TideDataValueList)
            {
                TideDataValue tideDataValueOriginal = tideSiteModelOriginal.TideDataValueList.Where(c => c.TideDataValueID == tideDataValueLocal.TideDataValueID).FirstOrDefault();
                if (tideDataValueOriginal == null)
                {
                    tideSiteModelOriginal.TideDataValueList.Add(tideDataValueLocal);
                }
                else
                {
                    tideDataValueOriginal = tideDataValueLocal;
                }
            }
        }
    }
}

