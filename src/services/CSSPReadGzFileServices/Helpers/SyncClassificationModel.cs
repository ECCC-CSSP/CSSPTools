namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncClassificationModel(ClassificationModel classificationModelOriginal, ClassificationModel classificationModelLocal)
    {
        if (classificationModelLocal != null)
        {
            if (classificationModelLocal.Classification != null)
            {
                classificationModelOriginal.Classification = classificationModelLocal.Classification;
            }
            if (classificationModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(classificationModelOriginal.TVItemModel, classificationModelLocal.TVItemModel);
            }
        }
    }
}

