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
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillDrogueRunModel(List<DrogueRunModel> DrogueRunModelList, TVItem TVItemProvince)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<DrogueRunModel> DrogueRunModelList, TVItem TVItemProvince) -- TVItem.TVItemID: { TVItemProvince.TVItemID }   TVItem.TVPath: { TVItemProvince.TVPath })";
            await CSSPLogService.FunctionLog(FunctionName);

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

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}