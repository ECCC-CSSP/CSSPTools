namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncRainExceedanceModel(RainExceedanceModel rainExceedanceModelOriginal, RainExceedanceModel rainExceedanceModelLocal)
    {
        if (rainExceedanceModelLocal != null)
        {
            if (rainExceedanceModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(rainExceedanceModelOriginal.TVItemModel, rainExceedanceModelLocal.TVItemModel);
            }

            if (rainExceedanceModelLocal.RainExceedance != null)
            {
                rainExceedanceModelOriginal.RainExceedance = rainExceedanceModelLocal.RainExceedance;
            }

            foreach (RainExceedanceClimateSite rainExceedanceClimateSiteLocal in rainExceedanceModelLocal.RainExceedanceClimateSiteList)
            {
                RainExceedanceClimateSite rainExceedanceClimateSiteOriginal = rainExceedanceModelOriginal.RainExceedanceClimateSiteList.Where(c => c.RainExceedanceClimateSiteID == rainExceedanceClimateSiteLocal.RainExceedanceClimateSiteID).FirstOrDefault();
                if (rainExceedanceClimateSiteOriginal == null)
                {
                    rainExceedanceModelOriginal.RainExceedanceClimateSiteList.Add(rainExceedanceClimateSiteLocal);
                }
                else
                {
                    rainExceedanceClimateSiteOriginal = rainExceedanceClimateSiteLocal;
                }
            }
        }
    }
}

