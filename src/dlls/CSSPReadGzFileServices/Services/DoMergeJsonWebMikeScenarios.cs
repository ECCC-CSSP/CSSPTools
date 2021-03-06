﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebMikeScenarios(WebMikeScenarios WebMikeScenarios, WebMikeScenarios WebMikeScenariosLocal)
        {
            if (WebMikeScenariosLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebMikeScenariosLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
              || WebMikeScenariosLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
              || WebMikeScenariosLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebMikeScenarios.TVItemModel = WebMikeScenariosLocal.TVItemModel;
            }

            if ((from c in WebMikeScenariosLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebMikeScenarios.TVItemModelParentList = WebMikeScenariosLocal.TVItemModelParentList;
            }

            List<MikeScenarioModel> MikeScenarioModelList = (from c in WebMikeScenariosLocal.MikeScenarioModelList
                                                               where c.MikeScenario.MikeScenarioID != 0
                                                               && c.MikeScenario.DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (MikeScenarioModel mikeScenarioModel in MikeScenarioModelList)
            {
                MikeScenarioModel mikeScenarioModelOriginal = WebMikeScenarios.MikeScenarioModelList.Where(c => c.MikeScenario.MikeScenarioID == mikeScenarioModel.MikeScenario.MikeScenarioID).FirstOrDefault();
                if (mikeScenarioModelOriginal == null)
                {
                    WebMikeScenarios.MikeScenarioModelList.Add(mikeScenarioModelOriginal);
                }
                else
                {
                    mikeScenarioModelOriginal = mikeScenarioModel;
                }
            }

            // checking if files are localized
            foreach (MikeScenarioModel mikeScenarioModel in WebMikeScenarios.MikeScenarioModelList)
            {
                DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{mikeScenarioModel.TVItemModel.TVItem.TVItemID}\\");

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
}
