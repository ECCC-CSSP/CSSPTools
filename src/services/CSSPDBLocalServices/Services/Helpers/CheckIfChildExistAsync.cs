namespace CSSPDBLocalServices;


public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public async Task CheckIfChildExistAsync(TVItem tvItemParent, TVItem tvItem)
    {
        List<TVItemModel> tvItemModelList = new List<TVItemModel>();
        List<TVFileModel> tvFileModelList = new List<TVFileModel>();

        switch (tvItem.TVType)
        {
            case TVTypeEnum.Address:
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.NotAllowedToRemove_, "Address"));
                }
                break;
            case TVTypeEnum.Area:
                {
                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItem.TVItemID);

                    if ((from c in webArea.TVItemModelSectorList
                         where c.TVItem != null
                         && c.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Area", "Sector"));
                    }

                    if ((from c in webArea.TVFileModelList
                         where c.TVFile != null
                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Area", "File"));
                    }
                }
                break;
            case TVTypeEnum.Classification:
                {
                    // there are no child of anything possible for Classification
                }
                break;
            case TVTypeEnum.ClimateSite:
                {
                    WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, (int)tvItem.ParentID);

                    ClimateSiteModel climateSiteModel = (from c in webClimateSites.ClimateSiteModelList
                                                         where c.TVItemModel != null
                                                         && c.TVItemModel.TVItem != null
                                                         && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                         select c).FirstOrDefault();

                    if (climateSiteModel != null)
                    {
                        if (climateSiteModel.ClimateSite != null && climateSiteModel.ClimateSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem ClimateSite", "ClimateSite"));
                        }
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                    List<UseOfSite> useOfSiteList = (from c in webAllUseOfSites.UseOfSiteList
                                                     where c.SiteTVItemID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.ClimateSite
                                                     select c).ToList();

                    if ((from c in useOfSiteList
                         where c.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem ClimateSite", "UseOfSite"));
                    }
                }
                break;
            case TVTypeEnum.Country:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItem.TVItemID);

                    if ((from c in webCountry.TVItemModelProvinceList
                         where c.TVItem != null
                         && c.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "Province"));
                    }

                    if ((from c in webCountry.RainExceedanceModelList
                         where c.RainExceedance != null
                         && c.RainExceedance.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "RainExceedance"));
                    }

                    if ((from c in webCountry.EmailDistributionListModelList
                         where c.EmailDistributionList != null
                         && c.EmailDistributionList.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "EmailDistributionList"));
                    }

                    if ((from c in webCountry.TVFileModelList
                         where c.TVFile != null
                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "File"));
                    }
                }
                break;
            case TVTypeEnum.Email:
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.NotAllowedToRemove_, "Email"));
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
                                WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, tvItem.TVItemID);

                                if ((from c in webArea.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Area TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, tvItem.TVItemID);

                                if ((from c in webCountry.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Country TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.Infrastructure:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                                InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                           where c.TVItemModel != null
                                                                           && c.TVItemModel.TVItem != null
                                                                           && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                if (infrastructureModel != null)
                                {
                                    if ((from c in infrastructureModel.TVFileModelList
                                         where c.TVFile != null
                                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                         select c).Any())
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Infrastructure TVFile"));
                                    }
                                }
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                                if ((from c in webProvince.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Province TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                       where c.TVItemModel != null
                                                                       && c.TVItemModel.TVItem != null
                                                                       && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                       select c).FirstOrDefault();

                                if (mikeScenarioModel != null)
                                {
                                    if ((from c in mikeScenarioModel.TVFileModelList
                                         where c.TVFile != null
                                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                         select c).Any())
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "MikeScenario TVFile"));
                                    }
                                }
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                                if ((from c in webMunicipality.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Municipality TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.MWQMSite:
                            {
                                WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);

                                MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                               where c.TVItemModel != null
                                                               && c.TVItemModel.TVItem != null
                                                               && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                                if (mwqmSiteModel != null)
                                {
                                    if ((from c in mwqmSiteModel.TVFileModelList
                                         where c.TVFile != null
                                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                         select c).Any())
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "MWQMSite TVFile"));
                                    }
                                }
                            }
                            break;
                        case TVTypeEnum.PolSourceSite:
                            {
                                WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);

                                PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                         where c.TVItemModel != null
                                                                         && c.TVItemModel.TVItem != null
                                                                         && c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                         select c).FirstOrDefault();

                                if (polSourceSiteModel != null)
                                {
                                    if ((from c in polSourceSiteModel.TVFileModelList
                                         where c.TVFile != null
                                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                         select c).Any())
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "PolSourceSite TVFile"));
                                    }
                                }
                            }
                            break;
                        case TVTypeEnum.Root:
                            {
                                WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, tvItem.TVItemID);

                                if ((from c in webRoot.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.TVFileTVItemID == tvItem.TVItemID
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Root TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItem.TVItemID);

                                if ((from c in webSector.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Sector TVFile"));
                                }
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItem.TVItemID);

                                if ((from c in webSubsector.TVFileModelList
                                     where c.TVFile != null
                                     && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                     select c).Any())
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Subsector TVFile"));
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItem.ParentID);

                    InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                               where c.TVItemModel != null
                                                               && c.TVItemModel.TVItem != null
                                                               && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                               select c).FirstOrDefault();

                    if (infrastructureModel.BoxModelModelList != null)
                    {
                        if ((from c in infrastructureModel.BoxModelModelList
                             where c.BoxModel != null
                             && c.BoxModel.DBCommand != DBCommandEnum.Deleted
                             select c).Any())
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "BoxModel"));
                        }
                    }

                    if (infrastructureModel.VPScenarioModelList != null)
                    {
                        if ((from c in infrastructureModel.VPScenarioModelList
                             where c.VPScenario != null
                             && c.VPScenario.DBCommand != DBCommandEnum.Deleted
                             select c).Any())
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "VPScenario"));
                        }
                    }

                    if (infrastructureModel.TVFileModelList != null)
                    {
                        if ((from c in infrastructureModel.TVFileModelList
                             where c.TVFile != null
                             && c.TVFile.DBCommand != DBCommandEnum.Deleted
                             select c).Any())
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "File"));
                        }
                    }
                }
                break;
            case TVTypeEnum.HydrometricSite:
                {
                    WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, (int)tvItem.ParentID);

                    HydrometricSiteModel climateSiteModel = (from c in webHydrometricSites.HydrometricSiteModelList
                                                             where c.TVItemModel != null
                                                             && c.TVItemModel.TVItem != null
                                                             && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                             select c).FirstOrDefault();

                    if (climateSiteModel != null)
                    {
                        if (climateSiteModel.HydrometricSite != null && climateSiteModel.HydrometricSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem HydrometricSite", "HydrometricSite"));
                        }
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                    List<UseOfSite> useOfSiteList = (from c in webAllUseOfSites.UseOfSiteList
                                                     where c.SiteTVItemID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.HydrometricSite
                                                     select c).ToList();

                    foreach (UseOfSite useOfSite in useOfSiteList)
                    {
                        if (useOfSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem HydrometricSite", "UseOfSite"));
                        }
                    }
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
                        MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                                                 where c.TVItemModel != null
                                                                                 && c.TVItemModel.TVItem != null
                                                                                 && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                                                 select c).FirstOrDefault();

                        if (mikeBoundaryConditionModel != null)
                        {
                            if (mikeBoundaryConditionModel.MikeBoundaryCondition != null && mikeBoundaryConditionModel.MikeBoundaryCondition.DBCommand != DBCommandEnum.Deleted)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeSource", "MikeSource"));
                            }
                        }
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
                        MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                                                                 where c.TVItemModel != null
                                                                                 && c.TVItemModel.TVItem != null
                                                                                 && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                                                 select c).FirstOrDefault();

                        if (mikeBoundaryConditionModel != null)
                        {
                            if (mikeBoundaryConditionModel.MikeBoundaryCondition != null && mikeBoundaryConditionModel.MikeBoundaryCondition.DBCommand != DBCommandEnum.Deleted)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeSource", "MikeSource"));
                            }
                        }
                    }
                }
                break;
            case TVTypeEnum.MikeScenario:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);

                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                           where c.TVItemModel != null
                                                           && c.TVItemModel.TVItem != null
                                                           && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                           select c).FirstOrDefault();

                    if (mikeScenarioModel != null)
                    {
                        if (mikeScenarioModel.MikeScenario != null && mikeScenarioModel.MikeScenario.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeScenario", "MikeScenario"));
                        }
                    }
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
                        MikeSourceModel mikeSourceModel = (from c in mikeScenarioModel.MikeSourceModelList
                                                           where c.TVItemModel != null
                                                           && c.TVItemModel.TVItem != null
                                                           && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                           select c).FirstOrDefault();

                        if (mikeSourceModel != null)
                        {
                            if (mikeSourceModel.MikeSource != null && mikeSourceModel.MikeSource.DBCommand != DBCommandEnum.Deleted)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeSource", "MikeSource"));
                            }
                        }
                    }
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                    if ((from c in webMunicipality.InfrastructureModelList
                         where c.Infrastructure != null
                         && c.Infrastructure.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Municipality", "Infrastructure"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                    if ((from c in webMikeScenarios.MikeScenarioModelList
                         where c.MikeScenario != null
                         && c.MikeScenario.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Municipality", "MikeScenario"));
                    }
                }
                break;
            case TVTypeEnum.MWQMRun:
                {
                    WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, (int)tvItem.ParentID);

                    MWQMRunModel mwqmRunModel = (from c in webMWQMRuns.MWQMRunModelList
                                                 where c.TVItemModel != null
                                                 && c.TVItemModel.TVItem != null
                                                 && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                 select c).FirstOrDefault();

                    if (mwqmRunModel != null)
                    {
                        bool showError = false;
                        if (mwqmRunModel.MWQMRun != null && mwqmRunModel.MWQMRun.DBCommand != DBCommandEnum.Deleted)
                        {
                            showError = true;
                        }
                        if (mwqmRunModel.MWQMRunLanguageList.Count > 0 && mwqmRunModel.MWQMRunLanguageList[0].DBCommand != DBCommandEnum.Deleted)
                        {
                            showError = true;
                        }
                        if (mwqmRunModel.MWQMRunLanguageList.Count > 1 && mwqmRunModel.MWQMRunLanguageList[1].DBCommand != DBCommandEnum.Deleted)
                        {
                            showError = true;
                        }
                        if (showError)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MWQMRun", "MWQMRun"));
                        }
                    }
                }
                break;
            case TVTypeEnum.MWQMSite:
                {
                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItem.ParentID);

                    MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                   where c.TVItemModel != null
                                                   && c.TVItemModel.TVItem != null
                                                   && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                   select c).FirstOrDefault();

                    if (mwqmSiteModel != null)
                    {
                        if (mwqmSiteModel.MWQMSite != null && mwqmSiteModel.MWQMSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MWQMSite", "MWQMSite"));
                        }
                    }
                }
                break;
            case TVTypeEnum.PolSourceSite:
                {
                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItem.ParentID);

                    PolSourceSiteModel mwqmRunModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                       where c.TVItemModel != null
                                                       && c.TVItemModel.TVItem != null
                                                       && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                       select c).FirstOrDefault();

                    if (mwqmRunModel != null)
                    {
                        if (mwqmRunModel.PolSourceSite != null && mwqmRunModel.PolSourceSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem PolSourceSite", "PolSourceSite"));
                        }
                    }
                }
                break;
            case TVTypeEnum.Province:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                    if ((from c in webProvince.TVItemModelAreaList
                         where c.TVItem != null
                         && c.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Area"));
                    }

                    if ((from c in webProvince.SamplingPlanModelList
                         where c.SamplingPlan != null
                         && c.SamplingPlan.ProvinceTVItemID == tvItem.TVItemID
                         && c.SamplingPlan.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "SamplingPlan"));
                    }

                    if ((from c in webProvince.TVItemModelMunicipalityList
                         where c.TVItem != null
                         && c.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Municipality"));
                    }

                    if ((from c in webProvince.TVFileModelList
                         where c.TVFile != null
                         && c.TVFile.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "File"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebClimateSites webClimateSite = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItem.TVItemID);

                    if ((from c in webClimateSite.ClimateSiteModelList
                         where c.TVItemModel != null
                         && c.TVItemModel.TVItem != null
                         && c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                         && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "ClimateSite"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebHydrometricSites webHydrometricSite = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);

                    if ((from c in webHydrometricSite.HydrometricSiteModelList
                         where c.TVItemModel != null
                         && c.TVItemModel.TVItem != null
                         && c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                         && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "HydrometricSite"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebTideSites webTideSite = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, tvItem.TVItemID);

                    if ((from c in webTideSite.TideSiteModelList
                         where c.TVItemModel != null
                         && c.TVItemModel.TVItem != null
                         && c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                         && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "TideSite"));
                    }
                }
                break;
            case TVTypeEnum.RainExceedance:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, (int)tvItem.ParentID);

                    RainExceedanceModel rainExceedanceModel = (from c in webCountry.RainExceedanceModelList
                                                               where c.TVItemModel != null
                                                               && c.TVItemModel.TVItem != null
                                                               && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                               select c).FirstOrDefault();

                    if (rainExceedanceModel != null)
                    {
                        if (rainExceedanceModel.RainExceedance != null && rainExceedanceModel.RainExceedance.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem RainExceedance", "RainExceedance"));
                        }
                    }
                }
                break;
            case TVTypeEnum.Root:
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.NotAllowedToRemove_, "Root"));
                }
                break;
            case TVTypeEnum.SamplingPlan:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                    if ((from c in webProvince.SamplingPlanModelList
                         where c.SamplingPlan != null
                         && c.SamplingPlan.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem SamplingPlan", "SamplingPlan"));
                    }
                }
                break;
            case TVTypeEnum.Sector:
                {
                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, tvItem.TVItemID);

                    if ((from c in webSector.TVItemModelSubsectorList
                         where c.TVItem != null
                         && c.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Sector", "Subsector"));
                    }
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, tvItem.TVItemID);

                    if ((from c in webSubsector.ClassificationModelList
                         where c.TVItemModel.TVItem != null
                         && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "Classification"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);

                    if ((from c in webMWQMRuns.MWQMRunModelList
                         where c.MWQMRun != null
                         && c.MWQMRun.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "MWQMRun"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);

                    if ((from c in webMWQMSites.MWQMSiteModelList
                         where c.MWQMSite != null
                         && c.MWQMSite.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "MWQMSite"));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);

                    if ((from c in webPolSourceSites.PolSourceSiteModelList
                         where c.PolSourceSite != null
                         && c.PolSourceSite.DBCommand != DBCommandEnum.Deleted
                         select c).Any())
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "PolSourceSite"));
                    }
                }
                break;
            case TVTypeEnum.Tel:
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.NotAllowedToRemove_, "Tel"));
                }
                break;
            case TVTypeEnum.TideSite:
                {
                    WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, (int)tvItem.ParentID);

                    TideSiteModel climateSiteModel = (from c in webTideSites.TideSiteModelList
                                                      where c.TVItemModel != null
                                                      && c.TVItemModel.TVItem != null
                                                      && c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                      select c).FirstOrDefault();

                    if (climateSiteModel != null)
                    {
                        if (climateSiteModel.TideSite != null && climateSiteModel.TideSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem TideSite", "TideSite"));
                        }
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                    WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                    List<UseOfSite> useOfSiteList = (from c in webAllUseOfSites.UseOfSiteList
                                                     where c.SiteTVItemID == tvItem.TVItemID
                                                     && c.TVType == TVTypeEnum.TideSite
                                                     select c).ToList();

                    foreach (UseOfSite useOfSite in useOfSiteList)
                    {
                        if (useOfSite.DBCommand != DBCommandEnum.Deleted)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem TideSite", "UseOfSite"));
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}
