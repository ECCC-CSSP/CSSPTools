/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private async Task CheckIfChildExist(TVItem tvItemParent, TVItem tvItem)
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
                        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItem.TVItemID);

                        bool childExist = (from c in webArea.TVItemModelSectorList
                                           where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Area", "Sector"));
                        }

                        childExist = (from c in webArea.TVFileModelList
                                      where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Area", "File"));
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItem.TVItemID);

                        bool childExist = (from c in webClimateSites.ClimateSiteModelList
                                           where c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                           && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem ClimateSite", "ClimateSite"));
                        }

                        WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSON<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                        childExist = (from c in webAllUseOfSites.UseOfSiteList
                                      where c.SiteTVItemID == tvItem.TVItemID
                                      && c.TVType == TVTypeEnum.ClimateSite
                                      && c.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem ClimateSite", "UseOfSite"));
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItem.TVItemID);

                        bool childExist = (from c in webCountry.TVItemModelProvinceList
                                           where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "Province"));
                        }

                        childExist = (from c in webCountry.RainExceedanceModelList
                                      where c.RainExceedance.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "RainExceedance"));
                        }

                        childExist = (from c in webCountry.EmailDistributionListModelList
                                      where c.EmailDistributionList.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "EmailDistributionList"));
                        }

                        childExist = (from c in webCountry.TVFileModelList
                                      where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
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
                                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItem.TVItemID);

                                    bool childExist = (from c in webArea.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Area TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItem.TVItemID);

                                    bool childExist = (from c in webCountry.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Country TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                                    InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    if (infrastructureModel == null)
                                    {
                                        bool childExist = (from c in infrastructureModel.TVFileModelList
                                                           where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                           select c).Any();

                                        if (childExist)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Infrastructure TVFile"));
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                                    bool childExist = (from c in webProvince.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Province TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    if (mikeScenarioModel == null)
                                    {
                                        bool childExist = (from c in mikeScenarioModel.TVFileModelList
                                                           where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                           select c).Any();

                                        if (childExist)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "MikeScenario TVFile"));
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                                    bool childExist = (from c in webMunicipality.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Municipality TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);

                                    MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    if (mwqmSiteModel == null)
                                    {
                                        bool childExist = (from c in mwqmSiteModel.TVFileModelList
                                                           where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                           select c).Any();

                                        if (childExist)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "MWQMSite TVFile"));
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);

                                    PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    if (polSourceSiteModel == null)
                                    {
                                        bool childExist = (from c in polSourceSiteModel.TVFileModelList
                                                           where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                           select c).Any();

                                        if (childExist)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "PolSourceSite TVFile"));
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItem.TVItemID);

                                    bool childExist = (from c in webRoot.TVFileModelList
                                                       where c.TVFile.TVFileTVItemID == tvItem.TVItemID
                                                       && c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Root TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItem.TVItemID);

                                    bool childExist = (from c in webSector.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem File", "Sector TVFile"));
                                    }
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItem.TVItemID);

                                    bool childExist = (from c in webSubsector.TVFileModelList
                                                       where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                                       select c).Any();

                                    if (childExist)
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
                        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                        InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                                                   select c).FirstOrDefault();

                        bool childExist = (from c in infrastructureModel.BoxModelModelList
                                           where c.BoxModel.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "BoxModel"));
                        }

                        childExist = (from c in infrastructureModel.VPScenarioModelList
                                      where c.VPScenario.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "BoxModel"));
                        }

                        childExist = (from c in infrastructureModel.TVFileModelList
                                      where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Infrastructure", "BoxModel"));
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);

                        bool childExist = (from c in webHydrometricSites.HydrometricSiteModelList
                                           where c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                           && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem HydrometricSite", "HydrometricSite"));
                        }

                        WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSON<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                        childExist = (from c in webAllUseOfSites.UseOfSiteList
                                      where c.SiteTVItemID == tvItem.TVItemID
                                      && c.TVType == TVTypeEnum.HydrometricSite
                                      && c.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem HydrometricSite", "UseOfSite"));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            bool childExist = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                               where c.MikeBoundaryCondition.DBCommand != DBCommandEnum.Deleted
                                               select c).Any();

                            if (childExist)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeBoundaryCondition", "MikeBoundaryCondition"));
                            }
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            bool childExist = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                               where c.MikeBoundaryCondition.DBCommand != DBCommandEnum.Deleted
                                               select c).Any();

                            if (childExist)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeBoundaryCondition", "MikeBoundaryCondition"));
                            }
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                        bool childExist = (from c in webMikeScenarios.MikeScenarioModelList
                                           where c.MikeScenario.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeScenario", "MikeScenario"));
                        }
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            bool childExist = (from c in mikeScenarioModel.MikeSourceModelList
                                               where c.MikeSource.DBCommand != DBCommandEnum.Deleted
                                               select c).Any();

                            if (childExist)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MikeSource", "MikeSource"));
                            }
                        }
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItem.TVItemID);

                        bool childExist = (from c in webMunicipality.InfrastructureModelList
                                           where c.Infrastructure.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Municipality", "Infrastructure"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);

                        childExist = (from c in webMikeScenarios.MikeScenarioModelList
                                      where c.MikeScenario.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Municipality", "MikeScenario"));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);

                        bool childExist = (from c in webMWQMRuns.MWQMRunModelList
                                           where c.MWQMRun.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MWQMRun", "MWQMRun"));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);

                        bool childExist = (from c in webMWQMSites.MWQMSiteModelList
                                           where c.MWQMSite.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MWQMSite", "MWQMSite"));
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);

                        bool childExist = (from c in webPolSourceSites.PolSourceSiteModelList
                                           where c.PolSourceSite.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem MWQMSite", "MWQMSite"));
                        }

                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                        bool childExist = (from c in webProvince.TVItemModelAreaList
                                           where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Area"));
                        }

                        childExist = (from c in webProvince.SamplingPlanModelList
                                      where c.SamplingPlan.ProvinceTVItemID == tvItem.TVItemID
                                      && c.SamplingPlan.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "SamplingPlan"));
                        }

                        childExist = (from c in webProvince.TVItemModelMunicipalityList
                                      where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Municipality"));
                        }

                        childExist = (from c in webProvince.TVFileModelList
                                      where c.TVFile.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "File"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebClimateSites webClimateSite = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItem.TVItemID);

                        childExist = (from c in webClimateSite.ClimateSiteModelList
                                      where c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                                      && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "ClimateSite"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebHydrometricSites webHydrometricSite = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);

                        childExist = (from c in webHydrometricSite.HydrometricSiteModelList
                                      where c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                                      && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "HydrometricSite"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebTideSites webTideSite = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, tvItem.TVItemID);

                        childExist = (from c in webTideSite.TideSiteModelList
                                      where c.TVItemModel.TVItem.ParentID == tvItem.TVItemID
                                      && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "TideSite"));
                        }
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, (int)tvItem.ParentID);

                        bool childExist = (from c in webCountry.RainExceedanceModelList
                                           where c.RainExceedance.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem RainExceedance", "RainExceedance"));
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
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItem.TVItemID);

                        bool childExist = (from c in webProvince.SamplingPlanModelList
                                           where c.SamplingPlan.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem SamplingPlan", "SamplingPlan"));
                        }
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItem.TVItemID);

                        bool childExist = (from c in webSector.TVItemModelSubsectorList
                                           where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Sector", "Subsector"));
                        }
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItem.TVItemID);

                        bool childExist = (from c in webSubsector.TVItemModelClassificationList
                                           where c.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "Classification"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);

                        childExist = (from c in webMWQMRuns.MWQMRunModelList
                                           where c.MWQMRun.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "MWQMRun"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);

                        childExist = (from c in webMWQMSites.MWQMSiteModelList
                                      where c.MWQMSite.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Subsector", "MWQMSite"));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return;

                        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);

                        childExist = (from c in webPolSourceSites.PolSourceSiteModelList
                                      where c.PolSourceSite.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
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
                        WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, tvItem.TVItemID);

                        bool childExist = (from c in webTideSites.TideSiteModelList
                                           where c.TVItemModel.TVItem.TVItemID == tvItem.TVItemID
                                           && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Deleted
                                           select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem TideSite", "TideSite"));
                        }

                        WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSON<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites, tvItem.TVItemID);

                        childExist = (from c in webAllUseOfSites.UseOfSiteList
                                      where c.SiteTVItemID == tvItem.TVItemID
                                      && c.TVType == TVTypeEnum.TideSite
                                      && c.DBCommand != DBCommandEnum.Deleted
                                      select c).Any();

                        if (childExist)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem TideSite", "UseOfSite"));
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}