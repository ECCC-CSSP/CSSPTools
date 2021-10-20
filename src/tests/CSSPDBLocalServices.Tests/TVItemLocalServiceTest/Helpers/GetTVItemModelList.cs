/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<List<TVItemModel>> GetTVItemModelList(WebTypeEnum webType, TVTypeEnum tvTypeList, int ParentTVItemID)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.Country:
                                {
                                    return await Task.FromResult((from c in webRoot.TVItemModelCountryList
                                                                  select c).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webRoot.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webCountry.TVItemModelProvinceList
                                                                  select c).ToList());
                                }
                            case TVTypeEnum.RainExceedance:
                                {
                                    return await Task.FromResult((from c in webCountry.RainExceedanceModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webCountry.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webProvince.TVItemModelAreaList select c).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webProvince.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webArea.TVItemModelSectorList
                                                                  select c).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webArea.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webSector.TVItemModelSubsectorList
                                                                  select c).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webSector.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webSubsector.TVItemModelClassificationList
                                                                  select c).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webSubsector.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webMunicipality.InfrastructureModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            case TVTypeEnum.MikeScenario:
                                {
                                    return await Task.FromResult((from c in webMikeScenarios.MikeScenarioModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        return await Task.FromResult((from c in webMunicipality.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webMWQMRuns.MWQMRunModelList
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
                                    return await Task.FromResult((from c in webMWQMSites.MWQMSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                            //                                       where c.MWQMSite.MWQMSiteTVItemID == ParentTVItemID
                            //                                       select c).FirstOrDefault();

                            //        return await Task.FromResult((from c in mwqmSiteModel.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
                            default:
                                return await Task.FromResult(new List<TVItemModel>());
                        }
                    }
                //case WebTypeEnum.WebAllContacts:
                //    {
                //        switch (tvTypeList)
                //        {
                //            case TVTypeEnum.Contact:
                //                {
                //                    return await Task.FromResult((from c in webAllContacts.ContactModelList
                //                                                  select new TVItemModel
                //                                                  {
                //                                                      TVItem = c.TVItemModel.TVItem,
                //                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                //                                                  }).ToList());
                //                }
                //            default:
                //                return await Task.FromResult(new List<TVItemModel>());
                //        }
                //    }
                case WebTypeEnum.WebClimateSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.ClimateSite:
                                {
                                    return await Task.FromResult((from c in webClimateSites.ClimateSiteModelList
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
                                    return await Task.FromResult((from c in webHydrometricSites.HydrometricSiteModelList
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
                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
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
                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
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
                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                           where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                                                                           select c).FirstOrDefault();

                                    return await Task.FromResult((from c in mikeScenarioModel.MikeSourceModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                            //                                               where c.MikeScenario.MikeScenarioTVItemID == ParentTVItemID
                            //                                               select c).FirstOrDefault();

                            //        return await Task.FromResult((from c in mikeScenarioModel.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                                    return await Task.FromResult((from c in webPolSourceSites.PolSourceSiteModelList
                                                                  select new TVItemModel
                                                                  {
                                                                      TVItem = c.TVItemModel.TVItem,
                                                                      TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                                                                  }).ToList());
                                }
                            //case TVTypeEnum.File:
                            //    {
                            //        PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                            //                                                 where c.PolSourceSite.PolSourceSiteTVItemID == ParentTVItemID
                            //                                                 select c).FirstOrDefault();

                            //        return await Task.FromResult((from c in polSourceSiteModel.TVFileModelList
                            //                                      select new TVItemModel
                            //                                      {
                            //                                          TVItem = c.TVItem,
                            //                                          TVItemLanguageList = c.TVItemLanguageList,
                            //                                      }).ToList());
                            //    }
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
                case WebTypeEnum.WebAllSearch:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    {
                        return await Task.FromResult(new List<TVItemModel>());
                    }
                //case WebTypeEnum.WebAllMunicipalities:
                //    {
                //        return await Task.FromResult((from c in webAllMunicipalities.TVItemModelList
                //                                      select c).ToList());
                //    }
                //case WebTypeEnum.WebAllProvinces:
                //    {
                //        return await Task.FromResult((from c in webAllProvinces.TVItemModelList
                //                                      select c).ToList());
                //    }
                //case WebTypeEnum.WebAllCountries:
                //    {
                //        return await Task.FromResult((from c in webAllCountries.TVItemModelList
                //                                      select c).ToList());
                //    }
                //case WebTypeEnum.WebAllAddresses:
                //    {
                //        return await Task.FromResult((from c in webAllAddresses.AddressModelList
                //                                      select new TVItemModel
                //                                      {
                //                                          TVItem = c.TVItemModel.TVItem,
                //                                          TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                //                                      }).ToList());
                //    }
                //case WebTypeEnum.WebAllEmails:
                //    {
                //        return await Task.FromResult((from c in webAllEmails.EmailModelList
                //                                      select new TVItemModel
                //                                      {
                //                                          TVItem = c.TVItemModel.TVItem,
                //                                          TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                //                                      }).ToList());
                //    }
                //case WebTypeEnum.WebAllTels:
                //    {
                //        return await Task.FromResult((from c in webAllTels.TelModelList
                //                                      select new TVItemModel
                //                                      {
                //                                          TVItem = c.TVItemModel.TVItem,
                //                                          TVItemLanguageList = c.TVItemModel.TVItemLanguageList,
                //                                      }).ToList());
                //    }
                case WebTypeEnum.WebTideSites:
                    {
                        switch (tvTypeList)
                        {
                            case TVTypeEnum.TideSite:
                                {
                                    return await Task.FromResult((from c in webTideSites.TideSiteModelList
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
