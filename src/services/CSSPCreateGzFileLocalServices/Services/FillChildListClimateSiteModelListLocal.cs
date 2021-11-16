/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillChildListClimateSiteModelListLocal(List<ClimateSiteModel> ClimateSiteModelList, TVItem TVItem)
        {
            List<ClimateSite> ClimateSiteList = await GetClimateSiteListUnderProvince(TVItem);

            foreach (ClimateSite climateSite in ClimateSiteList)
            {
                ClimateSiteModel climateSiteModel = new ClimateSiteModel()
                {
                    ClimateSite = climateSite,
                    ClimateDataValueList = await GetClimateDataValueListForClimateSite(climateSite.ClimateSiteTVItemID)
                };

                ClimateSiteModelList.Add(climateSiteModel);
            }
        }
    }
}