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
        private void AppendToRecreate(TVItem tvItem, int year, TVTypeEnum ParentTVType, int GrandParentID)
        {
            switch (tvItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllAddresses, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebArea, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebClimateSite, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllContacts, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, tvItem.TVItemID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllCountries, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllEmails, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (ParentTVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebArea, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenario, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSite, GrandParentID, GetWebTypeYear(year));
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, GrandParentID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebPolSourceSite, GrandParentID, GetWebTypeYear(year));
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, GrandParentID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebProvince, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebRoot, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSector, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, tvItem.TVItemID, GetWebTypeYear(year));
                                }
                                break;
                            case TVTypeEnum.TideSite:
                                {
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebTideSite, GrandParentID, GetWebTypeYear(year));
                                    ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, GrandParentID, GetWebTypeYear(year));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebHydrometricSite, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenario, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenario, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, (int)tvItem.ParentID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenario, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMikeScenario, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipality, tvItem.TVItemID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllMunicipalities, tvItem.TVItemID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMunicipalities, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMRun, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSite, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebPolSourceSite, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebProvince, tvItem.TVItemID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllProvinces, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebCountry, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebRoot, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSector, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebAllTels, (int)tvItem.ParentID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebSubsector, (int)tvItem.ParentID, GetWebTypeYear(year));
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebTideSite, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                case TVTypeEnum.MWQMSiteSample:
                    {
                        ToRecreate.AppendToRecreateList(ToRecreateList, WebTypeEnum.WebMWQMSample, tvItem.TVItemID, GetWebTypeYear(year));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}