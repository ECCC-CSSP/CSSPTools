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
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using CSSPHelperModels;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private async Task RecreateLocalGzFiles(List<TVItemModel> tvItemModelParentList)
        {
            if (tvItemModelParentList.Count == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "tvItemModelParentList"));
                return;
            }

            for (int i = 0, count = tvItemModelParentList.Count; i < count; i++)
            {
                switch (tvItemModelParentList[i].TVItem.TVType)
                {
                    case TVTypeEnum.Address:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Classification:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "Classification"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.ClimateSite:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "ClimateSites"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }

                            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Email:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.EmailDistributionList:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "EmailDistributionList"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.File:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "File"));
                                return;
                            }

                            switch (tvItemModelParentList[i - 1].TVItem.TVType)
                            {
                                case TVTypeEnum.Area:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Country:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Infrastructure:
                                    {
                                        if (i < 2)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "Infrastructure File"));
                                            return;
                                        }

                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, tvItemModelParentList[i - 2].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Province:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.MikeScenario:
                                    {
                                        if (i < 2)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MikeScenario File"));
                                            return;
                                        }

                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItemModelParentList[i - 2].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Municipality:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.MWQMSite:
                                    {
                                        if (i < 2)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MWQMSite File"));
                                            return;
                                        }

                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, tvItemModelParentList[i - 2].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.PolSourceSite:
                                    {
                                        if (i < 2)
                                        {
                                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "PolSourceSite File"));
                                            return;
                                        }

                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, tvItemModelParentList[i - 2].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Root:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot, 0);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Sector:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                                        }
                                    }
                                    break;
                                case TVTypeEnum.Subsector:
                                    {
                                        var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, tvItemModelParentList[i - 1].TVItem.TVItemID);
                                        if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                                        {
                                            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                            CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
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
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.HydrometricSite:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "HydrometricSites"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            if (i < 2)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MikeBoundaryConditionMesh"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItemModelParentList[i - 2].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            if (i < 2)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MikeBoundaryConditionWebTide"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItemModelParentList[i - 2].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MikeScenario:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            if (i < 2)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MikeSource"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItemModelParentList[i - 2].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }

                            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MWQMRun:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MWQMRun"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.MWQMSite:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "MWQMSite"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.PolSourceSite:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "PolSourceSite"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }

                            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.RainExceedance:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "RainExceedance"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Root:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.SamplingPlan:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "SamplingPlan"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, tvItemModelParentList[i].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }

                            actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMSubsectors, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.Tel:
                        {
                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels, 0);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    case TVTypeEnum.TideSite:
                        {
                            if (i == 0)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.ParentTVItemModelNotFoundFor_, "TideSites"));
                                return;
                            }

                            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, tvItemModelParentList[i - 1].TVItem.TVItemID);
                            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                            {
                                ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                                CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}