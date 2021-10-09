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
        private void ValidateTVType(TVItemLocalModel tvItemLocalModel)
        {
            switch (tvItemLocalModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        switch (tvItemLocalModel.TVItemParent.TVType)
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
                                if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                                {
                                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                                }
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Area)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Sector)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (tvItemLocalModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType, tvItemLocalModel.TVItemParent.TVType));
                        }
                    }
                    break;
                default:
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Adding_TVItemIsNotAllowed, tvItemLocalModel.TVItem.TVType));
                    }
                    break;
            }
        }
    }
}