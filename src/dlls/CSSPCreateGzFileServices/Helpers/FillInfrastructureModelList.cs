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
using System.Text.RegularExpressions;
using System.Reflection;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillInfrastructureModelList(List<TVItemModel> TVItemModelParentList, List<InfrastructureModel> InfrastructureModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            CSSPLogService.FunctionLog(FunctionName);

            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<TVItem> TVItemFileListAll = await GetTVItemListFileUnderMunicipality(TVItem);
            List<TVItemLanguage> TVItemLanguageFileListAll = await GetTVItemLanguageListFileUnderMunicipality(TVItem);

            List<Infrastructure> InfrastructureList = await GetInfrastructureListUnderMunicipality(TVItem);
            List<InfrastructureLanguage> InfrastructureLanguageList = await GetInfrastructureLanguageListUnderMunicipality(TVItem);
            List<BoxModel> BoxModelList = await GetBoxModelListUnderMunicipality(TVItem);
            List<BoxModelLanguage> BoxModelLanguageList = await GetBoxModelLanguageListUnderMunicipality(TVItem);
            List<BoxModelResult> BoxModelResultList = await GetBoxModelResultListUnderMunicipality(TVItem);
            List<VPScenario> VPScenarioList = await GetVPScenarioListUnderMunicipality(TVItem);
            List<VPScenarioLanguage> VPScenarioLanguageList = await GetVPScenarioLanguageListUnderMunicipality(TVItem);
            List<VPAmbient> VPAmbientList = await GetVPAmbientListUnderMunicipality(TVItem);
            List<VPResult> VPResultList = await GetVPResultListUnderMunicipality(TVItem);

            List<TVFile> TVFileListAll = await GetAllTVFileListUnder(TVItem);
            List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnder(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {

                InfrastructureModel InfrastructureModel = new InfrastructureModel();

                InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();

                TVItemModel TVItemModel = new TVItemModel();
                TVItemModel.TVItem = tvItem;
                TVItemModel.TVItemLanguageList = (from c in TVItemLanguageList 
                                                  where c.TVItemID == tvItem.TVItemID 
                                                  orderby c.Language 
                                                  select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in TVItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    TVItemModel.MapInfoModelList.Add(MapInfoModel);
                }

                InfrastructureModel.TVItemModel = TVItemModel;

                foreach (TVFile tvFile in TVFileListAll.Where(c => c.TVFileTVItemID == tvItem.TVItemID))
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVFile = tvFile;
                    tvFileModel.TVFileLanguageList = (from c in TVFileLanguageListAll
                                                      where c.TVFileID == tvFileModel.TVFile.TVFileID
                                                      orderby c.Language
                                                      select c).ToList();

                    InfrastructureModel.TVFileModelList.Add(tvFileModel);

                }

                InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();
                InfrastructureModel.InfrastructureLanguageList = InfrastructureLanguageList.Where(c => c.InfrastructureID == InfrastructureModel.Infrastructure.InfrastructureID).ToList();

                foreach (BoxModel BoxModel in BoxModelList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID))
                {
                    BoxModelModel BoxModelModel = new BoxModelModel();
                    BoxModelModel.BoxModel = BoxModel;
                    BoxModelModel.BoxModelLanguageList = BoxModelLanguageList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();
                    BoxModelModel.BoxModelResultList = BoxModelResultList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();

                    InfrastructureModel.BoxModelModelList.Add(BoxModelModel);
                }

                foreach (VPScenario VPScenario in VPScenarioList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID))
                {
                    VPScenarioModel VPScenarioModel = new VPScenarioModel();
                    VPScenarioModel.VPScenario = VPScenario;
                    VPScenarioModel.VPScenarioLanguageList = VPScenarioLanguageList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                    VPScenarioModel.VPAmbientList = VPAmbientList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                    VPScenarioModel.VPResultList = VPResultList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();

                    InfrastructureModel.VPScenarioModelList.Add(VPScenarioModel);
                }

                InfrastructureModelList.Add(InfrastructureModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}