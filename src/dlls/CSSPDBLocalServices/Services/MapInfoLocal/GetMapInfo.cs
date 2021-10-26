/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{
    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        public async Task<List<MapInfoLocalModel>> GetMapInfoLocalModel(TVItem tvItemParent, TVItem tvItem)
        {
            List<MapInfoLocalModel> mapInfoLocalModelList = new List<MapInfoLocalModel>();

            List<TVItemModel> tvItemModelList = new List<TVItemModel>();
            double SquareSizeDecimalDegree = 0.5D;
            List<MapInfoDrawTypeEnum> mapInfoDrawTypeList = new List<MapInfoDrawTypeEnum>();

            switch (tvItem.TVType)
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
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polygon);
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webSubsector.TVItemModelClassificationList
                                           select c).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polyline);
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webClimateSites.ClimateSiteModelList
                                           select c.TVItemModel).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);
                        tvItemModelList = webRoot.TVItemModelCountryList;
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polygon);
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
                                    tvItemModelList = new List<TVItemModel>() { webArea.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.Country:
                                {
                                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webCountry.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.Infrastructure:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)tvItemParent.ParentID);

                                    InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
                                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                               select c).FirstOrDefault();

                                    if (infrastructureModel != null)
                                    {
                                        tvItemModelList = new List<TVItemModel>() { infrastructureModel.TVItemModel };
                                        SquareSizeDecimalDegree = 0.1D;
                                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                    }
                                }
                                break;
                            case TVTypeEnum.Province:
                                {
                                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webProvince.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.MikeScenario:
                                {
                                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                                    MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                                           where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                           select c).FirstOrDefault();

                                    if (mikeScenarioModel != null)
                                    {
                                        tvItemModelList = (from c in mikeScenarioModel.MikeSourceModelList
                                                           select c.TVItemModel).ToList();
                                        SquareSizeDecimalDegree = 0.1D;
                                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                    }
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webMunicipality.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, (int)tvItemParent.ParentID);

                                    MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
                                                                   where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                   select c).FirstOrDefault();

                                    if (mwqmSiteModel != null)
                                    {
                                        tvItemModelList = new List<TVItemModel>() { mwqmSiteModel.TVItemModel };
                                        SquareSizeDecimalDegree = 0.1D;
                                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                    }
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, (int)tvItemParent.ParentID);

                                    PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                             where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                                             select c).FirstOrDefault();

                                    if (polSourceSiteModel != null)
                                    {
                                        tvItemModelList = new List<TVItemModel>() { polSourceSiteModel.TVItemModel };
                                        SquareSizeDecimalDegree = 0.1D;
                                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                    }
                                }
                                break;
                            case TVTypeEnum.Root:
                                {
                                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webRoot.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.Sector:
                                {
                                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webSector.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                                }
                                break;
                            case TVTypeEnum.Subsector:
                                {
                                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, tvItemParent.TVItemID);
                                    tvItemModelList = new List<TVItemModel>() { webSubsector.TVItemModel };
                                    SquareSizeDecimalDegree = 0.1D;
                                    mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
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
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polyline);
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webHydrometricSites.HydrometricSiteModelList
                                           select c.TVItemModel).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel != null)
                        {
                            tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                               where c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                                               select c.TVItemModel).ToList();
                            SquareSizeDecimalDegree = 0.1D;
                            mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel != null)
                        {
                            tvItemModelList = (from c in mikeScenarioModel.MikeBoundaryConditionModelList
                                               where c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                               select c.TVItemModel).ToList();
                            SquareSizeDecimalDegree = 0.1D;
                            mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        // no checking required
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, (int)tvItemParent.ParentID);

                        MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
                                                               where c.TVItemModel.TVItem.TVItemID == tvItemParent.TVItemID
                                                               select c).FirstOrDefault();

                        if (mikeScenarioModel != null)
                        {
                            tvItemModelList = (from c in mikeScenarioModel.MikeSourceModelList
                                               select c.TVItemModel).ToList();
                            SquareSizeDecimalDegree = 0.1D;
                            mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        }
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, tvItemParent.TVItemID);
                        tvItemModelList = webProvince.TVItemModelMunicipalityList;
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        // no checking required
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webMWQMSites.MWQMSiteModelList
                                           select c.TVItemModel).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webPolSourceSites.PolSourceSiteModelList
                                           select c.TVItemModel).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, tvItemParent.TVItemID);
                        tvItemModelList = webCountry.TVItemModelProvinceList;
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polygon);
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        // no checking required
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
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polygon);
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, tvItemParent.TVItemID);
                        tvItemModelList = (from c in webSector.TVItemModelSubsectorList
                                           select c).ToList();
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Polygon);
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
                        SquareSizeDecimalDegree = 0.1D;
                        mapInfoDrawTypeList.Add(MapInfoDrawTypeEnum.Point);
                    }
                    break;
                default:
                    break;
            }

            foreach (MapInfoDrawTypeEnum mapInfoDrawType in mapInfoDrawTypeList)
            {
                MapInfoLocalModel mapInfoLocalModel = new MapInfoLocalModel();

                List<double> LatMaxList = new List<double>();
                List<double> LatMinList = new List<double>();
                List<double> LngMaxList = new List<double>();
                List<double> LngMinList = new List<double>();

                List<double> LatList = new List<double>();
                List<double> LngList = new List<double>();

                foreach (TVItemModel tvItemModel in tvItemModelList)
                {
                    List<MapInfoModel> mapInfoModelList = tvItemModel.MapInfoModelList;

                    foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                    {
                        LatMaxList.Add(mapInfoModel.MapInfo.LatMax);
                        LatMinList.Add(mapInfoModel.MapInfo.LatMin);
                        LngMaxList.Add(mapInfoModel.MapInfo.LngMax);
                        LngMinList.Add(mapInfoModel.MapInfo.LngMin);

                        foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                        {
                            LatList.Add(mapInfoPoint.Lat);
                            LngList.Add(mapInfoPoint.Lng);
                        }
                    }
                }

                MapInfo mapInfo = new MapInfo()
                {
                    DBCommand = DBCommandEnum.Created,
                    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    LatMax = 0.0D,
                    LatMin = 0.0D,
                    LngMax = 0.0D,
                    LngMin = 0.0D,
                    MapInfoDrawType = mapInfoDrawType,
                    MapInfoID = 0,
                    TVItemID = tvItem.TVItemID,
                    TVType = tvItem.TVType,
                };

                mapInfo.LatMax = LatMaxList.Average() + SquareSizeDecimalDegree;
                mapInfo.LatMin = LatMinList.Average() - SquareSizeDecimalDegree;
                mapInfo.LngMax = LngMaxList.Average() + SquareSizeDecimalDegree;
                mapInfo.LngMin = LngMinList.Average() - SquareSizeDecimalDegree;

                double LatAverage = LatList.Average();
                double LngAverage = LngList.Average();

                List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();

                if (mapInfoDrawType == MapInfoDrawTypeEnum.Point)
                {
                    MapInfoPoint mapInfoPoint = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage,
                        Lng = LngAverage,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 0,
                    };

                    mapInfoPointList.Add(mapInfoPoint);
                }
                else
                {
                    MapInfoPoint mapInfoPointBottomLeft = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage - SquareSizeDecimalDegree,
                        Lng = LngAverage - SquareSizeDecimalDegree,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 0,
                    };

                    mapInfoPointList.Add(mapInfoPointBottomLeft);

                    MapInfoPoint mapInfoPointBottomRight = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage - SquareSizeDecimalDegree,
                        Lng = LngAverage + SquareSizeDecimalDegree,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 1,
                    };

                    mapInfoPointList.Add(mapInfoPointBottomRight);

                    MapInfoPoint mapInfoPointTopRight = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage + SquareSizeDecimalDegree,
                        Lng = LngAverage + SquareSizeDecimalDegree,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 2,
                    };

                    mapInfoPointList.Add(mapInfoPointTopRight);

                    MapInfoPoint mapInfoPointTopLeft = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage + SquareSizeDecimalDegree,
                        Lng = LngAverage - SquareSizeDecimalDegree,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 3,
                    };

                    mapInfoPointList.Add(mapInfoPointTopLeft);

                    MapInfoPoint mapInfoPointBottomLeft2 = new MapInfoPoint()
                    {
                        DBCommand = DBCommandEnum.Created,
                        LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        Lat = LatAverage + SquareSizeDecimalDegree,
                        Lng = LngAverage - SquareSizeDecimalDegree,
                        MapInfoID = 0,
                        MapInfoPointID = 0,
                        Ordinal = 4,
                    };
                    
                    mapInfoPointList.Add(mapInfoPointBottomLeft2);
                }

                mapInfoLocalModel.MapInfo = mapInfo;
                mapInfoLocalModel.MapInfoPointList = mapInfoPointList;

                mapInfoLocalModelList.Add(mapInfoLocalModel);
            }
            return await Task.FromResult(mapInfoLocalModelList);
        }

    }
}
