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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
}
