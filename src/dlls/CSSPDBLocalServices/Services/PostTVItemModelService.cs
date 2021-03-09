/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CreateGzFileLocalServices;

namespace CSSPDBLocalServices
{

    public partial interface IPostTVItemModelService
    {
        //Task<ActionResult<bool>> Delete(int TVItemID);
        //Task<ActionResult<List<TVItem>>> GetTVItemList(int skip = 0, int take = 100);
        //Task<ActionResult<TVItem>> GetTVItemWithTVItemID(int TVItemID);
        Task<ActionResult<bool>> AddOrModify(PostTVItemModel postTVItemModel);
        //Task<ActionResult<TVItem>> Put(TVItem tvitem);
    }
    public partial class PostTVItemModelService : ControllerBase, IPostTVItemModelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private ICreateGzFileLocalService CreateGzFileLocalService { get; }
        private List<ToRecreate> ToRecreateList { get; set; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public PostTVItemModelService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
           CSSPDBLocalContext dbLocal, IReadGzFileService ReadGzFileService, ICreateGzFileLocalService CreateGzFileLocalService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.ReadGzFileService = ReadGzFileService;
            this.CreateGzFileLocalService = CreateGzFileLocalService;

            ToRecreateList = new List<ToRecreate>();
        }
        #endregion Constructors

        #region Functions public 
        //public async Task<ActionResult<TVItem>> GetTVItemWithTVItemID(int TVItemID)
        //{
        //    if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized(""));
        //    }

        //    TVItem tVItem = (from c in dbLocal.TVItems.AsNoTracking()
        //            where c.TVItemID == TVItemID
        //            select c).FirstOrDefault();

        //    if (tVItem == null)
        //    {
        //        return await Task.FromResult(NotFound(""));
        //    }

        //    return await Task.FromResult(Ok(tVItem));
        //}
        //public async Task<ActionResult<List<TVItem>>> GetTVItemList(int skip = 0, int take = 100)
        //{
        //    if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized(""));
        //    }

        //    List<TVItem> tVItemList = (from c in dbLocal.TVItems.AsNoTracking() orderby c.TVItemID select c).Skip(skip).Take(take).ToList();

        //    return await Task.FromResult(Ok(tVItemList));
        //}
        //public async Task<ActionResult<bool>> Delete(int TVItemID)
        //{
        //    if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    TVItem tVItem = (from c in dbLocal.TVItems
        //            where c.TVItemID == TVItemID
        //            select c).FirstOrDefault();

        //    if (tVItem == null)
        //    {
        //        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", TVItemID.ToString())));
        //    }

        //    try
        //    {
        //        dbLocal.TVItems.Remove(tVItem);
        //        dbLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
        //    }

        //    return await Task.FromResult(Ok(true));
        //}
        public async Task<ActionResult<bool>> AddOrModify(PostTVItemModel postTVItemModel)
        {
            ActionDBTypeEnum actionDBType = ActionDBTypeEnum.Update;

            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (postTVItemModel.TVItemID == 0)
            {
                actionDBType = ActionDBTypeEnum.Create;
            }

            ValidationResults = ValidateAndAddOrModify(new ValidationContext(postTVItemModel), actionDBType);
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> ValidateAndAddOrModify(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            string TVItemErrorMessage = "";
            bool HasError = false;
            TVItem ParentTVItem = new TVItem();
            List<WebBase> tvItemParentList = new List<WebBase>();
            List<WebBase> tvItemSiblingList = new List<WebBase>();
            List<WebBase> tvItemFileSiblingList = new List<WebBase>();
            PostTVItemModel postTVItemModel = validationContext.ObjectInstance as PostTVItemModel;

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)postTVItemModel.ParentTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVType"), new[] { "ParentTVType" });
            }

