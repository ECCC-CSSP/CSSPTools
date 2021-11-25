namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncPolSourceObservationModel(PolSourceObservationModel polSourceObservationModelOriginal, PolSourceObservationModel polSourceObservationModelLocal)
    {
        if (polSourceObservationModelLocal != null)
        {
            if (polSourceObservationModelLocal.PolSourceObservation != null)
            {
                polSourceObservationModelOriginal.PolSourceObservation = polSourceObservationModelLocal.PolSourceObservation;
            }

            foreach (PolSourceObservationIssue polSourceObservationIssueLocal in polSourceObservationModelLocal.PolSourceObservationIssueList)
            {
                PolSourceObservationIssue polSourceObservationIssueOriginal = polSourceObservationModelOriginal.PolSourceObservationIssueList.Where(c => c.PolSourceObservationIssueID == polSourceObservationIssueLocal.PolSourceObservationIssueID).FirstOrDefault();
                if (polSourceObservationIssueOriginal == null)
                {
                    polSourceObservationModelOriginal.PolSourceObservationIssueList.Add(polSourceObservationIssueLocal);
                }
                else
                {
                    polSourceObservationIssueOriginal = polSourceObservationIssueLocal;
                }
            }
        }
    }
}

