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
        private bool ValidateAddOrModifyTVItemLocal(PostTVItemModel postTVItemModel)
        {
            ValidationResults = new List<ValidationResult>();

            if ((int)postTVItemModel.TVType == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" }));
            }

            string retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postTVItemModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" }));
            }

            if (postTVItemModel.ParentID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), new[] { "ParentID" }));
            }

            if ((int)postTVItemModel.ParentTVType == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postTVItemModel.ParentTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" }));
            }

            if (string.IsNullOrWhiteSpace(postTVItemModel.TVTextEN))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), new[] { "TVTextEN" }));
            }

            if (string.IsNullOrWhiteSpace(postTVItemModel.TVTextFR))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), new[] { "TVTextFR" }));
            }

            if (postTVItemModel.TVType == TVTypeEnum.File)
            {
                if (postTVItemModel.ParentTVType == TVTypeEnum.Infrastructure)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Municipality)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Municipality.ToString()), new[] { "GrandParentTVType" }));
                    }
                }

                if (postTVItemModel.ParentTVType == TVTypeEnum.MWQMSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else if (postTVItemModel.ParentTVType == TVTypeEnum.PolSourceSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else if (postTVItemModel.ParentTVType == TVTypeEnum.TideSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" }));
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" }));
                    }
                }
                else
                {
                    if (postTVItemModel.GrandParentID == null)
                    {
                        postTVItemModel.GrandParentID = 1;
                    }
                    if (postTVItemModel.GrandParentTVType == null)
                    {
                        postTVItemModel.GrandParentTVType = TVTypeEnum.Root;
                    }
                }
            }
            else
            {
                if (postTVItemModel.GrandParentID == null)
                {
                    postTVItemModel.GrandParentID = 1;
                }
                if (postTVItemModel.GrandParentTVType == null)
                {
                    postTVItemModel.GrandParentTVType = TVTypeEnum.Root;
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

            if (!AllowableTVTypes.Contains(postTVItemModel.TVType))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "TVType" }));
            }

            if (!AllowableTVTypes.Contains(postTVItemModel.ParentTVType))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ParentTVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { "TVType" }));
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}