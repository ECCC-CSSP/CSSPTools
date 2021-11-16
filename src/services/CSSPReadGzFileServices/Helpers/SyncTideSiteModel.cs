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
}
