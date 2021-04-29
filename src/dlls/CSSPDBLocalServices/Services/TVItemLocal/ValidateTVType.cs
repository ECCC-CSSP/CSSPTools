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

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private bool ValidateTVType(PostTVItemModel postTVItemModel)
        {
            switch (postTVItemModel.TVItem.TVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Classification:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
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
                                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                                }
                                break;
                        }
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Municipality)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.MikeScenario)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Subsector)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.RainExceedance:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Country)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Area)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Sector)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Root)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (postTVItemModel.TVItemParent.TVType != TVTypeEnum.Province)
                        {
                            ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemUnder_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType, postTVItemModel.TVItemParent.TVType), new[] { "TVType" }));
                        }
                    }
                    break;
                default:
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.Adding_TVItemIsNotAllowed, postTVItemModel.TVItem.TVType), new[] { "TVType" }));
                    }
                    break;
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}