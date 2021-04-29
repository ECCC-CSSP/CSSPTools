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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillDrogueRunModel(List<DrogueRunModel> DrogueRunModelList, TVItem TVItemProvince)
        {
            List<DrogueRun> drogueRunList = await GetDrogueRunListUnderProvince(TVItemProvince);
            List<DrogueRunPosition> drogueRunPositionList = await GetDrogueRunPositionListUnderProvince(TVItemProvince);

            foreach(DrogueRun drogueRun in drogueRunList)
            {
                DrogueRunModel drogueRunModel = new DrogueRunModel()
                {
                    DrogueRun = drogueRun,
                    DrogueRunPositionList = (from c in drogueRunPositionList
                                             where c.DrogueRunID == drogueRun.DrogueRunID
                                             orderby c.Ordinal
                                             select c).ToList(),
                };

                DrogueRunModelList.Add(drogueRunModel);
            }
        }
    }
}