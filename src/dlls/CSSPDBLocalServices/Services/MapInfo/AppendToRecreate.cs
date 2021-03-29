/*
 * Manually edited
 *
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSSPDBLocalServices
{

    public partial class MapInfoService : ControllerBase, IMapInfoService
    {
        private void AppendToRecreate(List<ToRecreate> toRecreateList, TVItem tvItem, int year)
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