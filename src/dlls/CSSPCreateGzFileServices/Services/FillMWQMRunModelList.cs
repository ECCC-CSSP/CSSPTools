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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillMWQMRunModelList(List<MWQMRunModel> MWQMRunModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);

            List<MWQMRun> MWQMRunList = await GetMWQMRunListFromSubsector(TVItem);
            List<MWQMRunLanguage> MWQMRunLanguageList = await GetMWQMRunLanguageListFromSubsector(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MWQMRunModel mwqmRunModel = new MWQMRunModel();

                TVItemStatModel tvItemStatModel = new TVItemStatModel();
                tvItemStatModel.TVItem = tvItem;
                tvItemStatModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                tvItemStatModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                mwqmRunModel.TVItemStatModel = tvItemStatModel;

                mwqmRunModel.MWQMRun = MWQMRunList.Where(c => c.MWQMRunTVItemID == tvItem.TVItemID).FirstOrDefault();
                mwqmRunModel.MWQMRunLanguageList = MWQMRunLanguageList.Where(c => c.MWQMRunID == mwqmRunModel.MWQMRun.MWQMRunID).ToList();

                MWQMRunModelList.Add(mwqmRunModel);
            }
        }
    }
}