            if (postTVItemModel.ParentID == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), new[] { "ParentID" });
                HasError = true;
            }

            if ((int)postTVItemModel.TVType == 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" });
                HasError = true;
            }

            if (string.IsNullOrWhiteSpace(postTVItemModel.TVTextEN))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), new[] { "TVTextEN" });
                HasError = true;
            }

            if (string.IsNullOrWhiteSpace(postTVItemModel.TVTextFR))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), new[] { "TVTextFR" });
                HasError = true;
            }

            if (postTVItemModel.TVType == TVTypeEnum.File)
            {
                if (postTVItemModel.ParentTVType == TVTypeEnum.Infrastructure)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Municipality)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Municipality.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }

                if (postTVItemModel.ParentTVType == TVTypeEnum.MWQMSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }
                else if (postTVItemModel.ParentTVType == TVTypeEnum.PolSourceSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
                    }
                }
                else if (postTVItemModel.ParentTVType == TVTypeEnum.TideSite)
                {
                    if (postTVItemModel.GrandParentID == null || postTVItemModel.GrandParentID == 0)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "GrandParentID"), new[] { "GrandParentID" });
                        HasError = true;
                    }

                    if (postTVItemModel.GrandParentTVType != TVTypeEnum.Subsector)
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeOfType_, "GrandParentTVType", TVTypeEnum.Subsector.ToString()), new[] { "GrandParentTVType" });
                        HasError = true;
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
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVType",
                    "Root,Address,Area,Classification,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure," +
                    "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite," +
                    "PolSourceSite,Province,RainExceedance,Sector,Subsector,Tel"), new[] { nameof(postTVItemModel.TVType) });

                HasError = true;
            }

            if (!HasError)
            {
                switch (postTVItemModel.TVType)
                {
                    case TVTypeEnum.Address:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            if (ReadGzFileService.webAppLoaded.WebAllAddresses == null)
                            {
                                ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList;
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList;
                        }
                        break;
                    case TVTypeEnum.Classification:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList;
                        }
                        break;
                    case TVTypeEnum.ClimateSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList;
                        }
                        break;
                    case TVTypeEnum.Contact:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            if (ReadGzFileService.webAppLoaded.WebAllContacts == null)
                            {
                                ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList;
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList;
                        }
                        break;
                    case TVTypeEnum.File:
                        {
                            switch (postTVItemModel.ParentTVType)
                            {
                                case TVTypeEnum.Area:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebArea == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Country:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebCountry == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Infrastructure:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                        WebBase TVItemModelInfrastructure = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                        tvItemParentList.Add(TVItemModelInfrastructure);
                                        foreach (InfrastructureModel infrastructureModel in ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                        {
                                            tvItemFileSiblingList.AddRange(infrastructureModel.TVItemFileList);
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                    }
                                    break;
                                case TVTypeEnum.MikeScenario:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Municipality:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.MWQMSite:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebMWQMSite == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
                                        WebBase TVItemModelMWQMSite = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                        tvItemParentList.Add(TVItemModelMWQMSite);
                                        foreach (MWQMSiteModel mwqmSiteModel in ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                        {
                                            tvItemFileSiblingList.AddRange(mwqmSiteModel.TVItemFileList);
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                    }
                                    break;
                                case TVTypeEnum.PolSourceSite:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebPolSourceSite == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
                                        WebBase TVItemModelPolSourceSite = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
                                        tvItemParentList.Add(TVItemModelPolSourceSite);
                                        foreach (PolSourceSiteModel polSourceSiteModel in ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID))
                                        {
                                            tvItemFileSiblingList.AddRange(polSourceSiteModel.TVItemFileList);
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault().TVItemModel.TVItem;
                                    }
                                    break;
                                case TVTypeEnum.Province:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebProvince == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Root:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebRoot == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Sector:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebSector == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList;
                                    }
                                    break;
                                case TVTypeEnum.Subsector:
                                    {
                                        if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                                        {
                                            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                        }

                                        ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                                        tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                                        tvItemFileSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case TVTypeEnum.Email:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            if (ReadGzFileService.webAppLoaded.WebAllEmails == null)
                            {
                                ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList;
                        }
                        break;
                    case TVTypeEnum.HydrometricSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList;
                        }
                        break;
                    case TVTypeEnum.Infrastructure:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList;
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList;
                        }
                        break;
                    case TVTypeEnum.MikeScenario:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMunicipality == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList;
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            if (ReadGzFileService.webAppLoaded.WebMikeScenario == null)
                            {
                                ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList;
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            if (ReadGzFileService.webAppLoaded.WebProvince == null)
                            {
                                ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                                ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebProvince.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList;
                        }
                        break;
                    case TVTypeEnum.MWQMRun:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList;
                        }
                        break;
                    case TVTypeEnum.MWQMSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList;
                        }
                        break;
                    case TVTypeEnum.PolSourceSite:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSubsector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSubsector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList;
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList;
                        }
                        break;
                    case TVTypeEnum.RainExceedance:
                        {
                            if (ReadGzFileService.webAppLoaded.WebCountry == null)
                            {
                                ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebCountry.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList;
                        }
                        break;
                    case TVTypeEnum.Root:
                        {
                            // this should not happen for now
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            if (ReadGzFileService.webAppLoaded.WebArea == null)
                            {
                                ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebArea.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList;
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            if (ReadGzFileService.webAppLoaded.WebSector == null)
                            {
                                ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebSector.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList;
                        }
                        break;
                    case TVTypeEnum.Tel:
                        {
                            if (ReadGzFileService.webAppLoaded.WebRoot == null)
                            {
                                ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            if (ReadGzFileService.webAppLoaded.WebAllTels == null)
                            {
                                ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
                            }

                            ParentTVItem = ReadGzFileService.webAppLoaded.WebRoot.TVItemModel.TVItem;
                            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
                            tvItemSiblingList = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList;
                        }
                        break;
                    default:
                        break;
                }

                #region Writting to DBLocal
                // already exist
                if ((from c in tvItemSiblingList
                     where c.TVItemModel.TVItem.TVItemID != postTVItemModel.TVItemID
                     && c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText == postTVItemModel.TVTextEN
                     select c).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVTextEN), new[] { "TVTextEN" });
                }

                if ((from c in tvItemSiblingList
                     where c.TVItemModel.TVItem.TVItemID != postTVItemModel.TVItemID
                     && c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText == postTVItemModel.TVTextFR
                     select c).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, postTVItemModel.TVTextFR), new[] { "TVTextFR" });
                }

                // filling all parent TVItem in the DBLocal
                foreach (WebBase webBaseToAdd in tvItemParentList.OrderBy(c => c.TVItemModel.TVItem.TVLevel))
                {
                    if (!(from c in dbLocal.TVItems
                          where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                          select c).Any())
                    {
                        try
                        {
                            dbLocal.TVItems.Add(webBaseToAdd.TVItemModel.TVItem);
                            dbLocal.SaveChanges();
                            AppendToRecreate(webBaseToAdd.TVItemModel.TVItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                        }
                        catch (Exception ex)
                        {
                            TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                        {
                            yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", TVItemErrorMessage), new[] { "TVItem" });
                        }

                        foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                        {
                            if (!(from c in dbLocal.TVItemLanguages
                                  where c.TVItemID == webBaseToAdd.TVItemModel.TVItem.TVItemID
                                  && c.Language == lang
                                  select c).Any())
                            {

                                string TVItemLanguageErrorMessage = "";
                                try
                                {
                                    dbLocal.TVItemLanguages.Add(webBaseToAdd.TVItemModel.TVItemLanguageList[(int)lang]);
                                    dbLocal.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    TVItemLanguageErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, $"TVItemLanguage_{ lang }", ex.Message);
                                }

                                if (!string.IsNullOrWhiteSpace(TVItemLanguageErrorMessage))
                                {
                                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", TVItemLanguageErrorMessage), new[] { "TVItem" });
                                }
                            }
                        }
                    }
                }

                int TVItemIDNew = (from c in dbLocal.TVItems
                                   where c.TVItemID < 0
                                   orderby c.TVItemID descending
                                   select c.TVItemID).FirstOrDefault() - 1;

                if (postTVItemModel.TVItemID == 0)
                {
                    TVItem tvItemNew = new TVItem()
                    {
                        DBCommand = DBCommandEnum.Created,
                        IsActive = true,
                        ParentID = postTVItemModel.ParentID,
                        TVItemID = TVItemIDNew,
                        TVLevel = ParentTVItem.TVLevel + 1,
                        TVPath = $"{ ParentTVItem.TVPath }p{TVItemIDNew}",
                        TVType = postTVItemModel.TVType,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                    };

                    try
                    {
                        dbLocal.TVItems.Add(tvItemNew);
                        dbLocal.SaveChanges();
                        AppendToRecreate(tvItemNew, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                    }
                    catch (Exception ex)
                    {
                        TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                    }

                    if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                    {
                        yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItem" });
                    }

                    foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        int TVItemLanguageIDNew = (from c in dbLocal.TVItemLanguages
                                                   where c.TVItemLanguageID < 0
                                                   orderby c.TVItemLanguageID descending
                                                   select c.TVItemLanguageID).FirstOrDefault() - 1;

                        TVItemLanguage tvItemLanguageNew = new TVItemLanguage()
                        {
                            TVItemLanguageID = TVItemLanguageIDNew,
                            DBCommand = DBCommandEnum.Created,
                            TVItemID = TVItemIDNew,
                            Language = lang,
                            TranslationStatus = TranslationStatusEnum.Translated,
                            TVText = lang == LanguageEnum.fr ? postTVItemModel.TVTextFR : postTVItemModel.TVTextEN,
                            LastUpdateDate_UTC = DateTime.UtcNow,
                            LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID,
                        };


                        TVItemErrorMessage = "";
                        try
                        {
                            dbLocal.TVItemLanguages.Add(tvItemLanguageNew);
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                        {
                            yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItemLanguage" });
                        }
                    }
                }
                else
                {
                    WebBase WebBaseToChange = new WebBase();
                    foreach (WebBase webBase in tvItemSiblingList)
                    {
                        if (webBase.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItemID)
                        {
                            WebBaseToChange = webBase;
                            break;
                        }
                    }

                    TVItem tvItem = (from c in dbLocal.TVItems
                                     where c.TVItemID == WebBaseToChange.TVItemModel.TVItem.TVItemID
                                     select c).FirstOrDefault();

                    if (tvItem == null)
                    {
                        TVItem tvItemNew = WebBaseToChange.TVItemModel.TVItem;

                        dbLocal.TVItems.Add(tvItemNew);
                        AppendToRecreate(tvItemNew, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                        tvItem = tvItemNew;
                    }
                    else
                    {
                        tvItem.IsActive = WebBaseToChange.TVItemModel.TVItem.IsActive;
                    }

                    try
                    {
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message);
                    }

                    if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                    {
                        yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItem" });
                    }

                    foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        TVItemLanguage tvItemLanguage = (from c in dbLocal.TVItemLanguages
                                                         where c.TVItemLanguageID == WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID
                                                         select c).FirstOrDefault();

                        string tvText = lang == LanguageEnum.fr ? postTVItemModel.TVTextFR : postTVItemModel.TVTextEN;
                        if (tvItemLanguage == null)
                        {
                            TVItemLanguage tvItemLanguageNew = WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang];
                            if (WebBaseToChange.TVItemModel.TVItemLanguageList[(int)lang].TVText == tvText)
                            {
                                tvItemLanguageNew.DBCommand = DBCommandEnum.Original;
                            }
                            else
                            {
                                tvItemLanguageNew.DBCommand = DBCommandEnum.Modified;
                                tvItemLanguageNew.TVText = tvText;
                                tvItemLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
                                tvItemLanguageNew.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                            }

                            dbLocal.TVItemLanguages.Add(tvItemLanguageNew);
                            AppendToRecreate(tvItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                        }
                        else
                        {
                            if (tvItemLanguage.DBCommand == DBCommandEnum.Original)
                            {
                                tvItemLanguage.DBCommand = DBCommandEnum.Modified;
                            }
                            tvItemLanguage.TVText = tvText;
                            tvItemLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                            tvItemLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                        }

                        TVItemErrorMessage = "";
                        try
                        {
                            dbLocal.SaveChanges();
                            AppendToRecreate(tvItem, 1982, postTVItemModel.ParentTVType, (int)postTVItemModel.GrandParentID);
                        }
                        catch (Exception ex)
                        {
                            TVItemErrorMessage = string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(TVItemErrorMessage))
                        {
                            yield return new ValidationResult(TVItemErrorMessage, new[] { "TVItemLanguage" });
                        }

                    }
                }

                foreach (ToRecreate toRecreate in ToRecreateList)
                {
                    CreateGzFileLocalService.CreateGzFileLocal(toRecreate.WebType, toRecreate.TVItemID, toRecreate.WebTypeYear);
                }
            }
            #endregion Writting to DBLocal
        }


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

        private WebTypeYearEnum GetWebTypeYear(int year)
        {
            if (year > 2050)
            {
                return WebTypeYearEnum.Year2050;
            }
            else if (year > 2040)
            {
                return WebTypeYearEnum.Year2040;
            }
            else if (year > 2030)
            {
                return WebTypeYearEnum.Year2030;
            }
            else if (year > 2020)
            {
                return WebTypeYearEnum.Year2020;
            }
            else if (year > 2010)
            {
                return WebTypeYearEnum.Year2010;
            }
            else if (year > 2000)
            {
                return WebTypeYearEnum.Year2000;
            }
            else if (year > 1990)
            {
                return WebTypeYearEnum.Year1990;
            }
            else
            {
                return WebTypeYearEnum.Year1980;
            }
        }
    }
    #endregion Functions private
}
