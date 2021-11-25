namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncDrogueRunModel(DrogueRunModel drogueRunModelOriginal, DrogueRunModel drogueRunModelLocal)
    {
        if (drogueRunModelLocal != null)
        {
            if (drogueRunModelLocal.DrogueRun != null)
            {
                drogueRunModelOriginal.DrogueRun = drogueRunModelLocal.DrogueRun;
            }

            foreach (DrogueRunPosition drogueRunPositionLocal in drogueRunModelLocal.DrogueRunPositionList)
            {
                DrogueRunPosition drogueRunPositionOriginal = drogueRunModelOriginal.DrogueRunPositionList.Where(c => c.DrogueRunPositionID == drogueRunPositionLocal.DrogueRunPositionID).FirstOrDefault();

                if (drogueRunPositionOriginal == null)
                {
                    drogueRunModelOriginal.DrogueRunPositionList.Add(drogueRunPositionLocal);
                }
                else
                {
                    drogueRunPositionOriginal = drogueRunPositionLocal;
                }
            }
        }
    }
}

