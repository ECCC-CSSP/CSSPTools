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
        private async Task<List<TVItemStatModel>> GetWebBaseList(WebTypeEnum webType, TVTypeEnum tvTypeList, int ParentTVItemID)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Country:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebRoot.TVItemStatMapModelCountryList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebRoot.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebCountry:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Province:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.TVItemStatMapModelProvinceList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.RainExceedance:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.RainExceedanceModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebCountry.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebProvince:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Area:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebProvince.TVItemStatMapAreaList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebProvince.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebArea:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Sector:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebArea.TVItemStatMapModelSectorList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebArea.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebSector:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Subsector:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSector.TVItemStatMapModelSubsectorList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSector.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebSubsector:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Classification:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSubsector.TVItemStatMapModelClassificationList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebSubsector.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebMunicipality:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Infrastructure:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeScenario:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemStatMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMunicipality.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebMWQMRuns:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.MWQMRun:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMWQMRuns.MWQMRunModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemStatModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemStatModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebMWQMSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.MWQMSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemStatMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    MWQMSiteModel mwqmSiteModel = (from c in ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList
                                                                   where c.MWQMSite.MWQMSiteTVItemID == ParentTVItemID
                                                                   select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mwqmSiteModel.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebAllContacts:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Contact:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebAllContacts.ContactModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebClimateSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.ClimateSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebClimateSites.ClimateSiteModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebHydrometricSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.HydrometricSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebHydrometricSites.HydrometricSiteModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebDrogueRuns:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
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
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeBoundaryConditionWebTide:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeSource:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeSourceModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    MikeScenarioModel mikeScenarioModel = (from c in ReadGzFileService.webAppLoaded.WebMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebAllHelpDocs:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTideLocations:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebPolSourceSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.PolSourceSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemStatMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemStatMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.File:
                                {
                                    PolSourceSiteModel polSourceSiteModel = (from c in ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList
                                                                             where c.PolSourceSite.PolSourceSiteTVItemID == ParentTVItemID
                                                                             select c).FirstOrDefault();

                                    return await Task.FromResult((from c in polSourceSiteModel.TVFileModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItem,
                                                                      TVItemLanguageList = c.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                case WebTypeEnum.WebAllPolSourceGroupings:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllReportTypes:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTVItems1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTVItems2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTVItemLanguages1980_2020:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTVItemLanguages2021_2060:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllMunicipalities:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllProvinces:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllCountries:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllAddresses:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllEmails:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebAllTels:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
                case WebTypeEnum.WebTideSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.TideSite:
                                {
                                    return await Task.FromResult((from c in ReadGzFileService.webAppLoaded.WebTideSites.TideSiteModelList
                                                                  select new TVItemStatModel
                                                                  {
                                                                      TVItem = c.TVItemMapModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemMapModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            default:
                                return await Task.FromResult(new List<TVItemStatModel>());
                        }
                    }
                default:
                    {
                        return await Task.FromResult(new List<TVItemStatModel>());
                    }
            }
        }
    }
}
