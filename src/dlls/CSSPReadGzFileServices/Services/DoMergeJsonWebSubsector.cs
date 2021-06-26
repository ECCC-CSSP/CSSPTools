/*
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
        private void DoMergeJsonWebSubsector(WebSubsector WebSubsector, WebSubsector WebSubsectorLocal)
        {
            if (WebSubsectorLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebSubsectorLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebSubsector.TVItemModel = WebSubsectorLocal.TVItemModel;
            }

            if ((from c in WebSubsectorLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebSubsector.TVItemModelParentList = WebSubsectorLocal.TVItemModelParentList;
            }

            List<TVFileModel> TVFileModelList = (from c in WebSubsectorLocal.TVFileModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebSubsector.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebSubsector.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }

            // checking if files are localized
            DirectoryInfo di = new DirectoryInfo($"{CSSPFilesPath}{WebSubsector.TVItemModel.TVItem.TVItemID}\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in WebSubsector.TVFileModelList)
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
