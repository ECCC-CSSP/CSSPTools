/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
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
}
