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
}
