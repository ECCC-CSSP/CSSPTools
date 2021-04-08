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
        private bool ValidateDeleteTVItemLocal(DeleteTVItemModel deleteTVItemModel)
        {
            ValidationResults = new List<ValidationResult>();

            if (deleteTVItemModel.TVItemID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" }));
            }

            string retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)deleteTVItemModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" }));
            }

            if (deleteTVItemModel.ParentID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), new[] { "ParentID" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)deleteTVItemModel.ParentTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" }));
            }

            if (deleteTVItemModel.TVType == TVTypeEnum.File)
            {
                if (deleteTVItemModel.ParentTVType == TVTypeEnum.Infrastructure)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Municipality)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Municipality.ToString()), new[] { "GrandParentTVType" }));
                    }
                }

                if (deleteTVItemModel.ParentTVType == TVTypeEnum.MWQMSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else if (deleteTVItemModel.ParentTVType == TVTypeEnum.PolSourceSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else if (deleteTVItemModel.ParentTVType == TVTypeEnum.TideSite)
                {
                    if (deleteTVItemModel.GrandParentID == null || deleteTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (deleteTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else
                {
                    if (deleteTVItemModel.GrandParentID == null)
                    {
                        deleteTVItemModel.GrandParentID = 1;
                    }
                    if (deleteTVItemModel.GrandParentTVType == null)
                    {
                        deleteTVItemModel.GrandParentTVType = TVTypeEnum.Root;
                    }
                }
            }
            else
            {
                if (deleteTVItemModel.GrandParentID == null)
                {
                    deleteTVItemModel.GrandParentID = 1;
                }
                if (deleteTVItemModel.GrandParentTVType == null)
                {
                    deleteTVItemModel.GrandParentTVType = TVTypeEnum.Root;
                }
            }

            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.Classification,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.RainExceedance,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                    };

            if (!AllowableTVTypes.Contains(deleteTVItemModel.TVType))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "TVType" }));
            }

            if (!AllowableTVTypes.Contains(deleteTVItemModel.ParentTVType))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentTVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "ParentTVType" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}