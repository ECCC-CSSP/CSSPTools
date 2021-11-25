namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncClimateSiteModel(ClimateSiteModel climateSiteModelOriginal, ClimateSiteModel climateSiteModelLocal)
    {
        if (climateSiteModelLocal != null)
        {
            if (climateSiteModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(climateSiteModelOriginal.TVItemModel, climateSiteModelLocal.TVItemModel);
            }
            if (climateSiteModelLocal.ClimateSite != null)
            {
                climateSiteModelOriginal.ClimateSite = climateSiteModelLocal.ClimateSite;
            }
            foreach (ClimateDataValue climateDataValueLocal in climateSiteModelLocal.ClimateDataValueList)
            {
                ClimateDataValue climateDataValueOriginal = climateSiteModelOriginal.ClimateDataValueList.Where(c => c.ClimateDataValueID == climateDataValueLocal.ClimateDataValueID).FirstOrDefault();
                if (climateDataValueOriginal == null)
                {
                    climateSiteModelOriginal.ClimateDataValueList.Add(climateDataValueLocal);
                }
                else
                {
                    climateDataValueOriginal = climateDataValueLocal;
                }
            }
        }
    }
}

