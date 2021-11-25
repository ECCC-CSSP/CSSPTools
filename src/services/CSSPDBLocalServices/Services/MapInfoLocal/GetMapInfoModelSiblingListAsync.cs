namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    private async Task<List<MapInfoModel>> GetMapInfoModelSiblingListAsync(TVItem tvItemParent, TVItem tvItem)
    {
        List<TVItemModel> tvItemModelList = new List<TVItemModel>();

        switch (tvItem.TVType)
        {
            case TVTypeEnum.Address:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.Area:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                    tvItemModelList = webProvince.TVItemModelAreaList;
                }
                break;
            case TVTypeEnum.Classification:
                {
                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webSubsector.ClassificationModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.ClimateSite:
                {
                    WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webClimateSites.ClimateSiteModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.Country:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);
                    tvItemModelList = webRoot.TVItemModelCountryList;
                }
                break;
            case TVTypeEnum.Email:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.EmailDistributionList:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.File:
                {
                    switch (tvItemParent.TVType)
                    {
                        case TVTypeEnum.Area:
                            {
                                WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webArea.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webCountry.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.Infrastructure:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemParent.ParentID);

                                InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                           where c.TVItemModel != null
                                                                           && c.TVItemModel.TVItem != null
                                                                           && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                if (infrastructureModel != null)
                                {
                                    tvItemModelList = new List<TVItemModel>() { infrastructureModel.TVItemModel };
                                }
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webProvince.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                       where c.TVItemModel != null
                                                                       && c.TVItemModel.TVItem != null
                                                                       && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                       select c).FirstOrDefault();

                                if (mikeScenarioModel != null)
                                {
                                    tvItemModelList = (from c in mikeScenarioModel.MikeSourceModelList
                                                       select c.TVItemModel).ToList();
                                }
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webMunicipality.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.MWQMSite:
                            {
                                WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemParent.ParentID);

                                MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                               where c.TVItemModel != null
                                                               && c.TVItemModel.TVItem != null
                                                               && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                                if (mwqmSiteModel != null)
                                {
                                    tvItemModelList = new List<TVItemModel>() { mwqmSiteModel.TVItemModel };
                                }
                            }
                            break;
                        case TVTypeEnum.PolSourceSite:
                            {
                                WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemParent.ParentID);

                                PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                         where c.TVItemModel != null
                                                                         && c.TVItemModel.TVItem != null
                                                                         && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                         select c).FirstOrDefault();

                                if (polSourceSiteModel != null)
                                {
                                    tvItemModelList = new List<TVItemModel>() { polSourceSiteModel.TVItemModel };
                                }
                            }
                            break;
                        case TVTypeEnum.Root:
                            {
                                WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webRoot.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webSector.TVItemModel };
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                                tvItemModelList = new List<TVItemModel>() { webSubsector.TVItemModel };
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webMunicipality.InfrastructureModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.HydrometricSite:
                {
                    WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webHydrometricSites.HydrometricSiteModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.MikeBoundaryConditionMesh:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel != null
                                                           && c.TVItemModel.TVItem != null
                                                           && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel != null)
                    {
                        tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                           where c.MikeBoundaryCondition != null
                                           && c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                           select c.TVItemModel).ToList();
                    }
                }
                break;
            case TVTypeEnum.MikeBoundaryConditionWebTide:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel != null
                                                           && c.TVItemModel.TVItem != null
                                                           && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel != null)
                    {
                        tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                           where c.MikeBoundaryCondition != null
                                           && c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                           select c.TVItemModel).ToList();
                    }
                }
                break;
            case TVTypeEnum.MikeScenario:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.MikeSource:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel != null
                                                           && c.TVItemModel.TVItem != null
                                                           && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel != null)
                    {
                        tvItemModelList = (from c in mikeScenarioModel.MikeSourceModelList
                                           select c.TVItemModel).ToList();
                    }
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                    tvItemModelList = webProvince.TVItemModelMunicipalityList;
                }
                break;
            case TVTypeEnum.MWQMRun:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.MWQMSite:
                {
                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webMWQMSites.MWQMSiteModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.PolSourceSite:
                {
                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webPolSourceSites.PolSourceSiteModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            case TVTypeEnum.Province:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                    tvItemModelList = webCountry.TVItemModelProvinceList;
                }
                break;
            case TVTypeEnum.RainExceedance:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.SamplingPlan:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.Sector:
                {
                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webArea.TVItemModelSectorList
                                       select c).ToList();
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webSector.TVItemModelSubsectorList
                                       select c).ToList();
                }
                break;
            case TVTypeEnum.Tel:
                {
                    // no checking required
                }
                break;
            case TVTypeEnum.TideSite:
                {
                    WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, tvItemParent.TVItemID);
                    tvItemModelList = (from c in webTideSites.TideSiteModelList
                                       select c.TVItemModel).ToList();
                }
                break;
            default:
                break;
        }

        List<MapInfoModel> mapInfoModelList = new List<MapInfoModel>();

        foreach (TVItemModel tvItemModel in tvItemModelList)
        {
            mapInfoModelList.AddRange(tvItemModel.MapInfoModelList);
        }

        return await Task.FromResult(mapInfoModelList);
    }

}

