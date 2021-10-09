/*
 * Manually edited
 *
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private void AppendToRecreate(TVItem tvItem, TVTypeEnum ParentTVType)
        {
            switch (tvItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllAddresses, 0);
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebArea, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebProvince, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebClimateSites, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllContacts, 0);
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllCountries, 0);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebRoot, 0);
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllEmails, 0);
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (ParentTVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebArea, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSites, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebPolSourceSites, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebProvince, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebRoot, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSector, (int)tvItem.ParentID);
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebHydrometricSites, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenarios, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllMunicipalities, 0);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMRuns, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.MWQMSiteSample:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSites, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebPolSourceSites, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllProvinces, 0);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, (int)tvItem.ParentID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebProvince, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, (int)tvItem.ParentID);
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebRoot, 0);
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebArea, (int)tvItem.ParentID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSector, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSector, (int)tvItem.ParentID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllTels, 0);
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebTideSites, (int)tvItem.ParentID);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}