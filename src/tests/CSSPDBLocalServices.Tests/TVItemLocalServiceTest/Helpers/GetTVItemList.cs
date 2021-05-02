/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<List<TVItemModel>> GetWebBaseList(WebTypeEnum webType, TVTypeEnum tvTypeList, int ParentTVItemID)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Country:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebRoot.TVItemModelCountryList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebCountry:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Province:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.TVItemModelProvinceList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.RainExceedance:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.RainExceedanceModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebProvince:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Area:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebProvince.TVItemModelAreaList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebArea:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Sector:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebArea.TVItemModelSectorList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebArea.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebSector:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Subsector:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSector.TVItemModelSubsectorList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSector.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Classification:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSubsector.TVItemModelClassificationList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Infrastructure:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeScenario:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.MWQMRun:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMWQMRuns.MWQMRunModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.MWQMSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                   where c.MWQMSite.MWQMSiteTVItemID == ParentTVItemID
                                                                   select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mwqmSiteModel.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Contact:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebAllContacts.ContactModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.ClimateSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebClimateSites.ClimateSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.HydrometricSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebHydrometricSites.HydrometricSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebMikeScenarios:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.MikeBoundaryConditionMesh:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionMesh)
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeBoundaryConditionWebTide:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeSource:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeSourceModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.PolSourceSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                             where c.PolSourceSite.PolSourceSiteTVItemID == ParentTVItemID
                                                                             select c).FirstOrDefault();

                                    return await Task.FromResult((from c in polSourceSiteModel.TVFileModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTVItems1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTVItems2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTVItemLanguages1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTVItemLanguages2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.TideSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebTideSites.TideSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                default:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
            }
        }
    }
}
