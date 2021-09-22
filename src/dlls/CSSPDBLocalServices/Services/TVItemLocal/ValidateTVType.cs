/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private async Task<bool> ValidateTVType(PostTVItemModel postTVItemModel)
        {
            switch (postTVItemModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (postTVItemModel.TVItemParent.TVType)
                        {
                            case TVTypeEnum.Area:
                            case TVTypeEnum.Country:
                            case TVTypeEnum.Infrastructure:
                            case TVTypeEnum.MikeScenario:
                            case TVTypeEnum.Municipality:
                            case TVTypeEnum.MWQMSite:
                            case TVTypeEnum.PolSourceSite:
                            case TVTypeEnum.Province:
                            case TVTypeEnum.Root:
                            case TVTypeEnum.Sector:
                            case TVTypeEnum.Subsector:
                                break;
                            default:
                                if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                                }
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Area)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Sector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType));
                        }
                    }
                    break;
                default:
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType));
                    }
                    break;
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}