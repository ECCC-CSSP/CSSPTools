namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public async Task<List<TVItemModel>> GetTVItemModelParentListAsync(TVItem tvItemParent, TVTypeEnum tvType)
    {
        switch (tvType)
        {
            case TVTypeEnum.Address:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);
                    return await Task.FromResult(webRoot.TVItemModelParentList);
                }
            case TVTypeEnum.Area:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                    return await Task.FromResult(webProvince.TVItemModelParentList);
                }
            case TVTypeEnum.Classification:
                {
                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                    return await Task.FromResult(webSubsector.TVItemModelParentList);
                }
            case TVTypeEnum.ClimateSite:
                {
                    WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItemParent.TVItemID);
                    return await Task.FromResult(webClimateSites.TVItemModelParentList);
                }
            case TVTypeEnum.Country:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                    return await Task.FromResult(webRoot.TVItemModelParentList);
                }
            case TVTypeEnum.Email:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);
                    return await Task.FromResult(webRoot.TVItemModelParentList);
                }
            case TVTypeEnum.EmailDistributionList:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                    return await Task.FromResult(webCountry.TVItemModelParentList);
                }
            case TVTypeEnum.File:
                {
                    switch (tvItemParent.TVType)
                    {
                        case TVTypeEnum.Area:
                            {
                                WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                                return await Task.FromResult(webArea.TVItemModelParentList);
                            }
                        case TVTypeEnum.Country:
                            {
                                WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                                return await Task.FromResult(webCountry.TVItemModelParentList);
                            }
                        case TVTypeEnum.Infrastructure:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemParent.ParentID);

                                List<TVItemModel> tvItemModelList = webMunicipality.TVItemModelParentList;

                                InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                if (infrastructureModel == null)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                    return await Task.FromResult(new List<TVItemModel>());
                                }

                                tvItemModelList.Add(infrastructureModel.TVItemModel);

                                return await Task.FromResult(tvItemModelList);
                            }
                        case TVTypeEnum.Province:
                            {
                                WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                                return await Task.FromResult(webProvince.TVItemModelParentList);
                            }
                        case TVTypeEnum.MikeScenario:
                            {
                                WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                                List<TVItemModel> tvItemModelList = webMikeScenarios.TVItemModelParentList;

                                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                       where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                       select c).FirstOrDefault();

                                if (mikeScenarioModel == null)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                    return await Task.FromResult(new List<TVItemModel>());
                                }

                                tvItemModelList.Add(mikeScenarioModel.TVItemModel);

                                return await Task.FromResult(tvItemModelList);
                            }
                        case TVTypeEnum.Municipality:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                                return await Task.FromResult(webMunicipality.TVItemModelParentList);
                            }
                        case TVTypeEnum.MWQMSite:
                            {
                                WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemParent.ParentID);

                                List<TVItemModel> tvItemModelList = webMWQMSites.TVItemModelParentList;

                                MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                                if (mwqmSiteModel == null)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSiteModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                    return await Task.FromResult(new List<TVItemModel>());
                                }

                                tvItemModelList.Add(mwqmSiteModel.TVItemModel);

                                return await Task.FromResult(tvItemModelList);
                            }
                        case TVTypeEnum.PolSourceSite:
                            {
                                WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemParent.ParentID);

                                List<TVItemModel> tvItemModelList = webPolSourceSites.TVItemModelParentList;

                                PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                         where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                         select c).FirstOrDefault();

                                if (polSourceSiteModel == null)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                    return await Task.FromResult(new List<TVItemModel>());
                                }

                                tvItemModelList.Add(polSourceSiteModel.TVItemModel);

                                return await Task.FromResult(tvItemModelList);
                            }
                        case TVTypeEnum.Root:
                            {
                                WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                                return await Task.FromResult(webRoot.TVItemModelParentList);
                            }
                        case TVTypeEnum.Sector:
                            {
                                WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                                return await Task.FromResult(webSector.TVItemModelParentList);
                            }
                        case TVTypeEnum.Subsector:
                            {
                                WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                                return await Task.FromResult(webSubsector.TVItemModelParentList);
                            }
                        default:
                            break;
                    }
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                    return await Task.FromResult(webMunicipality.TVItemModelParentList);
                }
            case TVTypeEnum.HydrometricSite:
                {
                    WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItemParent.TVItemID);
                    return await Task.FromResult(webHydrometricSites.TVItemModelParentList);
                }
            case TVTypeEnum.MikeBoundaryConditionMesh:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    List<TVItemModel> tvItemModelList = webMikeScenarios.TVItemModelParentList;

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel == null)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                        return await Task.FromResult(new List<TVItemModel>());
                    }

                    tvItemModelList.Add(mikeScenarioModel.TVItemModel);

                    return await Task.FromResult(tvItemModelList);
                }
            case TVTypeEnum.MikeBoundaryConditionWebTide:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    List<TVItemModel> tvItemModelList = webMikeScenarios.TVItemModelParentList;

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel == null)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                        return await Task.FromResult(new List<TVItemModel>());
                    }

                    tvItemModelList.Add(mikeScenarioModel.TVItemModel);

                    return await Task.FromResult(tvItemModelList);
                }
            case TVTypeEnum.MikeScenario:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItemParent.TVItemID);
                    return await Task.FromResult(webMikeScenarios.TVItemModelParentList);
                }
            case TVTypeEnum.MikeSource:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    List<TVItemModel> tvItemModelList = webMikeScenarios.TVItemModelParentList;

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel == null)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                        return await Task.FromResult(new List<TVItemModel>());
                    }

                    tvItemModelList.Add(mikeScenarioModel.TVItemModel);

                    return await Task.FromResult(tvItemModelList);
                }
            case TVTypeEnum.Municipality:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                    return await Task.FromResult(webProvince.TVItemModelParentList);
                }
            case TVTypeEnum.MWQMRun:
                {
                    WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItemParent.TVItemID);
                    return await Task.FromResult(webMWQMRuns.TVItemModelParentList);
                }
            case TVTypeEnum.MWQMSite:
                {
                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItemParent.TVItemID);
                    return await Task.FromResult(webMWQMSites.TVItemModelParentList);
                }
            case TVTypeEnum.PolSourceSite:
                {
                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItemParent.TVItemID);
                    return await Task.FromResult(webPolSourceSites.TVItemModelParentList);
                }
            case TVTypeEnum.Province:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                    return await Task.FromResult(webCountry.TVItemModelParentList);
                }
            case TVTypeEnum.RainExceedance:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                    return await Task.FromResult(webCountry.TVItemModelParentList);
                }
            case TVTypeEnum.Root:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);
                    return await Task.FromResult(webRoot.TVItemModelParentList);
                }
            case TVTypeEnum.SamplingPlan:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                    return await Task.FromResult(webProvince.TVItemModelParentList);
                }
            case TVTypeEnum.Sector:
                {
                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                    return await Task.FromResult(webArea.TVItemModelParentList);
                }
            case TVTypeEnum.Subsector:
                {
                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                    return await Task.FromResult(webSector.TVItemModelParentList);
                }
            case TVTypeEnum.Tel:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);
                    return await Task.FromResult(webRoot.TVItemModelParentList);
                }
            case TVTypeEnum.TideSite:
                {
                    WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, tvItemParent.TVItemID);
                    return await Task.FromResult(webTideSites.TVItemModelParentList);
                }
            default:
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvType.ToString()));
                    return await Task.FromResult(new List<TVItemModel>());
                }
        }

        return await Task.FromResult(new List<TVItemModel>());
    }
}
