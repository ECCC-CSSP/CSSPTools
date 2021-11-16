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

    public partial class HelperLocalService : ControllerBase, IHelperLocalService
    {
        public async Task CheckIfSiblingsExistWithSameTVTextAsync(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR, int TVItemIDOrTVFileID)
        {
            List<TVItemModel> tvItemModelList = new List<TVItemModel>();
            List<TVFileModel> tvFileModelList = new List<TVFileModel>();

            switch (tvType)
            {
                case TVTypeEnum.Address:
                    {
                        // no checking required
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                        tvItemModelList = webProvince.TVItemModelAreaList;
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webSubsector.ClassificationModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webClimateSites.ClimateSiteModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
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
                                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                                    tvFileModelList = webArea.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                                    tvFileModelList = webCountry.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemParent.ParentID);

                                    InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    if (infrastructureModel == null)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "InfrastructureModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                        return;
                                    }

                                    tvFileModelList = infrastructureModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                                    tvFileModelList = webProvince.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    if (mikeScenarioModel == null)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                        return;
                                    }

                                    tvFileModelList = mikeScenarioModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                                    tvFileModelList = webMunicipality.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemParent.ParentID);

                                    MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    if (mwqmSiteModel == null)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMSiteModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                        return;
                                    }

                                    tvFileModelList = mwqmSiteModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemParent.ParentID);

                                    PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    if (polSourceSiteModel == null)
                                    {
                                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "PolSourceModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                                        return;
                                    }

                                    tvFileModelList = polSourceSiteModel.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                                    tvFileModelList = webRoot.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                                    tvFileModelList = webSector.TVFileModelList;
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                                    tvFileModelList = webSubsector.TVFileModelList;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webMunicipality.InfrastructureModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webHydrometricSites.HydrometricSiteModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                            return;
                        }

                        tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                            return;
                        }

                        tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webMikeScenarios.MikeScenarioModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel == null)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MikeScenarioModel", "TVItemID", tvItemParent.TVItemID.ToString()));
                            return;
                        }

                        tvItemModelList = (from c in mikeScenarioModel.MikeSourceModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                        tvItemModelList = webProvince.TVItemModelMunicipalityList;
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, tvItemParent.TVItemID);

                        tvItemModelList = (from c in webMWQMRuns.MWQMRunModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItemParent.TVItemID);

                        tvItemModelList = (from c in webMWQMSites.MWQMSiteModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItemParent.TVItemID);

                        tvItemModelList = (from c in webPolSourceSites.PolSourceSiteModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                        tvItemModelList = webCountry.TVItemModelProvinceList;
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webCountry.RainExceedanceModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                        tvItemModelList = new List<TVItemModel>() { webRoot.TVItemModel };
                    }
                    break;
                case TVTypeEnum.SamplingPlan:
                    {
                        // no checking required
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webArea.TVItemModelSectorList
                                           select c).ToList();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
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
                        WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webTideSites.TideSiteModelList
                                           select c.TVItemModel).ToList();
                    }
                    break;
                default:
                    break;
            }

            if (tvType == TVTypeEnum.File)
            {
                TVFileModel tvFileModelJSON = (from c in tvFileModelList
                                               where c.TVFile.TVFileID != TVItemIDOrTVFileID
                                               && c.TVFile.ServerFileName == TVTextEN
                                               || c.TVFile.ServerFileName == TVTextFR
                                               select c).FirstOrDefault();

                if (tvFileModelJSON != null)
                {
                    string message = "";

                    if (tvFileModelJSON.TVFile.ServerFileName == TVTextEN)
                    {
                        message = $"{ TVTextEN } (en)";
                    }
                    if (tvFileModelJSON.TVFile.ServerFileName == TVTextFR)
                    {
                        message = message + $"     { TVTextFR } (fr)";
                    }

                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, message));
                }
            }
            else
            {
                TVItemModel tvItemModelJSON = (from c in tvItemModelList
                                               where c.TVItem.TVItemID != TVItemIDOrTVFileID
                                               && (c.TVItemLanguageList[0].TVText == TVTextEN
                                               || c.TVItemLanguageList[1].TVText == TVTextFR)
                                               select c).FirstOrDefault();

                if (tvItemModelJSON != null)
                {
                    string message = "";

                    if (tvItemModelJSON.TVItemLanguageList[0].TVText == TVTextEN)
                    {
                        message = $"{ TVTextEN } (en)";
                    }
                    if (tvItemModelJSON.TVItemLanguageList[1].TVText == TVTextFR)
                    {
                        message = message + $"     { TVTextFR } (fr)";
                    }

                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, message));
                }
            }
        }
    }
}