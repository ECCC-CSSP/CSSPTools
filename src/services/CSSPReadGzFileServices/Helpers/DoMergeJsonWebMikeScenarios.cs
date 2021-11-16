/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private async Task<bool> DoMergeJsonWebMikeScenarios(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMikeScenarios WebMikeScenarios, WebMikeScenarios WebMikeScenariosLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebMikeScenariosTVItemModel(webMikeScenarios, webMikeScenariosLocal);

            DoMergeJsonWebMikeScenariosTVItemModelParentList(webMikeScenarios, webMikeScenariosLocal);

            DoMergeJsonWebMikeScenariosMikeScenarioModelList(webMikeScenarios, webMikeScenariosLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebMikeScenariosTVItemModel(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal)
        {
            if (webMikeScenariosLocal.TVItemModel.TVItem.TVItemID != 0
                && (webMikeScenariosLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || webMikeScenariosLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || webMikeScenariosLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                SyncTVItemModel(webMikeScenarios.TVItemModel, webMikeScenariosLocal.TVItemModel);
            }
        }
        private void DoMergeJsonWebMikeScenariosTVItemModelParentList(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal)
        {
            if ((from c in webMikeScenariosLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                SyncTVItemModelParentList(webMikeScenarios.TVItemModelParentList, webMikeScenariosLocal.TVItemModelParentList);
            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelList(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal)
        {
            List<MikeScenarioModel> MikeScenarioModelListLocal = (from c in webMikeScenariosLocal.MikeScenarioModelList
                                                                  select c).ToList();

            foreach (MikeScenarioModel mikeScenarioModelLocal in MikeScenarioModelListLocal)
            {
                MikeScenarioModel mikeScenarioModelOriginal = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == mikeScenarioModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();

                if (mikeScenarioModelOriginal == null)
                {
                    webMikeScenarios.MikeScenarioModelList.Add(mikeScenarioModelLocal);

                    mikeScenarioModelOriginal = webMikeScenarios.MikeScenarioModelList.Where(c => c.TVItemModel.TVItem.TVItemID == mikeScenarioModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                }

                DoMergeJsonWebMikeScenariosMikeScenarioModelListMikeBoundaryConditionModel(webMikeScenarios, webMikeScenariosLocal, mikeScenarioModelOriginal, mikeScenarioModelLocal);

                DoMergeJsonWebMikeScenariosMikeScenarioModelListMikeSourceModel(webMikeScenarios, webMikeScenariosLocal, mikeScenarioModelOriginal, mikeScenarioModelLocal);

                DoMergeJsonWebMikeScenariosMikeScenarioModelListTVItemModel(webMikeScenarios, webMikeScenariosLocal, mikeScenarioModelOriginal, mikeScenarioModelLocal);

                DoMergeJsonWebMikeScenariosMikeScenarioModelListTVFileModelList(webMikeScenarios, webMikeScenariosLocal, mikeScenarioModelOriginal, mikeScenarioModelLocal);

                DoMergeJsonWebMikeScenariosMikeScenarioModelListIsLocalized(webMikeScenarios, webMikeScenariosLocal, mikeScenarioModelOriginal, mikeScenarioModelLocal);

            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelListMikeBoundaryConditionModel(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal, MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelLocal)
        {
            List<MikeBoundaryConditionModel> mikeBoundaryConditionModelListLocal = (from c in mikeScenarioModelLocal.MikeBoundaryConditionModelList
                                                                                    select c).ToList();

            foreach (MikeBoundaryConditionModel mikeBoundaryConditionModelLocal in mikeBoundaryConditionModelListLocal)
            {
                if (mikeBoundaryConditionModelLocal.TVItemModel.TVItem.TVItemID != 0
                    && (mikeBoundaryConditionModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                    || mikeBoundaryConditionModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                    || mikeBoundaryConditionModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelOriginal = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == mikeBoundaryConditionModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                    if (mikeBoundaryConditionModelOriginal == null)
                    {
                        mikeScenarioModel.MikeBoundaryConditionModelList.Add(mikeBoundaryConditionModelLocal);
                    }
                    else
                    {
                        SyncMikeBoundaryConditionModel(mikeBoundaryConditionModelOriginal, mikeBoundaryConditionModelLocal);
                    }
                }
            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelListMikeSourceModel(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal, MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelLocal)
        {
            List<MikeSourceModel> mikeSourceModelListLocal = (from c in mikeScenarioModelLocal.MikeSourceModelList
                                                              select c).ToList();

            foreach (MikeSourceModel mikeSourceModelLocal in mikeSourceModelListLocal)
            {
                if (mikeSourceModelLocal.TVItemModel.TVItem.TVItemID != 0
                    && (mikeSourceModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                    || mikeSourceModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                    || mikeSourceModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
                {
                    MikeSourceModel mikeSourceModelOriginal = mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == mikeSourceModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
                    if (mikeSourceModelOriginal == null)
                    {
                        mikeScenarioModel.MikeSourceModelList.Add(mikeSourceModelLocal);
                    }
                    else
                    {
                        SyncMikeSourceModel(mikeSourceModelOriginal, mikeSourceModelLocal);
                    }
                }
            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelListTVItemModel(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal, MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelLocal)
        {
            if (mikeScenarioModelLocal.TVItemModel != null)
            {
                if (mikeScenarioModelLocal.TVItemModel.TVItem.TVItemID != 0
                    && (mikeScenarioModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                  || mikeScenarioModelLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                  || mikeScenarioModelLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
                {
                    SyncTVItemModel(mikeScenarioModel.TVItemModel, mikeScenarioModelLocal.TVItemModel);
                }
            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelListTVFileModelList(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal, MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelLocal)
        {
            List<TVFileModel> TVFileModelLocalList = (from c in mikeScenarioModelLocal.TVFileModelList
                                                 where c.TVFile.TVFileID != 0
                                                 && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                 || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
            {
                TVFileModel tvFileModelOriginal = mikeScenarioModel.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    mikeScenarioModel.TVFileModelList.Add(tvFileModelLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
                }
            }
        }
        private void DoMergeJsonWebMikeScenariosMikeScenarioModelListIsLocalized(WebMikeScenarios webMikeScenarios, WebMikeScenarios webMikeScenariosLocal, MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelLocal)
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ mikeScenarioModel.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in mikeScenarioModel.TVFileModelList)
                {
                    if ((from c in FileInfoList
                         where c.Name == tvFileModel.TVFile.ServerFileName
                         select c).Any())
                    {
                        tvFileModel.IsLocalized = true;
                    }
                    else
                    {
                        tvFileModel.IsLocalized = false;
                    }
                }
            }
        }
    }
}
