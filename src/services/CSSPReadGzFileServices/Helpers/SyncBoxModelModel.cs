namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncBoxModelModel(BoxModelModel boxModelModelOriginal, BoxModelModel boxModelModelLocal)
    {
        if (boxModelModelLocal != null)
        {
            if (boxModelModelLocal.BoxModel != null)
            {
                boxModelModelOriginal.BoxModel = boxModelModelLocal.BoxModel;
            }
            if (boxModelModelLocal.BoxModelLanguageList != null)
            {
                boxModelModelOriginal.BoxModelLanguageList = boxModelModelLocal.BoxModelLanguageList;
            }
            foreach (BoxModelResult boxModelResultLocal in boxModelModelLocal.BoxModelResultList)
            {
                BoxModelResult boxModelResultOriginal = boxModelModelOriginal.BoxModelResultList.Where(c => c.BoxModelResultID == boxModelResultLocal.BoxModelResultID).FirstOrDefault();
                if (boxModelResultOriginal == null)
                {
                    boxModelModelOriginal.BoxModelResultList.Add(boxModelResultLocal);
                }
                else
                {
                    boxModelResultOriginal = boxModelResultLocal;
                }
            }
        }
    }
}

