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
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private void SyncPolSourceSiteModel(PolSourceSiteModel polSourceSiteModelOriginal, PolSourceSiteModel polSourceSiteModelLocal)
        {
            if (polSourceSiteModelLocal != null)
            {
                if (polSourceSiteModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(polSourceSiteModelOriginal.TVItemModel, polSourceSiteModelLocal.TVItemModel);
                }

                if (polSourceSiteModelLocal.PolSourceSite != null)
                {
                    polSourceSiteModelOriginal.PolSourceSite = polSourceSiteModelLocal.PolSourceSite;
                }
                
                List<TVFileModel> TVFileModelLocalList = (from c in polSourceSiteModelLocal.TVFileModelList
                                                     where c.TVFile.TVFileID != 0
                                                     && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                     || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                     || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                     select c).ToList();

                foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
                {
                    TVFileModel tvFileModelOriginal = polSourceSiteModelLocal.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
                    if (tvFileModelOriginal == null)
                    {
                        polSourceSiteModelLocal.TVFileModelList.Add(tvFileModelLocal);
                    }
                    else
                    {
                        SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                    }
                }

                foreach (PolSourceObservationModel polSourceObservationModelLocal in polSourceSiteModelLocal.PolSourceObservationModelList)
                {
                    PolSourceObservationModel polSourceObservationModelOriginal = polSourceSiteModelLocal.PolSourceObservationModelList.Where(c => c.PolSourceObservation.PolSourceObservationID == polSourceObservationModelLocal.PolSourceObservation.PolSourceObservationID).FirstOrDefault();
                    if (polSourceObservationModelOriginal == null)
                    {
                        polSourceSiteModelLocal.PolSourceObservationModelList.Add(polSourceObservationModelLocal);
                    }
                    else
                    {
                        SyncPolSourceObservationModel(polSourceObservationModelOriginal, polSourceObservationModelLocal);
                    }
                }

                foreach (PolSourceSiteEffect polSourceSiteEffectLocal in polSourceSiteModelLocal.PolSourceSiteEffectList)
                {
                    PolSourceSiteEffect polSourceSiteEffectOriginal = polSourceSiteModelLocal.PolSourceSiteEffectList.Where(c => c.PolSourceSiteEffectID== polSourceSiteEffectLocal.PolSourceSiteEffectID).FirstOrDefault();
                    if (polSourceSiteEffectOriginal == null)
                    {
                        polSourceSiteModelLocal.PolSourceSiteEffectList.Add(polSourceSiteEffectLocal);
                    }
                    else
                    {
                        polSourceSiteEffectOriginal = polSourceSiteEffectLocal;
                    }
                }
            }
        }
    }
}
