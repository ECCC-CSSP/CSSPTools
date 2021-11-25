namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMikeBoundaryConditionModel(MikeBoundaryConditionModel mikeBoundaryConditionModelOriginal, MikeBoundaryConditionModel mikeBoundaryConditionModelLocal)
    {
        if (mikeBoundaryConditionModelLocal != null)
        {
            if (mikeBoundaryConditionModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(mikeBoundaryConditionModelOriginal.TVItemModel, mikeBoundaryConditionModelLocal.TVItemModel);
            }
            if (mikeBoundaryConditionModelLocal.MikeBoundaryCondition != null)
            {
                mikeBoundaryConditionModelOriginal.MikeBoundaryCondition = mikeBoundaryConditionModelLocal.MikeBoundaryCondition;
            }
        }
    }
}

